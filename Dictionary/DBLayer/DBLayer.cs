using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Dictionary
{
    public static partial class DBLayer
    {
        public static void applyChanges(this XDocument doc, string path)
        {
            doc.Save(path);
        }

        private static XElement getExistsOrCreateNewChild(this XElement el, string childName)
        {
            XElement e;
            if (el.Element(childName) != null)
                return el.Element(childName);
            else
            {
                e = new XElement(childName);
                el.Add(e);
                return e;
            }
        }
    }
}
