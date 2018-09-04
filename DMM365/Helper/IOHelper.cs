using System;
using System.IO;
using DMM365.DataContainers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Reflection;
using System.Security.AccessControl;

namespace DMM365.Helper
{
    public static class IOHelper
    {
        /// <summary>
        /// Copy files, overrides on doOverride = true, else appends
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="doOverride"></param>
        internal static void copyFile(string sourcePath, string destinationPath, bool doOverride) {

            //File.Copy(sourcePath, destinationPath, doOverride);

            FileStream inf = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            FileStream outf = new FileStream(destinationPath, doOverride ? FileMode.Create : FileMode.Append);
            int content;
            while ((content = inf.ReadByte()) != -1)
            {
                outf.WriteByte((byte)content);
            }
            inf.Close();
            inf.Dispose();
            outf.Close();
            outf.Dispose();
        }

        internal static void clearDirectory(string directoryPath)
        {
            DirectoryInfo dir = new DirectoryInfo(directoryPath);

            foreach (FileInfo files in dir.GetFiles())
            {
                foreach (FileInfo file in dir.GetFiles())
                    file.Delete();
                foreach (DirectoryInfo subDirectory in dir.GetDirectories())
                    dir.Delete(true);
            }
        }

        internal static void deleteFile(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            file.Delete();
        }


        /// <summary>
        /// Creates/overrides file specified in the patch with new content
        /// </summary>
        /// <param name="resourceName"></param>
        /// <param name="path"></param>
        internal static void updateContent(string path, string content)
        {

            //var assembly = Assembly.GetExecutingAssembly();
            //using (Stream dll = assembly.GetManifestResourceStream(resourceName))
            //{
            //    using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileSystemRights.FullControl, FileShare.ReadWrite, (int)dll.Length, FileOptions.None))// File.Create(path, (int)dll.Length, FileOptions.))
            //    {
            //        byte[] b = new byte[dll.Length];
            //        dll.Read(b, 0, b.Length);
            //        file.Write(b, 0, b.Length);
            //    }
            //}

            //override

            File.WriteAllText(path, content, Encoding.UTF8);


        }


        /// <summary>
        /// Creates projects directories starting from ProjectPath property and based on subFolders enum values
        /// </summary>
        /// <param name="settings"></param>
        internal static void setInnerProjectStructure(AllSettings settings)
        {
            IEnumerable<KeyValuePair<int, string>> directoriesNames = enumToList.Of<subFolders>(false);

            foreach (KeyValuePair<int, string> item in directoriesNames)
            {
                string path = Path.Combine(settings.ProjectPath, item.Value);
                if (Directory.Exists(path)) continue;
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Obsolete
        /// Returns abolute path to project folder selected by folder param.
        /// Appends directory name or file name with/without extention
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="folder"></param>
        /// <returns></returns>
        internal static string getProjectSubfolderPathOld(AllSettings settings, subFolders folder, bool appendFileName = true, string extensionAttach = "")
        {
            string dir = Path.Combine(settings.ProjectPath, folder.ToString());
            if (Directory.Exists(dir))
            {
                string fileName = folder.ToString();
                if (GlobalHelper.isValidString(fileName) && appendFileName) return Path.Combine(dir, fileName + extensionAttach);
                else return dir;
            }

            return string.Empty;
        }


        internal static string getProjectSubfolderPath(AllSettings settings, subFolders folder, fileName extentionSelector, string fileNameAndExt = "")
        {
            string result = string.Empty;
            string dir = Path.Combine(settings.ProjectPath, folder.ToString());
            if (Directory.Exists(dir))
            {
                string fileName = folder.ToString();

                switch (extentionSelector.ToString())
                {
                    case "pathToFolderFromProjectRoot": result = dir; break;
                    case "appendFolderNameNoExt": result = Path.Combine(dir, fileName); break;
                    case "appendFolderNameDotXml": result = Path.Combine(dir, fileName + ".xml"); break;
                    case "appendFolderNameDotZip": result = Path.Combine(dir, fileName + ".zip"); break;
                    case "appendfolderNameDotPSscript": result = Path.Combine(dir, fileName + ".ps1"); break;
                    case "dataFileXml": result = Path.Combine(dir, "data.xml"); break;
                    case "dataSchemaXml": result = Path.Combine(dir, "data_schema.xml"); break;
                    case "contentTypesXml": result = Path.Combine(dir, @"[Content_Types].xml"); break;
                    default:
                        if (GlobalHelper.isValidString(fileNameAndExt)) result = Path.Combine(dir,fileNameAndExt);
                        break;
                }
            }
            return result;
        }



        /// <summary>
        /// returns absolute path to project xml
        /// </summary>
        /// <param name="allSettings"></param>
        /// <returns></returns>
        internal static string getPathToProjectFile(AllSettings allSettings)
        {
            if (Directory.Exists(allSettings.ProjectPath))
            {
                string dirName = new DirectoryInfo(allSettings.ProjectPath).Name;
                return Path.Combine(allSettings.ProjectPath, dirName + ".xml");
            }
            else return string.Empty;
        }


        /// <summary>
        /// Object to XML string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string SerializeToXmlString<T>(object obj)
        {
            string result = string.Empty;

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (StringWriter objectReader = new StringWriter())
            {
                xmlSerializer.Serialize(objectReader, obj);
                result = objectReader.ToString();
            }

            return result;
        }


        /// <summary>
        /// Deserialize and load Xml from file of an xml string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static T DeserializeXmlFromFile<T>(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (TextReader textReader = new StreamReader(path))
            {
                return (T)xmlSerializer.Deserialize(textReader);
            }
        }

        /// <summary>
        /// Object to xml file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="pathWithFileName"></param>
        /// <returns></returns>
        internal static void SerializeObjectToXmlFile<T>(object obj, string pathWithFileName)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (FileStream file = File.OpenWrite(pathWithFileName))
            {
                xmlSerializer.Serialize(file, obj);
            }
        }


        /// <summary>
        /// JSON to object of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        internal static T DeserializeJsonObject<T>(string json)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                StreamWriter writer = new StreamWriter(stream);
                writer.Write(json);
                writer.Flush();
                stream.Position = 0;
                T responseObject = (T)serializer.ReadObject(stream);
                return responseObject;
            }
        }

        /// <summary>
        /// Object of type T to JSON
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        internal static string SerializeObjectToJson<T>(object obj)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
                serializer.WriteObject(stream, obj);
                return Encoding.UTF8.GetString(stream.ToArray());
                //stream.Position = 0;
                //StreamReader reader = new StreamReader(stream);
                //string requestBody = reader.ReadToEnd();
                //return requestBody;
            }
        }

    }
}
