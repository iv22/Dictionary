using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dictionary
{
    class Controller_UserEdit: AbstractOperationController
    {
        private View_UserEdit view;
        private User user;

        public Controller_UserEdit(Model model, View_UserEdit view, User user)
        {
            this.model = model;
            this.user = user;
            this.view = view;
            InitView();
            view.SetController(this);
            //view.Init();
            view.ShowDialog();
        }

        private void InitView()
        {
            view.SetViewCaption("Редактирование данных пользователя");
            view.user_name = this.user.name;
        }

        public override void ExecOperation() 
        {
            this.user.name = this.view.user_name;
            model.updUser(this.user);
            view.Close();
        }
    }


    class Controller_UserAdd : AbstractOperationController
    {
        private View_UserEdit view;
        private User user;

        public Controller_UserAdd(Model model, View_UserEdit view)
        {
            this.model = model;
            this.user = new User("");
            this.view = view;
            InitView();
            view.SetController(this);
            //view.Init();
            view.ShowDialog();
        }

        public void InitView()
        {
            view.SetViewCaption("Создание нового пользователя");
            view.user_name = this.user.name;
        }

        public override void ExecOperation()
        {
            this.user.name = this.view.user_name;
            model.addUser(this.user);
            view.Close();
        }
    }

    class Controller_UserDel : AbstractOperationController
    {
        private User user;

        public Controller_UserDel(Model model, User user)
        {
            this.model = model;
            this.user = user;
            this.ExecOperation();
        }

        public override void ExecOperation()
        {
            if(MessageBox.Show("Вы действительно желаете удалить пользователя?", 
                "Редактирование списка пользователей",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                model.delUser(user);
        }
    }
}
