using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public class Controller_View
    {
        internal Model model { get; private set; }
        private View view;
        private View_ChartDict view_chart = new View_ChartDict();

        public Controller_View(Model model, View view)
        {
            this.model = model;
            this.view = view;
            this.view.SetController(this);
            this.view.SetController_DictionaryWord(new Controller_DictionaryWord(model, view));
            this.view.Init();
            //this.view.cbUser_fillItems(getUsers());
            Application.Run(view);
        }

        public List<User> getUsers()
        {
            return model.getUsers();
        }

        public void SelectedUserChange(User user)
        {
            view.CanAddUser = true;
            view.CanAddDictionary = false;
            view.CanEditDictionary = false;
            view.CanDelDictionary = false;
            try
            {
                model.SetUser(user);
                this.DictionaryReset();
                if (model.CurrentUser != null)
                {
                    view.CanEditUser = true;
                    view.CanDelUser = true;
                    view.CanAddDictionary = true;
                    view.UserDictionaries = model.CurrentUser.dictionaryList;
                }
                else
                {
                    view.CanEditUser = false;
                    view.CanDelUser = false;
                    view.UserDictionaries = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DictionaryReset()
        {
            model.SetDictionary(null);
            view.CanEditDictionary = false;
            view.CanDelDictionary = false;
            view.CanTesting = false;
            view.DictionaryWordsCount = null;
        }

        public void SelectedDictionaryChange(MyDictionary dict)
        {
            model.SetDictionary(dict);
            if (model.CurrentDictionary != null)
            {
                view.CanEditDictionary = true;
                view.CanDelDictionary = true;
                if (dict.wordList.Count > 0)
                    view.CanTesting = true;
                else
                    view.CanTesting = false;
                view.DictionaryWordsCount = dict.wordList.Count;
            }
            else
            {
                this.DictionaryReset();
            }
        }

        public void EditUser()
        {
            view.BookmarkSelectedUser();
            new Controller_UserEdit(model, new View_UserEdit(), model.CurrentUser);
            view.RestoreBookmarkedUser();
        }

        public void AddUser()
        {
            new Controller_UserAdd(model, new View_UserEdit());
        }

        public void DelUser()
        {
            new Controller_UserDel(model, model.CurrentUser);
        }

        public void EditDictionary()
        {
            //view.BookmarkSelectedUser();
            new Controller_DictionaryEdit(model, model.CurrentDictionary);
            //view.RestoreBookmarkedUser();
        }

        public void AddDictionary()
        {
            new Controller_DictionaryAdd(model);
        }

        public void DelDictionary()
        {
            new Controller_DictionaryDel(model, model.CurrentDictionary);
        }

        public void CreateTest()
        {
            model.CreateTest(model.CurrentDictionary, view.TestTiming, view.TestPriority, view.TestWordsCount, view.TestIsPreview);
            view.Hide();
            foreach(ATestPart p in model.CurrentTest.TestParts())
            {
                if (p is PreviewPart)
                {
                    new Controller_Preview(this.model, new View_Preview());
                }
                else if (p is CouplePart)
                {
                    new Controller_Couple(this.model, new View_Preview());
                }
                else if (p is SpellPart)
                {
                    new Controller_Spell(this.model, new View_Spell());
                }
            }
            if (model.CurrentTest.State == TestStates.Completed)
                model.SaveTestResult();
            view.Show();
        }

        public void ShowStatistics()
        {
            if (model.CurrentDictionary == null)
            {
                view_chart.Hide();
                //view_chart.SetChart(0, 0, 0);
            }
            else
            {
                view_chart.SetChart(model.CurrentDictionary.wordList.Count(), model.GetHitWordsCount(), model.GetKnowingWordsCount(),
                    model.GetLessThen_N_TestCount(), model.GetLessThen_K_HitCount());
                view_chart.TopLevel = false;
                this.view.ViewChartDict = view_chart;
                view_chart.Show();
            }
        }
    }
}
