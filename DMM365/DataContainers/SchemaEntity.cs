using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMM365.DataContainers
{
    [Serializable()]
    public class SchemaEntity
    {
        [XmlAttribute("displayname")]
        public string displayname { get; set; }

        [XmlAttribute("name")]
        public string name { get; set; }

        [XmlAttribute("etc", DataType = "int")]
        public int etc { get; set; }

        [XmlAttribute("disableplugins", DataType = "boolean")]
        public bool disableplugins { get; set; }

        [XmlAttribute("primaryidfield")]
        public string primaryidfield { get; set; }

        [XmlAttribute("primarynamefield")]
        public string primarynamefield { get; set; }

        [XmlAttribute ("isSelected", DataType = "boolean")]
        public bool isSelected { get; set; }

        [XmlAttribute("doDisablePlugin", DataType = "boolean")]
        public bool doDisablePlugin { get; set; }



        [XmlArray("fields")]
        [XmlArrayItem("field")]
        public List<SchemaField> fields { get; set; }

    }
}
