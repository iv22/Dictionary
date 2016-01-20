using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using System.Runtime.Serialization.Json;

namespace Dictionary
{
    public class User
    {
        //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));

        public int id { get; private set; }
        public string name { get; set; }
        public DateTime reg_date { get; private set; }

        internal delegate List<MyDictionary> MyDictionaryDelegate(User u);
        private MyDictionaryDelegate MyDictionaryGetter;
        public List<MyDictionary> dictionaryList { get { return MyDictionaryGetter(this); } }

        internal User(int id, string name, DateTime reg_date, MyDictionaryDelegate dictionaryDelegate)
        {
            this.id = id;
            this.name = name;
            this.reg_date = reg_date;
            this.MyDictionaryGetter = dictionaryDelegate;
        }  
        public User(string name)
        {
            this.name = name;
            this.reg_date = DateTime.Now;
        }

        public override string ToString()
        {
            return this.name + " - " + this.reg_date.ToShortDateString();
        }
    }
}
