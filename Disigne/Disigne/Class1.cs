using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Disigne
{
    public abstract class Page
    {
        public abstract void LoadPage();
    }


    public class FirstPage : Page
    {
        private Element textFieldName;
        private Element textFieldAge;
        private Element buttonSave; 

        public override void LoadPage()
        {
            textFieldName = new ElementsOfPage();
            textFieldAge = new ElementsOfPage();
            buttonSave = new ElementsOfPage();
        }

        public void SetName(string name)
        {
            textFieldName.SetText(name);
        }

        public void SetAge(string age)
        {
            textFieldAge.SetText(age);
        }

        public void ClickSave()
        {
            buttonSave.Click();
        }
    }

    public class SecondPage : Page
    {
        public override void LoadPage()
        {
            throw new NotImplementedException();
        }
    }

    public abstract class Element
    {
        public abstract void Click();
        public abstract void SetText(string text);
    }

    public class ElementsOfPage : Element, ILoggable
    {
        private string value;

        public override void Click()
        {
            Console.WriteLine("click to element: " + value);
        }

        public void Log()
        {
            throw new NotImplementedException();
        }

        public override void SetText(string text)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Value: " + value;
        }

    }

    public interface ILoggable
    {
        void Log();
    }

    public class WebDriver
    {
        public const string BROWSER_KEY = "browser";

        //public const string FIREFOX = "Firefox";
        //public const string CHROME = "Chrome";
        //public const string OPERA = "Opera";

        public void GetBrowser()
        {
            Browsers brows = (Browsers) Enum.Parse(typeof(Browsers), ConfigurationManager.AppSettings[BROWSER_KEY],true);

            switch (brows)
                {
                case Browsers.FIREFOX:
                    break;
                case Browsers.CHROME:
                    break;
                case Browsers.OPERA:
                    break;
                default:
                    Console.WriteLine("Browser isn't found");
                    break;
            }
        }

        enum Browsers
        {
            FIREFOX,
            CHROME,
            OPERA
        }

    }

}
