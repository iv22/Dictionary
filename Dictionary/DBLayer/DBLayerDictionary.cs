using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace Dictionary
{
    static partial class DBLayer
    {
        public static List<Word> getDictionaryWords(MyDictionary d, User u)
        {
            XDocument doc;
            List<Word> WordList = new List<Word>();
            int i;
            bool b;
            int? test_count;
            int? attempts;
            bool knowing;

            if (d != null)
            {
                doc = XMLUtils.getXmlDocument(d.path);
                IEnumerable<XElement> elWord = from a in
                                                   (from w in doc.Descendants("Dictionary")
                                                    where long.Parse(w.Attribute("id").Value) == d.id
                                                    select w).Descendants("Word")
                                               orderby a.Element("Source").Value
                                               select a;

                IEnumerable<XElement> elUWs;
                XElement elUW;
                foreach (XElement w in elWord)
                {
                    try
                    {
                        elUWs = w.Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id);
                        if (elUWs.Count() > 0)
                        {
                            elUW = elUWs.Single();
                            if ((elUW.Element("Test_count") != null) && int.TryParse(elUW.Element("Test_count").Value, out i))
                                test_count = i;
                            else
                                test_count = null;
                            if ((elUW.Element("Attempts") != null) && int.TryParse(elUW.Element("Attempts").Value, out i))
                                attempts = i;
                            else
                                attempts = null;
                            if ((elUW.Element("Knowing") != null) && bool.TryParse(elUW.Element("Knowing").Value, out b))
                                knowing = b;
                            else
                                knowing = false;
                        }
                        else
                        {
                            test_count = null;
                            attempts = null;
                            knowing = false;
                        }
                        WordList.Add(new Word(w.Element("Source").Value, w.Element("Translate").Value) { test_count = test_count, attempts = attempts, knowing = knowing });
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message + " / " + w.Element("Source").Value);
                    }
                }
            }
            return WordList;
        }

        public static void addDictionary(this XDocument doc, User u, MyDictionary d)
        {
            long id = Convert.ToInt64(DateTime.Now.ToString("ddMMyyhhmmss"));

            //doc.c
            XElement element = (from el in doc.Descendants("Dictionary")
                                select el).Single();
            element.SetAttributeValue("id", id);
            element.SetAttributeValue("name", d.name);
            element.SetAttributeValue("id_user", u.id);
            element.SetAttributeValue("opened", false);
        }

        public static void updDictionary(this XDocument doc, MyDictionary d)
        {
            IEnumerable<XElement> elDictionary =
               from el in doc.Descendants("Dictionary")
               where int.Parse(el.Attribute("id").Value) == d.id
               select el;

            elDictionary.Single().Attribute("name").Value = d.name;
        }

        public static void delDictionary(this XDocument doc, User u, MyDictionary d)
        {
            IEnumerable<XElement> elDictionary = 
                from uel in
                    (from el in doc.Descendants("Dictionary")
                     where int.Parse(el.Attribute("id").Value) == d.id &&
                     el.Attribute("opened").Value == "true"
                     select el).Descendants("User")
                where int.Parse(uel.Attribute("id_user").Value) == u.id
                select uel;

            elDictionary.Remove();
        }

        //  ----    Begin Words layer  ----  //
        public static bool checkWordUserDictUniq(this XDocument doc, MyDictionary d, Word w)
        {
            int WordsCount = (from el in doc.Descendants("Word")
                              //проверяем слово на уникальность только в рамках конкретного словаря
                              where string.Compare(el.Element("Source").Value.Trim(), w.source.Trim(), true) == 0
                              select el).Count();
   
            if (WordsCount > 0)
            {
                //MessageBox.Show("Слово уже присутствует в словаре");
                //throw new DuplicateWaitObjectException();
                return false;
            }
            return true;
        }

        public static void addWord(this XDocument doc, MyDictionary d, Word w)
        {
            if (!doc.checkWordUserDictUniq(d, w))
            {
                MessageBox.Show("Слово не может быть добавлено, т.к. уже присутствует в словаре пользователя!");
                return;
            }

            XElement Element = new XElement("Word",
                new XElement("Source", new XCData(w.source)),
                new XElement("Translate",new XCData(w.translate)));
 
            doc.Descendants("Dictionary")
                .Where(dict => long.Parse(dict.Attribute("id").Value) == d.id).Single().Add(Element);
            d.RefreshWordList();
        }


        public static void updWord(this XDocument doc, MyDictionary d, User u, Word fromWord, Word toWord)
        {
            if ((fromWord.source != toWord.source) && !doc.checkWordUserDictUniq(d, toWord))
            {
                //MessageBox.Show("Слово не может быть изменено, т.к. уже присутствует в словаре пользователя!");
                throw new DuplicateWaitObjectException(toWord.source,"Слово не может быть изменено, т.к. уже присутствует в словаре пользователя!");
                //return;
            }

            XElement elWord =
                (from word in
                    (from el in doc.Descendants("Dictionary")
                     where long.Parse(el.Attribute("id").Value) == d.id
                     select el).Descendants("Word")
                        .Where(x => string.Compare(
                        x.Element("Source").Value.ToString().Trim(), fromWord.source.Trim(), true) == 0)
                 select word).Single();

            elWord.Element("Source").Value = toWord.source;
            elWord.getExistsOrCreateNewChild("Translate").Value = toWord.translate;

            int unodes = elWord.Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id).Count();

            if (unodes == 0)
                elWord.Add(new XElement("User", new XAttribute("id_user", u.id)));

            XElement elWordUser = elWord.Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id).Single();
            elWordUser.getExistsOrCreateNewChild("Knowing").Value = toWord.knowing.ToString();
            
            //elWord.getExistsOrCreateNewChild("Test_count").Value = toWord.test_count.ToString();
            //elWord.getExistsOrCreateNewChild("Attempts").Value = toWord.attempts.ToString();
            d.RefreshWordList();
        }

        public static void delWord(this XDocument doc, MyDictionary d, Word w)
        {
            IEnumerable<XElement> elWord =
               from dict in doc.Descendants("Dictionary")
               where long.Parse(dict.Attribute("id").Value) == d.id
               from word in dict.Descendants("Word")
               where string.Compare(word.Element("Source").Value.Trim(), w.source.Trim(), true) == 0
               select word;

            elWord.Single().Remove();
            d.RefreshWordList();
        }

        public static void incTest_count(this XDocument doc, User u, MyDictionary d, Word editWord)
        {
            XElement elWord =
                (from word in
                     (from el in doc.Descendants("Dictionary")
                      where long.Parse(el.Attribute("id").Value) == d.id
                      select el).Descendants("Word")
                         .Where(x => string.Compare(
                         x.Element("Source").Value.ToString().Trim(), editWord.source.Trim(), true) == 0)
                 select word).Single();

            int i = 0;
            if (elWord.Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id).Count() == 0)
            {
                XElement Element = new XElement("User", new XAttribute("id_user", u.id));
                elWord.Add(Element);
            }
            elWord = elWord.Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id).Single();

            int.TryParse(elWord.getExistsOrCreateNewChild("Test_count").Value, out i);
            elWord.getExistsOrCreateNewChild("Test_count").Value = (++i).ToString();
            d.RefreshWordList();
        }

        public static void incAttempts(this XDocument doc, User u, MyDictionary d, Word editWord)
        {
            XElement elWord = 
                (from el in doc.Descendants("Dictionary")
                 where long.Parse(el.Attribute("id").Value) == d.id
                 select el).Descendants("Word")
                    .Where(x => string.Compare(x.Element("Source").Value.ToString().Trim(), editWord.source.Trim(), true) == 0)
                    .Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id).Single();               

            int i = 0;
            int.TryParse(elWord.getExistsOrCreateNewChild("Attempts").Value, out i);
            elWord.getExistsOrCreateNewChild("Attempts").Value = (++i).ToString();
            d.RefreshWordList();
        }
        //  ----    End Words layer ----     //

        public static int GetHitWordsCount(this XDocument doc, User u, MyDictionary d)
        {
            IEnumerable<XElement> el_s= (from el in doc.Descendants("Dictionary")
                           where long.Parse(el.Attribute("id").Value) == d.id
                           select el).Descendants("Word").Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id).
                           Descendants("Test_count");
            int i;
            int c = el_s.Where(x => int.TryParse(x.Value, out i)).Where(x => int.Parse(x.Value) > 0).Count();
  
            return c;
        }

        public static int GetLessThen_N_TestCount(this XDocument doc, User u, MyDictionary d)
        {
            int i;
            int c = (from el in doc.Descendants("Dictionary")
                     where long.Parse(el.Attribute("id").Value) == d.id
                     select el).Descendants("Word").Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id)
                .Where(x => (x.Element("Test_count")!=null) && int.TryParse(x.Element("Test_count").Value, out i) &&
                    (x.Element("Knowing") == null || !bool.Parse(x.Element("Knowing").Value))
                    )
                .Where(x => int.Parse(x.Element("Test_count").Value) < 2).Count();

            return c;
        }

        public static int GetLessThen_K_HitCount(this XDocument doc, User u, MyDictionary d)
        {
            int i;
            int c = (from el in doc.Descendants("Dictionary")
                     where long.Parse(el.Attribute("id").Value) == d.id
                     select el).Descendants("Word").Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id)
                .Where(x => (x.Element("Test_count") != null) && (x.Element("Attempts") != null) && int.TryParse(x.Element("Test_count").Value, out i) && int.TryParse(x.Element("Attempts").Value, out i) &&
                    (x.Element("Knowing") == null || !bool.Parse(x.Element("Knowing").Value))
                    )
                .Where(x => ((float.Parse(x.Element("Test_count").Value) + (int)(float.Parse(x.Element("Test_count").Value) / 6)) / float.Parse(x.Element("Attempts").Value)) <= 0.5).Count();

            return c;
        }


        public static int GetKnowingWordsCount(this XDocument doc, User u, MyDictionary d)
        {
            int i;
            int c = (from el in doc.Descendants("Dictionary")
                     where long.Parse(el.Attribute("id").Value) == d.id
                     select el).Descendants("Word").Descendants("User").Where(x => int.Parse(x.Attribute("id_user").Value) == u.id)
                .Where(x =>
                    (x.Element("Knowing") != null && bool.Parse(x.Element("Knowing").Value)) ||
                    ((x.Element("Test_count") != null) && (x.Element("Attempts") != null) && int.TryParse(x.Element("Test_count").Value, out i) && int.TryParse(x.Element("Attempts").Value, out i) &&
                    ((float.Parse(x.Element("Test_count").Value)+(int)(float.Parse(x.Element("Test_count").Value)/6)) / float.Parse(x.Element("Attempts").Value)) > 0.5 &&
                    int.Parse(x.Element("Test_count").Value) >= 2)
                    ).Count();

            return c;
        }
    }
}
