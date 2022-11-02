using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKWeb.Helpers
{
    public class AppException : Exception
    {
        public string Key { get; set; }
        public Dictionary<string, string> Exceptions { get; set; }
        private AppException() : base() { }

        public AppException(string key, string message) : base(message)
        {
            Key = key;
        }

        public AppException(Dictionary<string, string> ex)
        {
            Exceptions = ex;
        }

        public AppException(string message) : base(message) { Key = "Undefined"; }
    }
}
