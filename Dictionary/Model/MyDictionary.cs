using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public class Word
    {
        public string source;
        public string translate;
        public int? test_count = null;
        public int? attempts = null;
        public bool knowing = false; 

        public Word(string source, string translate)
        {
            this.source = source;
            this.translate = translate;
            //this.test_count = test_count;
            //this.attempts = attempts;
        }

        public void CopyTo(Word w)
        {
            w.source = this.source;
            w.translate = this.translate;
            w.test_count = this.test_count;
            w.attempts = this.attempts;
            w.knowing = this.knowing;
        }

        public override bool Equals(object obj)
        {
            return ((Word)obj).source.Equals(this.source) && ((Word)obj).translate.Equals(this.translate);
        }

        public void SetKnowing(Word w, bool is_known)
        {
            w.knowing = is_known;
        }
    }

    public class MyDictionary
    {
        public long id{get; private set;}
        public string name;
        public string path;
        public bool opened;

        internal delegate List<Word> WordDelegate(MyDictionary d);
        private WordDelegate WordGetter;
        private List<Word> _wordList;
        public List<Word> wordList { 
            get { 
                if (_wordList == null) 
                    _wordList = WordGetter(this); 
                return _wordList; 
            } }

        internal MyDictionary(long id, string name, string path, bool opened, WordDelegate wordDelegate)
        {
            this.id = id;
            this.name = name;
            this.path = path;
            this.opened = opened;
            this.WordGetter = wordDelegate;
        }

        public MyDictionary(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return this.name;
        }

        public void RefreshWordList()
        {
            _wordList = null;
        }

        public Word FindWordBySource(string search)
        {
            //wordList
            return  wordList.Find(x => string.Compare(x.source.Trim(),search.Trim(),true) == 0);
        }
    }
}
