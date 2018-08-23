using System;
using System.Xml.Serialization;

namespace DMM365.DataContainers
{
    [Serializable()]
    public class SchemaField
    {

        [XmlAttribute("displayname", DataType = "string")]
        public string displayname { get; set; }

        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("type")]
        public string type { get; set; }

        [XmlAttribute("customfield", DataType = "boolean")]
        public bool customfield { get; set; }

        [XmlAttribute("primaryKey", DataType = "boolean")]
        public bool primaryKey { get; set; }

        [XmlAttribute("lookupType")]
        public string lookupType { get; set; }


        [XmlAttribute("isSelected", DataType = "boolean")]
        public bool isSelected { get; set; }
    }

}
