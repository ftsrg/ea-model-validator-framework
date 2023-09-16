using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OCLtoSQL
{
    /// <summary>
    /// Enables basic operations with an Enterprise Architect DDL package
    /// </summary>
    public class DDLPackageControl
    {
        /// <summary>
        /// Transformes a new DDL package out of the selected PIM package.
        /// </summary>
        /// <param name="Repository">A new valid EA reporsitory reference.</param>
        public static void createDDLPackage(EA.Repository Repository)
        {
            EA.Package parentPackage = Repository.GetTreeSelectedPackage();

            try
            {
                EA.Package DDLPackage = parentPackage.Packages.GetByName("DDL");
                if (DDLPackage == null)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                //run DDL transformation into a new DDl package
                EA.Project project = Repository.GetProjectInterface();
                string targetPackageGuidXML = project.GUIDtoXML(parentPackage.PackageGUID);
                project.TransformPackage("DDL", targetPackageGuidXML, targetPackageGuidXML, null);
            }
        }

        /// <summary>
        /// Validates the new DDL package under the selected PIM package. It is needed to ensure that all needed data are inside.
        /// </summary>
        /// <param name="Repository">A new valid EA reporsitory reference.</param>
        public static bool reTransformDDLPackage(EA.Repository Repository)
        {
            EA.Package parentPackage = Repository.GetTreeSelectedPackage();
            EA.Package package;

            try
            {
                package = parentPackage.Packages.GetByName("DDL");
                if (package == null)
                {
                    //no DDL package
                    return false;
                }
            }
            catch (Exception)
            {
                //no DDL package
                return false;
            }

            EA.Project project = Repository.GetProjectInterface();
            string packageGuidXML = project.GUIDtoXML(package.PackageGUID);
            string parentPackageGuidXML = project.GUIDtoXML(parentPackage.PackageGUID);
            string temporaryFile = null;
            try
            {
                temporaryFile = System.IO.Path.GetTempFileName();
                project.ExportPackageXMI(packageGuidXML, EA.EnumXMIType.xmiEADefault, 2, 3, 1, 0, temporaryFile);
                short i = 0;
                foreach (EA.Package childPackage in parentPackage.Packages)
                {
                    if (childPackage.PackageID == package.PackageID)
                    {
                        parentPackage.Packages.Delete(i);
                    }
                    ++i;
                }
                parentPackage.Update();
                project.ImportPackageXMI(parentPackageGuidXML, temporaryFile, 1, 0);
            }
            catch (Exception)
            {
            }
            finally
            {
                if (temporaryFile != null)
                {
                    try
                    {
                        System.IO.File.Delete(temporaryFile);
                    }
                    catch (Exception) { }
                }
            }

            return true;
        }
    }
}
