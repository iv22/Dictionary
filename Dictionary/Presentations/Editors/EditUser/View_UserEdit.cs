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
    //Pattern Singleton for create unique instance of Form
    public partial class View_UserEdit : Form
    {
        private AbstractOperationController controller;
        public string user_name
        {
            get { return this.txtUser.Text; }
            set { txtUser.Text = value; }
        }

        public View_UserEdit()
        {
            InitializeComponent();
            this.btnOK.Click += delegate { controller.ExecOperation(); };
        }

        public void Init()
        {
            //this.btnOK.Click += delegate { controller.ExecOperation(); };
        }

        public void SetController(AbstractOperationController controller)
        {
            this.controller = controller;
        }

        public void SetViewCaption(string caption)
        {
            this.Text = caption;
        }
    }
}
