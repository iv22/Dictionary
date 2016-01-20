using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Timers;
using System.Runtime.Serialization;

namespace Dictionary
{
    public enum TestTimings { Long = 12000, Middle = 9900, Short = 7000 }
    public enum TestPriorities { NewWords, WrongWords, Balanced, SeldomWords}
    public enum TestStates { Ready, Working, Expired, Cancelled, Completed }

    public delegate void AddWrongWordDelegate(Word w);
    public delegate void ChangeTestStateDelegate(TestStates s);
    
    public class Test: INotifyPropertyChanged 
    {
        private List<ATestPart> _testParts = new List<ATestPart>();
        private int _curPart;
        private MyDictionary _dictionary;
        private TestTimings timing;
        private TestPriorities priority;
        //private TestStates state;
        private int wordCount;

        public List<Word> selectedWords { get; private set; }
        public List<Word> wrongWords { get; private set; }
        public ATestPart CurrentPart { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private TestStates state;
        public TestStates State
        {
            get { return state; }
            private set
            {
                if (value != this.state)
                {
                    this.state = value;
                    NotifyPropertyChanged("State");
                }
            }
        }

        public Test(MyDictionary dictionary, TestTimings timing, TestPriorities priority, int WordCount)
        {
            this._dictionary = dictionary;
            this.timing = timing;
            this.priority = priority;
            this.wordCount = WordCount;
            this.selectedWords = new List<Word>();
            this.wrongWords = new List<Word>();
            this.CurrentPart = null;
        }

        public void AddTestPart(ATestPart part)
        {
            this._testParts.Add(part);
        }

        public void Cancel()
        {
            if (this.CurrentPart != null)
                this.CurrentPart.Cancel();
            this.State = TestStates.Cancelled;
        }

        private void Reset()
        {
            _curPart = -1;
            state = TestStates.Ready;
            wrongWords = new List<Word>();
            selectedWords = getTestWords(_dictionary);
        }

        private List<Word> getTestWords(MyDictionary dict)
        {
            Random rnd = new Random();
            List<Word> resultWords;

            int newCount = 0;

            Func<int?, int?, int> OrderFunc = delegate(int? tcount, int? att)
            {
                int range1 = 0;
                int range2 = 0;
                
                if (tcount == null) tcount = 0;
                if ((att == null) || (tcount == 0)) att = 0;
                if (att < tcount) att = tcount;

                switch (priority)
                {
                    case TestPriorities.NewWords:
                        if (tcount == 0)
                        {
                            range1 = 1;
                            range2 = wordCount;
                        }
                        else
                        {
                            range1 = wordCount + (int)(wordCount * tcount / att);
                            range2 = wordCount * 2 + (int)(wordCount * tcount / att);
                        }
                        break;

                    case TestPriorities.WrongWords:
                        if ((tcount > 0) && (tcount < att))
                        {
                            range1 = 1 + (int)(wordCount * (tcount / 5) * tcount / att);
                            range2 = 2 * (1 + (int)(wordCount * (tcount / 5) * tcount / att));
                        }
                        else if (tcount == 0)
                        {
                            range1 = 3 + 2 * wordCount;
                            range2 = 4 + 4 * wordCount;
                        }
                        else
                        {
                            range1 = 5 + 4 * wordCount + (int)att;
                            range2 = 9 + 4 * wordCount + (int)att;
                        }
                        break;

                    case TestPriorities.Balanced:
                        if ((tcount > 0) && (tcount < att))
                        {                           
                            range1 = 1001 + (int)(100 * tcount / att);
                            range2 = 1050 + (int)(100 * tcount / att);
                        }
                        else if (tcount == 0)
                        {
                            if ((newCount + 1) < (2 * wordCount / 3))
                            {
                                newCount++;
                                range1 = 1;
                                range2 = 1000;
                            }
                            else
                            {
                                range1 = 1111;
                                range2 = 1150;
                            }
                        }
                        else
                        {
                            range1 = 1081 + 5 * (int)tcount;
                            range2 = 1081 + 10 * (int)tcount;
                        }
                        break;

                    case TestPriorities.SeldomWords:
                        if (att == 0)
                        {
                            range1 = 0;
                            range2 = 0;
                        }
                        else
                        {
                            range1 = (int)tcount;
                            range2 = (int)tcount + (int)(tcount * 10 / att);
                        }
                        break;
                }
                return rnd.Next(range1,range2);
            };

            resultWords = (from l in dict.wordList
                           where l.knowing != true
                           orderby OrderFunc(l.test_count, l.attempts), l.GetHashCode() //rnd.Next(40)
                           select l).Take(wordCount).ToList();

            return resultWords;
        }

        private void addWrongWord(Word w)
        {
            wrongWords.Add(w);
        }

        private void changeState(TestStates state)
        {
            this.State = state;
        }

        public IEnumerable<ATestPart> TestParts()
        {
            Reset();
            while (((_curPart + 1) < _testParts.Count) && (this.selectedWords.Count > 0) &&
                ((this.state == TestStates.Ready) || (this.state == TestStates.Completed))) 
            {
                _curPart++;
                this.CurrentPart = _testParts[_curPart];
                this.CurrentPart.Reset(this.selectedWords, this.wrongWords, this.addWrongWord, changeState, timing);

                yield return this.CurrentPart;
            }
        }

        public static List<Word> GetShuffleWords(List<Word> w)
        {
            Random rnd = new Random();
            List<Word> result = (from l in w
                                 orderby rnd.Next(40)
                                 select l).ToList();
            return result;
        }
    }

    public abstract class ATestPart
    {
        protected Test _test;
        protected List<Word> _selectedWords;
        protected List<Word> _uncheckedWords;
        protected int curIndex;
        protected Word curWord;
        protected AddWrongWordDelegate addWrongWordHandler;
        protected ChangeTestStateDelegate changeTestStateHandler;

        public abstract void SetTimer(Timer t);

        public virtual bool CheckWord(Word w)
        {
            int i = 0;
            int find_index = -1;
            bool result = false;
            Word find_word;

            while ((i < this._uncheckedWords.Count) && (!result))
            {
                find_word = this._uncheckedWords[i];
                if (find_word.Equals(w))
                {
                    result = true;
                    this._uncheckedWords.RemoveAt(i);
                }
                else
                {
                    if (find_word.source.Equals(w.source))
                        find_index = i;
                    i++;
                }
            }

            if ((!result) && (find_index >= 0))
            {
                this.AddWrongWord(_uncheckedWords[find_index]);
            }

            if (this._uncheckedWords.Count == 0)
                this.changeTestStateHandler(TestStates.Completed);

            return result;
        }

        public virtual void Reset(List<Word> selectedWords, List<Word> wrongWords, AddWrongWordDelegate wrongProcDelegate, ChangeTestStateDelegate changeStateDelegate, TestTimings timing)
        {
            this._selectedWords = new List<Word>(selectedWords);
            this.addWrongWordHandler = wrongProcDelegate;
            this.changeTestStateHandler = changeStateDelegate;
            this.changeTestStateHandler(TestStates.Working);
        }

        protected abstract void AddWrongWord(Word w);
        public abstract IEnumerable<Word> PartWords();
        public abstract void Cancel();

        /*public ATestPart(List<Word> selectedWords, List<Word> wrongWords)
        {
            _selectedWords = selectedWords;
            _wrongWords = wrongWords;
        }*/
    }

    class PreviewPart : ATestPart
    {
        //public CouplePart(List<Word> selectedWords, List<Word> wrongWords) : base(selectedWords, wrongWords) { }

        public override void SetTimer(Timer t){}

        protected override void AddWrongWord(Word w) { }

        public override void Reset(List<Word> selectedWords, List<Word> wrongWords, AddWrongWordDelegate wrongProcDelegate, ChangeTestStateDelegate changeStateDelegate, TestTimings timing)
        {
            this._selectedWords = new List<Word>(selectedWords);
            this.changeTestStateHandler = changeStateDelegate;
            this.changeTestStateHandler(TestStates.Ready);
        }

        public override IEnumerable<Word> PartWords()
        {
            this.changeTestStateHandler(TestStates.Working);
            foreach(Word w in this._selectedWords)
              yield return w;
            this.changeTestStateHandler(TestStates.Completed); 
        }

        public override bool CheckWord(Word w) { return true; }
        
        public override void Cancel() 
        {
            this.changeTestStateHandler(TestStates.Cancelled); 
        }
    }

    class CouplePart : ATestPart
    {
        TestTimings timing;

        public override void SetTimer(Timer t) 
        {
            t.Interval = ((int)timing) * (this._selectedWords.Count);
            t.Elapsed += delegate { Expire(); };
            t.AutoReset = false;
        }

        protected override void AddWrongWord(Word w) 
        {
            this.addWrongWordHandler(w);
        }

        public override void Reset(List<Word> selectedWords, List<Word> wrongWords, AddWrongWordDelegate wrongProcDelegate, ChangeTestStateDelegate changeStateDelegate, TestTimings timing)
        {
            this._selectedWords = new List<Word>(Test.GetShuffleWords(selectedWords));
            this._uncheckedWords = new List<Word>(this._selectedWords);
            this.addWrongWordHandler = wrongProcDelegate;
            this.timing = timing;
            this.changeTestStateHandler = changeStateDelegate;
            this.changeTestStateHandler(TestStates.Ready);
        }

        public override IEnumerable<Word> PartWords()
        {
            foreach (Word w in this._selectedWords)
                yield return w;
            this.changeTestStateHandler(TestStates.Working);
        }

        private void Expire()
        {
            this.changeTestStateHandler(TestStates.Expired);
        }

        public override void Cancel()
        {
            this.changeTestStateHandler(TestStates.Cancelled);
        }
    }

    class SpellPart : ATestPart
    {
        TestTimings timing;

        public override void SetTimer(Timer t)
        {
            t.Interval = ((int)timing);
            t.Elapsed += delegate { Expire(); };
            t.AutoReset = false;
        }

        protected override void AddWrongWord(Word w)
        {
            this.addWrongWordHandler(w);
            this._uncheckedWords.Add(w);
            this._uncheckedWords = Test.GetShuffleWords(this._uncheckedWords);
        }

        public override void Reset(List<Word> selectedWords, List<Word> wrongWords, AddWrongWordDelegate wrongProcDelegate, ChangeTestStateDelegate changeStateDelegate, TestTimings timing)
        {
            this._selectedWords = new List<Word>(selectedWords);
            this._selectedWords.AddRange(wrongWords);
            this._selectedWords = Test.GetShuffleWords(this._selectedWords);
            this._uncheckedWords = new List<Word>(this._selectedWords);
            this.addWrongWordHandler = wrongProcDelegate;
            this.timing = timing;
            this.changeTestStateHandler = changeStateDelegate;
            this.changeTestStateHandler(TestStates.Ready);
        }

        public override IEnumerable<Word> PartWords()
        {
            while (this._uncheckedWords.Count > 0)
            {
                this.changeTestStateHandler(TestStates.Working);
                yield return this._uncheckedWords[0];
            }
        }

        private void Expire()
        {
            this.changeTestStateHandler(TestStates.Expired);
        }

        public override void Cancel()
        {
            this.changeTestStateHandler(TestStates.Cancelled);
        }
    }
}
