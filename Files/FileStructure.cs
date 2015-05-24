using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Files
{
    class FileStructure
    {
        [XmlAttribute("filename")]
        public string Name { get; set; }

        [XmlAttribute("Path")]
        public string Path { get; set; }

        [XmlAttribute("Type")]
        public string Type { get; set; }
    }
}
