using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipExcel.Client.Contracts
{
    public interface ISQLRecord
    {
        void SetProperty(string key, string value);
        string GetProperty(string key);
    }
}
