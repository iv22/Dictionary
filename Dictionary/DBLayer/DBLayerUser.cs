using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace Dictionary
{
    static partial class DBLayer
    { 
        public static List<User> getAllUsers(this XDocument doc, string dirDict)
        {
            var filtered = from r in doc.Descendants("Users").Descendants("User")
                           select new
                           {
                               uId = (string)r.Attribute("id").Value,
                               uName = (string)r.Attribute("name").Value,
                               uReg = (string)r.Attribute("reg_date").Value
                           };
            List<User> UserList;
            UserList = new List<User>();
            int i;
            DateTime dt;
            foreach (var v in filtered)
            {
                if (int.TryParse(v.uId, out i) && DateTime.TryParse(v.uReg, out dt))
                    UserList.Add(new User(i, v.uName, dt, delegate(User u) { return getUserDictionaries(dirDict, u); }));  
            }
            
            return UserList;
        }


        public static List<MyDictionary> getUserDictionaries(string path, User u)
        {
            List<MyDictionary> DictionaryList = new List<MyDictionary>();
            XDocument doc;
            if (u != null)
                foreach (var s in Directory.GetFiles(path, "*.xml", SearchOption.TopDirectoryOnly))
                {
                    doc = XMLUtils.getXmlDocument(s);
                    var filtered = from d in doc.Descendants("Dictionary")
                                   where d.Attribute("opened").Value == "true" ||
                                   int.Parse(d.Attribute("id_user").Value) == u.id
                                   select new
                                   {
                                       id = long.Parse(d.Attribute("id").Value),
                                       name = (string)d.Attribute("name").Value,
                                       path = s,
                                       opened = (d.Attribute("opened").Value == "true")
                                   };

                    if (filtered.Count() > 0)
                    {
                        var dict = filtered.Single();
                        DictionaryList.Add(new MyDictionary(dict.id, dict.name, dict.path, dict.opened,
                            delegate(MyDictionary d) { return getDictionaryWords(d, u); }));
                    }
                }
            return DictionaryList;
        }

        public static void addUser(this XDocument doc, User u)
        {
            System.Nullable<int> lastUserId =
                (from el in doc.Descendants("Users").Descendants("User")
                 select int.Parse(el.Attribute("id").Value)).Max();
            if (lastUserId == null)
                lastUserId = 1;
            else
                lastUserId = lastUserId + 1;
            XElement Element = new XElement("User",
                new XAttribute("id", lastUserId), 
                new XAttribute("name", u.name),
                new XAttribute("reg_date", u.reg_date));
            doc.Descendants("Users").First().Add(Element);
        }

        public static void addUser(this XDocument doc, List<User> lu)
        {
            foreach(User u in lu)
                addUser(doc, u);
        }

        public static void updUser(this XDocument doc, User u)
        {
            IEnumerable<XElement> elUser =
               from el in doc.Descendants("Users").Descendants("User")
               where int.Parse(el.Attribute("id").Value) == u.id
               select el;

            elUser.Single().Attribute("name").Value = u.name;
        }

        public static void delUser(this XDocument doc, User u)
        {
             IEnumerable<XElement> elUser=
                from el in doc.Descendants("Users").Descendants("User")
                where int.Parse(el.Attribute("id").Value) == u.id
                select el;

             elUser.Single().Remove();
        }
    }
}
