using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class View : Form, IObserver<List<User>>, IObserver<List<MyDictionary>>
    {
        private Model model;
        private Controller_View controller;
        private Controller_DictionaryWord controller_word;
        private IDisposable UserSubscriber;
        private IDisposable DictSubscriber;
        private int bookmarked_user_id = -1;

        public bool CanEditUser { set { this.linkEditUser.Enabled = value; } }
        public bool CanAddUser { set { this.linkAddUser.Enabled = value; } }
        public bool CanDelUser { set { this.linkDelUser.Enabled = value; } }

        public List<MyDictionary> UserDictionaries { set { this.cbDictionary_fillItems(value); } }
        public bool CanEditDictionary { set { this.linkEditDictionary.Enabled = value; } }
        public bool CanAddDictionary { set { this.linkAddDictionary.Enabled = value; } }
        public bool CanDelDictionary { set { this.linkDelDictionary.Enabled = value; } }
        public int? DictionaryWordsCount { set { this.txtDictWordsCount.Text = value.ToString(); } }

        public Form ViewChartDict { 
            set 
            { 
                value.Parent = this.gboxChartDict;
                value.Left = 2;
                value.Top = 14;
                value.Width = this.gboxChartDict.Width-4;
                value.Height = this.gboxChartDict.Height-16;
                //value.Anchor = (AnchorStyles.Right | AnchorStyles.Left);
            } 
        }

        public bool CanTesting { set { this.gboxTestSets.Enabled = value; this.btnTest.Enabled = value; } }
        public int TestWordsCount { get { return (int)this.updownTest.Value; } }
        public bool TestIsPreview { get { return this.chboxTestPreview.Checked; } }
        public TestTimings TestTiming
        {
            get
            {
                if (this.radiobtnLong.Checked)
                    return TestTimings.Long;
                else if (this.radiobtnShort.Checked)
                    return TestTimings.Short;
                else
                    return TestTimings.Middle;
            }
        }

        public TestPriorities TestPriority
        {
            get
            {
                if (this.radiobtnNew.Checked)
                    return TestPriorities.NewWords;
                else if (this.radiobtnWrong.Checked)
                    return TestPriorities.WrongWords;
                else if (this.radiobtnSeldom.Checked)
                    return TestPriorities.SeldomWords;
                else 
                    return TestPriorities.Balanced;
            }
        }

        public View(Model model)
        {
            this.model = model;
            InitializeComponent();
            UserSubscriber = model.Subscribe((IObserver<List<User>>)this);
            DictSubscriber = model.Subscribe((IObserver<List<MyDictionary>>)this);
            //cbUser_fillItems(controller.getUsers());
        }

        public void SetController(Controller_View controller)
        {
            this.controller = controller;
        }

        public void SetController_DictionaryWord(Controller_DictionaryWord controller_dw)
        {
            this.controller_word = controller_dw;
        }

        public void Init()
        {
            //GUI events
            cbUser_fillItems(controller.getUsers());
        }

        private void cbUser_fillItems(List<User> items)
        {
            //this.cbUsers.Text = "";
            this.cbUsers.DataSource = items;
            this.cbUsers.SelectedItem = null;
            //this.cbUsers.DisplayMember = "name";
            //this.cbUsers.ValueMember = "id";
            //this.cbUsers.SelectedIndex = -1;
        }

        private void cbDictionary_fillItems(List<MyDictionary> items)
        {
            //this.cbDictionary.Text = "";
            this.cbDictionary.DataSource = items;
            this.cbDictionary.DisplayMember = "name";
            this.cbDictionary.SelectedItem = null;
            //this.cbDictionary.ValueMember = "id";
            //this.cbDictionary.SelectedIndex = -1;
        }

        public virtual void OnCompleted()
        {
        }

        public virtual void OnError(Exception e)
        {
        }

        public virtual void OnNext(List<User> users)
        {
            MessageBox.Show("Users list was changed!");
            cbUser_fillItems(users);
        }


        public virtual void OnNext(List<MyDictionary> dicts)
        {
            MessageBox.Show("Dictionaries list was changed!");
            cbDictionary_fillItems(dicts);
        }

        public void fill_DictionaryGrid(List<Word> words)
        {
            double? d = null;
            gridDictionary.Rows.Clear();
            if (words!=null)
                foreach (Word w in words)
                {
                    if (w.test_count != null && w.attempts != null)
                        d = Math.Round((double)(w.test_count+(int)(w.test_count/6)) / (double)w.attempts, 2);
                    else
                        d = null;
                    gridDictionary.Rows.Add(w.source, w.translate, w.test_count, w.attempts, d, w.knowing);
                }
        }

        public void BookmarkSelectedUser()
        {
            if (cbUsers.SelectedItem is User)
                bookmarked_user_id = (cbUsers.SelectedItem as User).id;
        }

        public void RestoreBookmarkedUser()
        {
            if (bookmarked_user_id > 0) 
                foreach(var v in cbUsers.Items)
                {
                    if ((v as User).id == bookmarked_user_id)
                    {
                        cbUsers.SelectedItem = v;
                        break;
                    }
                }
        }

        private void cbUsers_SelectedValueChanged(object sender, EventArgs e)
        {
            User user = ((ComboBox)sender).SelectedItem as User;
            controller.SelectedUserChange(user);
        }

        private void cbDictionary_SelectedValueChanged(object sender, EventArgs e)
        {
            MyDictionary dict = ((ComboBox)sender).SelectedItem as MyDictionary;
            controller.SelectedDictionaryChange(dict);
        }

        #region DictionaryWords 
        public bool CanEditDictionaryView { set { this.panelDictionary.Enabled = value; } }
        public bool CanAddDictionaryWord { set { this.btnAdd.Enabled = value; } }
        public bool CanUpdDictionaryWord { set { this.btnUpd.Enabled = value; } }
        public bool CanDelDictionaryWord { set { this.btnDel.Enabled = value; } }
        public bool CanEditCurrentWord { set { this.btnEdit.Enabled = value; } }
        public bool CanCancelEditWord { set { this.btnCancel.Enabled = value; } }
        public bool CanEditWordTranslate { 
            set 
            { 
                this.txtTranslate.ReadOnly = !value;
                this.chBoxKnowing.Enabled = value;   
            } 
        }
        public string CurrentWordOperTitle { set { this.gBoxWord.Text = value; } }

        public string source
        {
            get { return txtSource.Text; }
            set { txtSource.Text = value; }
        }

        public string translate
        {
            get { return txtTranslate.Text; }
            set { txtTranslate.Text = value; }
        }

        public int? test_count { get; set; }
        public int? attempts { get; set; }
        
        public bool knowing
        {
            get { return this.chBoxKnowing.Checked; }
            set { this.chBoxKnowing.Checked = value; }
        }

        public void TrySetWordPosition(string source, bool isExactly=false)
        {
            string curValue; 
            Func<string,string,bool,bool> comparer;
            comparer = (_curValue,_source,_isExactly) => {
                if (_source.Length < 1)
                    return true;
                else if (!_isExactly)
                    return (string.Compare(_curValue.Trim(), 0, _source.Trim(), 0, _source.Length, true) == 0);
                else
                    return (string.Compare(_curValue.Trim(), _source.Trim(), true) == 0);
            };

            if (this.gridDictionary.CurrentRow != null)
            {
                curValue = gridDictionary.CurrentRow.Cells["Source"].Value.ToString();
                if (comparer(curValue, source, isExactly))
                    return;
            }

            foreach (DataGridViewRow row in this.gridDictionary.Rows)
            {
                curValue = row.Cells["Source"].Value.ToString();

                if (comparer(curValue,source,isExactly))
                {
                    gridDictionary.CurrentCell = gridDictionary["Source",row.Index];
                    gridDictionary.FirstDisplayedCell = gridDictionary.CurrentCell;
                    return;
                }
            }
        }

        private void txtSource_TextChanged(object sender, EventArgs e)
        {
            controller_word.SelectedWordChanged(source);
        }

        private void gridDictionary_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (this.gridDictionary.CurrentRow != null)
                this.controller_word.SelectedWordChanged(this.gridDictionary.CurrentRow.Cells["Source"].Value.ToString());

            //if (this.gridDictionary.SelectedRows.Count > 0)
              //  this.controller.SelectedWordChanged(this.gridDictionary.SelectedRows[0].Cells[0].Value.ToString());
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            controller_word.AddDictionaryWord();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить слово из словаря?",
                "Подтверждение операции", MessageBoxButtons.YesNo) == DialogResult.Yes)
            controller_word.DelDictionaryWord();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            controller_word.EditDictionaryWord();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            controller_word.CancelEditDictionaryWord();
        }

        private void btnUpd_Click(object sender, EventArgs e)
        {
            controller_word.UpdateDictionaryWord();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            controller.CreateTest();
        }

        private void linkEditUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controller.EditUser();
        }

        private void linkAddUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controller.AddUser();
        }

        private void linkDelUser_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controller.DelUser();
        }

        private void linkEditDictionary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controller.EditDictionary();
        }

        private void linkAddDictionary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controller.AddDictionary();
        }

        private void linkDelDictionary_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controller.DelDictionary();
        }

        private void tabDictionary_Enter(object sender, EventArgs e)
        {
            controller_word.DictionaryEnter();
        }

        private void tabStatistics_Enter(object sender, EventArgs e)
        {
            controller.ShowStatistics();
        }
    }
}
