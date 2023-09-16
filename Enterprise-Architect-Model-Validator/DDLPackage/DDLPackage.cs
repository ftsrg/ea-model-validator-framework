using EA;
using System;
using System.Collections.Generic;

namespace OCLtoSQL
{
    /// <summary>
    /// Enables to get information from an Enterprise Architect DDL package.
    /// </summary>
    public class DDLPackage
    {
        /// <summary>
        /// Creates a new DDLPackage.
        /// </summary>
        /// <param name="Repository">A new valid Enterprise Architect reporsitory reference.</param>
        public DDLPackage(EA.Repository Repository, string PIMPackageGUID, string DDLPackageGUID)
        {
            this.Repository = Repository;
            this.PIMPackageGUID = PIMPackageGUID;
            this.DDLPackageGUID = DDLPackageGUID;
        }

        EA.Repository Repository;
        private string PIMPackageGUID;
        private string DDLPackageGUID;

        private static Element getElementInPackage(Package package, string name)
        {
            Element element = null;
            try
            {
                element = package.Elements.GetByName(name);
                if (element != null)
                    return element;
            }
            catch (Exception) { }
            foreach (Element e in package.Elements)
            {
                try
                {
                    element = e.Elements.GetByName(name);
                    if (element != null)
                        return element;
                }
                catch (Exception) { }
            }
            foreach (Package e in package.Packages)
            {
                try
                {
                    element = e.Elements.GetByName(name);
                    if (element != null)
                        return element;
                }
                catch (Exception) { }
            }
            return null;
        }

        /// <summary>
        /// Gets the join data for navigation.
        /// </summary>
        /// <param name="navigateFrom">Name of the class to navigate from.</param>
        /// <param name="navigateTo">Entity to navigate to - either another class or its attribute.</param>
        /// <returns>Data needed for joining appropriate tables along the navigateTo Connector,
        /// null if navigateTo is not a Connector but a property,
        /// throws an Exception otherwise</returns>
        public List<NavigationItem> getNavigation(string navigateFrom, string navigateTo)
        {
            EA.Package PIMPackage = Repository.GetPackageByGuid(PIMPackageGUID);
            EA.Package DDLPackage = Repository.GetPackageByGuid(DDLPackageGUID);
            if (DDLPackage == null)
            {
                throw new Exception();
            }

            //Console.WriteLine($"{navigateFrom}-->{navigateTo}");
            EA.Element navigateFromElement = getElementInPackage(DDLPackage, navigateFrom);
            if (navigateFromElement == null)
            {
                throw new Exception();
            }

            var element = getElementInPackage(PIMPackage, navigateFrom);
            foreach (EA.Attribute a in ((EA.Element)element).Attributes)    // needed to work on hierarchies
            {
                if (a.Name == navigateTo) //is a column
                {
                    return null;
                }
            }

            //PIM association through which we want to navigate
            EA.Connector PIMassociation = getConnectorFromItsRole(PIMPackage, navigateFrom, navigateTo);
            if (PIMassociation == null)
            {
                throw new Exception();
            }

            //four possibilities: 1:1, 1:n, n:1, n:n (1 can also be 0, but behaves the same for our purposes)
            //n:n ... through another table; in the table special columns may be found for FKs
            //1:n ... FK from the second table on the first (special column made in the second table - name same as the navigateTo)
            //n:1 ... FK from the first table on the second (special column made in the first table)

            if (isConnectorManyToMany(PIMassociation))
            {
                return getManyToManyNavigation(Repository, DDLPackage, navigateFromElement, PIMassociation.Name);
            }
            else
            {
                return getOneToManyNavigation(Repository, navigateFromElement, PIMassociation.Name);
            }
        }

        private static bool isConnectorManyToMany(EA.Connector connector)
        {
            return (((connector.ClientEnd.Cardinality == "0..*") || (connector.ClientEnd.Cardinality == "1..*"))
                    && ((connector.SupplierEnd.Cardinality == "0..*") || (connector.SupplierEnd.Cardinality == "1..*"))
                    );
        }

        private static List<NavigationItem> getManyToManyNavigation(EA.Repository Repository, EA.Package DDLPackage, EA.Element navigateFromElement, string PIMassociationName)
        {
            //n:n -> PIM connector name as the name of the connecting table
            EA.Element overElement = DDLPackage.Elements.GetByName(PIMassociationName);
            if (overElement == null)
            {
                return null;
            }

            EA.Connector firstConnector = getConnectorBetweenElements(navigateFromElement, overElement);
            if (firstConnector == null)
            {
                return null;
            }
            EA.Connector secondConnector = null; //is the other one from overElement
            foreach (EA.Connector connector in overElement.Connectors)
            {
                if (connector.ConnectorID != firstConnector.ConnectorID)
                {
                    secondConnector = connector;
                }
            }

            List<NavigationItem> navigationItems = getOneToManyNavigation(Repository, navigateFromElement, firstConnector);
            navigationItems.AddRange(getOneToManyNavigation(Repository, overElement, secondConnector));

            return navigationItems;
        }

        private static List<NavigationItem> getOneToManyNavigation(EA.Repository Repository, EA.Element navigateFromElement, EA.Connector throughConnector)
        {
            string[] joincolumns = parseJoincolumns(throughConnector);
            if (throughConnector.ClientID == navigateFromElement.ElementID)
            {
                //first column from source
                string targetTable = Repository.GetElementByID(throughConnector.SupplierID).Name;
                return new List<NavigationItem>
                    {
                        new NavigationItem(targetTable, joincolumns[0], joincolumns[1])
                    };
            }
            else
            {
                //second column from source
                string targetTable = Repository.GetElementByID(throughConnector.ClientID).Name;
                return new List<NavigationItem>
                    {
                        new NavigationItem(targetTable, joincolumns[1], joincolumns[0])
                    };
            }
        }

        private static List<NavigationItem> getOneToManyNavigation(EA.Repository Repository, EA.Element navigateFromElement, string PIMassociationName)
        {
            //n:1/1:n/1:1 -> PIM connector name as the source role of PSM connector
            EA.Connector throughConnector = null;
            foreach (EA.Connector connector in navigateFromElement.Connectors)
            {
                if (connector.ClientEnd.Role == PIMassociationName)
                {
                    throughConnector = connector;
                }
            }
            if (throughConnector == null)
            {
                return null;
            }

            return getOneToManyNavigation(Repository, navigateFromElement, throughConnector);
        }

        private static EA.Connector getConnectorBetweenElements(EA.Element navigateFromElement, EA.Element navigateToElement)
        {
            List<EA.Connector> connectors = new List<EA.Connector>();
            foreach (EA.Connector connectorFrom in navigateFromElement.Connectors)
            {
                foreach (EA.Connector connectorTo in navigateToElement.Connectors)
                {
                    if (connectorFrom.ConnectorID == connectorTo.ConnectorID)
                    {
                        connectors.Add(connectorFrom);
                    }
                }
            }

            if (connectors.Count == 1)
            {
                return connectors[0];
            }
            else
            {
                return null;
            }

        }

        private static EA.Connector getConnectorFromItsRole(EA.Package package, string elementName, string roleName)
        {
            EA.Element navigateFromElement = getElementInPackage(package, elementName);
            if (navigateFromElement == null)
            {
                return null;
            }

            foreach (EA.Connector connector in navigateFromElement.Connectors)
            {
                string furtherRoleName;
                if (connector.ClientID == navigateFromElement.ElementID)
                {
                    furtherRoleName = connector.SupplierEnd.Role;
                    if (connector.SupplierID == navigateFromElement.ElementID) //connector starting from and ending on the same element
                    {
                        if (connector.ClientEnd.Role == roleName)
                        {
                            return connector;
                        }
                    }
                }
                else
                {
                    furtherRoleName = connector.ClientEnd.Role;
                }

                if (furtherRoleName == roleName)
                {
                    return connector;
                }
            }

            return null;
        }

        private static string[] parseJoincolumns(EA.Connector connector)
        {
            string joinString = connector.Name;

            string[] joinColumns = joinString.Split(new string[] { "(", ")", " = " }, StringSplitOptions.RemoveEmptyEntries);
            if ((joinColumns == null) || (joinColumns.Length != 2))
            {
                return null;
            }

            return joinColumns;
        }
    }
}
