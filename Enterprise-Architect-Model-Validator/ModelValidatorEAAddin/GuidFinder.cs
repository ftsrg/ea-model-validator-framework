/*
 *  Copyright 2023 Gergely Ulicska
 *  
 *  See the README file(s) distributed with this work for additional
 *  information regarding copyright ownership and contributors.
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */
using EA;
using System;
using System.Windows.Forms;

namespace ModelValidatorEAAddin
{
    internal sealed class GuidFinder
    {
        public static void FindGuid(Repository repository)
        {
            var clipboard = Clipboard.GetText();
            try
            {
                clipboard = clipboard.Split('{')[1].Split('}')[0];
                Guid guid = Guid.Parse(clipboard);
                string guidString = $"{{{guid}}}";
                try
                {
                    Diagram diagram = repository.GetDiagramByGuid(guidString);
                    repository.ShowInProjectView(diagram);
                }
                catch
                {
                    Package package = repository.GetPackageByGuid(guidString);
                    if (package != null)
                    {
                        repository.ShowInProjectView(package);
                        return;
                    }

                    Element element = repository.GetElementByGuid(guidString);
                    if (element != null)
                    {
                        HandleElement(repository, element);
                        return;
                    }

                    Connector connector = repository.GetConnectorByGuid(guidString);
                    if (connector != null)
                    {
                        element = repository.GetElementByID(connector.ClientID);
                        HandleElement(repository, element);
                        EAConsoleLogger.Instance.Info("Note that the provided GUID refers to a connector, start (client) object is shown.");
                        return;
                    }

                    EA.Attribute attribute = repository.GetAttributeByGuid(guidString);
                    if (attribute != null)
                    {
                        element = repository.GetElementByID(attribute.ParentID);
                        HandleElement(repository, element);
                        EAConsoleLogger.Instance.Info("Note that the provided GUID refers to an attribute, container (parent) object is shown.");
                        return;
                    }

                    EAConsoleLogger.Instance.Error($"GUID {guidString} is not valid in this model.");
                }
            }
            catch (IndexOutOfRangeException)
            {
                EAConsoleLogger.Instance.Error("No GUID provided on the clipboard.");
            }
            catch (ArgumentNullException)
            {
                EAConsoleLogger.Instance.Error("No GUID provided on the clipboard.");
            }
            catch (FormatException)
            {
                EAConsoleLogger.Instance.Error($"Provided text from the clipboard is not a GUID: {clipboard}");
            }
        }

        private static void HandleElement(Repository repository, Element element)
        {
            if (element.Type.Equals("Text") || element.Type.Equals("Note"))
            {
                var query = $"SELECT DISTINCT diagram_id FROM t_diagramobjects WHERE object_id = {element.ElementID}";
                var xml = repository.SQLQuery(query);
                if (xml == null || !xml.Contains("<diagram_id>"))
                {
                    EAConsoleLogger.Instance.Error($"GUID {element.ElementGUID} refers to a text/note object, but it does not appear on any diagram.");
                    return;
                }
                var pFrom = xml.IndexOf("<diagram_id>") + "<diagram_id>".Length;
                var pTo = xml.IndexOf("</diagram_id>");
                var diagramID = xml.Substring(pFrom, pTo - pFrom);
                repository.OpenDiagram(int.Parse(diagramID));
            }
            else
            {
                repository.ShowInProjectView(element);
            }
            Diagram diagram = repository.GetCurrentDiagram();
            diagram?.SelectedObjects.AddNew(element.ElementID.ToString(), "");
        }
    }
}
