using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disigne
{
    class BuisnessLogicClass
    {
        private FirstPage firstPage;

        public BuisnessLogicClass()
        {
            firstPage = new FirstPage();
        }

        public void SaveDate()
        {
            string name = "nastya";
            int age = 20;

            firstPage.LoadPage();
            firstPage.SetName(name);
            firstPage.SetAge(age.ToString());
            firstPage.ClickSave();
        }
    }
}
