using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disigne
{  public interface IReadConfig
    {
        void ReadConfig();
    }

    class DateBaseWorker : IReadConfig
    {
        public void ReadConfig()
        {
            throw new NotImplementedException();
        }
    }

    public class XMLWorker : IReadConfig
    {
        public void ReadConfig()
        {
            throw new NotImplementedException();
        }
    }

}
