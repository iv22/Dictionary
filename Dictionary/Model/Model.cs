using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace Dictionary
{
    public class Model : IObservable<List<User>>
    {
        private List<IObserver<List<User>>> UserObservers = new List<IObserver<List<User>>>();
        private List<IObserver<List<MyDictionary>>> DictObservers = new List<IObserver<List<MyDictionary>>>();

        private string path;
        private XDocument Doc;
        private string dirDict;
        private XDocument DocDict;

        public User CurrentUser { get; private set; }
        public MyDictionary CurrentDictionary { get; private set; }
        public Test CurrentTest { get; private set; }

        public Model()
        {
            this.path = Application.StartupPath + @"\base\settings.xml";
            this.Doc = XMLUtils.getXmlDocument(path);
            this.dirDict = Application.StartupPath + @"\base";
        }

        public IDisposable Subscribe(IObserver<List<User>> observer)
        {
            if (!UserObservers.Contains(observer))
                UserObservers.Add(observer);
            return new Unsubscriber<IObserver<List<User>>>(UserObservers, observer);
        }

        private class Unsubscriber <Observer> : IDisposable
        {
            private List<Observer> _observers;
            private Observer _observer;

            public Unsubscriber(List<Observer> observers, Observer observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        public IDisposable Subscribe(IObserver<List<MyDictionary>> observer)
        {
            if (!DictObservers.Contains(observer))
                DictObservers.Add(observer);
            return new Unsubscriber<IObserver<List<MyDictionary>>>(DictObservers, observer);
        }


        public void SetUser(User u)
        {
            this.CurrentUser = u;
        }

        public void SetDictionary(MyDictionary d)
        {
            this.CurrentDictionary = d;
            if(d != null)
                this.DocDict = XMLUtils.getXmlDocument(d.path);
        }

        public List<User> getUsers()
        {
            return Doc.getAllUsers(this.dirDict);
        }

        public void addUser(User u)
        {
            try
            {
                Doc.addUser(u);
                Doc.applyChanges(path);
                ChangeUserModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updUser(User u)
        {
            try
            {
                Doc.updUser(u);
                Doc.applyChanges(path);
                ChangeUserModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void delUser(User u)
        {
            try
            {
                foreach (MyDictionary d in u.dictionaryList)
                {       
                    this.delDictionary(d);
                }
                Doc.delUser(u);
                Doc.applyChanges(path);
                ChangeUserModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ChangeUserModel()
        {
            foreach (var observer in UserObservers)
            {
                observer.OnNext(getUsers());
            }
        }

        private void ChangeDictionaryModel()
        {
            foreach (var observer in DictObservers)
            {
                observer.OnNext(CurrentUser.dictionaryList);
            }
        }

        public void addDictionary(MyDictionary d)
        {
            try
            {
                string fname = this.dirDict + @"\dict_" + this.CurrentUser.id + "_" + DateTime.Now.ToString("ddMMyy_hmmss") + ".xml";
                XDocument xdoc = XMLUtils.getNewXmlDocument(fname);
                xdoc.addDictionary(CurrentUser,d);
                xdoc.applyChanges(fname);
                ChangeDictionaryModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updDictionary(MyDictionary d)
        {
            try
            {
                DocDict.updDictionary(d);
                DocDict.applyChanges(d.path);
                ChangeDictionaryModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void delDictionary(MyDictionary d)
        {
            try
            {
                if (!d.opened)
                    File.Delete(d.path);
                else
                {
                    XDocument xdoc = XMLUtils.getXmlDocument(d.path);
                    xdoc.delDictionary(this.CurrentUser, d);
                    xdoc.applyChanges(d.path);
                }
                
                ChangeDictionaryModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void addWord(Word w)
        {
            try
            {
                DocDict.addWord(CurrentDictionary, w);
                DocDict.applyChanges(CurrentDictionary.path);
                //ChangeDictionaryModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void updWord(Word fromWord, Word toWord)
        {
            try
            {
                DocDict.updWord(CurrentDictionary, this.CurrentUser, fromWord, toWord);
                DocDict.applyChanges(CurrentDictionary.path);
                //ChangeDictionaryModel();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                throw;
            }
        }

        public void delWord(Word w)
        {
            try
            {
                DocDict.delWord(CurrentDictionary, w);
                DocDict.applyChanges(CurrentDictionary.path);
                //ChangeDictionaryModel();
            } 
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void CreateTest(MyDictionary dictionary, TestTimings timing, TestPriorities priority, int WordCount, bool IsPreview)
        {
            CurrentTest = new Test(dictionary, timing, priority, WordCount);
            if (IsPreview)
                CurrentTest.AddTestPart(new PreviewPart());
            CurrentTest.AddTestPart(new CouplePart());
            CurrentTest.AddTestPart(new SpellPart());
        }

        public void SaveTestResult()
        {
            foreach (Word w in this.CurrentTest.selectedWords)
            {
                this.DocDict.incTest_count(this.CurrentUser, this.CurrentDictionary, w);
                this.DocDict.incAttempts(this.CurrentUser, this.CurrentDictionary, w);
            }

            foreach (Word w in this.CurrentTest.wrongWords)
            {
                this.DocDict.incAttempts(this.CurrentUser, this.CurrentDictionary, w);
            }

            this.DocDict.applyChanges(CurrentDictionary.path);
        }

        public void MarkWordAsKnowing()
        {
            foreach (Word w in this.CurrentTest.selectedWords)
            {
                this.DocDict.incTest_count(this.CurrentUser, this.CurrentDictionary, w);
                this.DocDict.incAttempts(this.CurrentUser, this.CurrentDictionary, w);
            }

            foreach (Word w in this.CurrentTest.wrongWords)
            {
                this.DocDict.incAttempts(this.CurrentUser, this.CurrentDictionary, w);
            }

            this.DocDict.applyChanges(CurrentDictionary.path);
        }

        public int GetHitWordsCount()
        {
            return DocDict.GetHitWordsCount(this.CurrentUser, this.CurrentDictionary);
        }

        public int GetKnowingWordsCount()
        {
            return DocDict.GetKnowingWordsCount(this.CurrentUser, this.CurrentDictionary);
        }

        public int GetLessThen_N_TestCount()
        {
            return DocDict.GetLessThen_N_TestCount(this.CurrentUser, this.CurrentDictionary);
        }

        public int GetLessThen_K_HitCount()
        {
            return DocDict.GetLessThen_K_HitCount(this.CurrentUser, this.CurrentDictionary);
        }
    }
}
