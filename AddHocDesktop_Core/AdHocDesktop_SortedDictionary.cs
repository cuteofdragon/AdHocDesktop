using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Schema;

namespace AdHocDesktop.Core
{
    public class AdHocDesktop_SortedDictionary : SortedDictionary<string, string>, IXmlSerializable
    {
        const string ns = "http://www.cte.cju.edu.tw/xml/serialization";
        const string schema =
            "<xs:schema id='DictionarySchema' " +
                "targetNamespace='http://www.cte.cju.edu.tw/xml/serialization' " +
                "elementFormDefault='qualified' " +
                "xmlns='http://www.cte.cju.edu.tw/xml/serialization' " +
                "xmlns:mstns='http://www.cte.cju.edu.tw/xml/serialization' " +
                "xmlns:xs='http://www.w3.org/2001/XMLSchema'>" +
            "<xs:complexType name='DictionaryType'>" +
                "<xs:sequence>" +
                    "<xs:element name='Item' type='ItemType' maxOccurs='unbounded' />" +
                "</xs:sequence>" +
            "</xs:complexType>" +
            "<xs:complexType name='ItemType'>" +
                "<xs:sequence>" +
                    "<xs:element name='Key' type='xs:string' />"+
                    "<xs:element name='Value' type='xs:string' />" +
                "</xs:sequence>" +
            "</xs:complexType>" +
            "<xs:element name='Dictionary' type='mstns:DictionaryType'>" +
            "</xs:element>" +
            "</xs:schema>";

        public AdHocDesktop_SortedDictionary()
        { }

        public AdHocDesktop_SortedDictionary(XmlElement element)
        {
            XmlNodeList itemList = element.GetElementsByTagName("Item", ns);
            foreach (XmlElement item in itemList)
            {
                string key = item.GetElementsByTagName("Key", ns)[0].InnerText;
                string value = item.GetElementsByTagName("Value", ns)[0].InnerText;
                base.Add(key, value);
            }
        }

        public void WriteXml(XmlWriter w)
        {
            w.WriteStartElement("Dictionary", ns);
            foreach (string key in base.Keys)
            {
                string value = base[key];
                w.WriteStartElement("Item", ns);
                w.WriteElementString("Key", ns, key.ToString());
                w.WriteElementString("Value", ns, value.ToString());
                w.WriteEndElement();
            }
            w.WriteEndElement();
        }

        public void ReadXml(XmlReader r)
        {
            r.Read(); // move past container
            r.ReadStartElement("Dictionary");
            while (r.NodeType != XmlNodeType.EndElement)
            {
                r.ReadStartElement("Item", ns);
                string key = r.ReadElementString("Key", ns);
                string value = r.ReadElementString("Value", ns);
                r.ReadEndElement();
                r.MoveToContent();
                base.Add(key, value);
            }
        }

        public XmlSchema GetSchema()
        {
            return XmlSchema.Read(new StringReader(schema), null);
        }

    }
}
