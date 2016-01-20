using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dictionary
{
    public static class ViewsMediator
    {
        enum operations {insert,update,delete};

        public delegate Model getModelDelegate();
        public static getModelDelegate getModelDelegateHandler;

        public delegate Controller_View getControllerDelegate();
        public static getControllerDelegate getControllerDelegateHandler;
        
        public delegate User getUserDelegate();
        public static getUserDelegate getUserDelegateHandler;
    }
}
