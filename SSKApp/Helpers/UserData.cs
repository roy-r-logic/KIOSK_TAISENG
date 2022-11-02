using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSKApp.Helpers
{
    public sealed class UserData
    {
        private static UserData _instance;

        private UserData()
        {
          
        }

        public static UserData GetInstance()
        {
            if (_instance == null)
            {
                _instance = new UserData();
            }

            return _instance;
        }

        public void Dispose()
        {
            if (_instance != null)
            {
                _instance = null;
            }
        }
    }
}
