using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace DMM365.DataContainers
{
    [Serializable()]
    [XmlRoot("entities")]
    public class SchemaEntities
    {
        [XmlElement("entity")]
        public List<SchemaEntity> entities { get; set; }
    }
}
