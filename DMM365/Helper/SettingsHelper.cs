using DMM365.DataContainers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMM365.Helper
{
    public static class SettingsHelper
    {

        internal static void projectFileLoad(AllSettings allSettings)
        {
            string projectFileName = string.Empty;
            AllSettings settingsLoaded = new AllSettings();

            projectFileName = IOHelper.getPathToProjectFile(allSettings);
            if(GlobalHelper.isValidString(projectFileName))
            { 
                //if DirectoryName.xml exists => existing project, load settings
                if (File.Exists(projectFileName))
                {
                    settingsLoaded = IOHelper.DeserializeXmlFromFile<AllSettings>(projectFileName);

                    //copy deserialized properties
                    GlobalHelper.copyObjectProperies(settingsLoaded, allSettings);

                    //get and load passwords is available
                    allSettings.PasswordSource = CredentialsHelper.getLocalPassword(string.Concat(allSettings.OrgUniqueNameSource, allSettings.ServerUrlSource, allSettings.UsernameSource));

                    allSettings.IsDirty = false;
                }
                //else create/update settings object,create DirectoryName.xml and write settings there
                else
                {
                    saveProject(allSettings);
                    return;
                }
            }
            //else message "wrong rooth"
            else throw new Exception("The root is not appropriate");
        }


        internal static void saveProject(AllSettings allSettings)
        {
            //clean previous project file to prevent corruption
            IOHelper.deleteFile(IOHelper.getPathToProjectFile(allSettings));

            IOHelper.SerializeObjectToXmlFile<AllSettings>(allSettings, IOHelper.getPathToProjectFile(allSettings));
            allSettings.IsDirty = false;
        }

    }
}
