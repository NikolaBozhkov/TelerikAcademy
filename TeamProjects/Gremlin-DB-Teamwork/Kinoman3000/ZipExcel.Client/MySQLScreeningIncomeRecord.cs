using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipExcel.Client.Contracts;

namespace ZipExcel.Client
{
    class MySQLScreeningIncomeRecord : ISQLRecord
    {
        private Dictionary<string, string> Properties;

        public MySQLScreeningIncomeRecord(string date, string expence, string filmId)
        {
            this.Properties = new Dictionary<string, string>();
            this.Properties.Add("Date", date);
            this.Properties.Add("Expence", expence);
            this.Properties.Add("FilmId", filmId);
        }

        public void SetProperty(string key, string value)
        {
            this.Properties[key] = value;
        }

        public string GetProperty(string key)
        {
            return this.Properties[key];
        }
    }
}
