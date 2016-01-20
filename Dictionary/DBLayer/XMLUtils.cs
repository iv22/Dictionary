using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;


namespace Dictionary
{
    static class XMLUtils
    {
        public static XDocument getXmlDocument(string path)
        {
            /*string xmlPath;
            if (AppSettings.Default.XmlPath != "")
                xmlPath = AppSettings.Default.XmlPath;
            else
                xmlPath=Application.StartupPath;*/
            try
            {
                XDocument doc = XDocument.Load(path);
                return doc;
            }
            catch (UriFormatException ue)
            {
                MessageBox.Show(ue.Message);
                return null;
            }
            catch (Exception e)
            {
                //AppSettings.Default.XmlPath = "";
                //AppSettings.Default.Save();
                MessageBox.Show(e.Message);
                return null;
            }
        }

        public static XDocument getNewXmlDocument(string path)
        {
            XmlTextWriter writer = new XmlTextWriter(path, Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartElement("Dictionary");
           
            writer.Close();

            return getXmlDocument(path);
        }
    }
}
