using SSKApp.Helpers.Libraries.Scanner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSKApp.Helpers.ChromiumObjects
{
    public class QrScanningChromiumObject
    {

        public async Task<string> Scan()
        {
            using (var scanner = new Scanner())
            {
                var text = await scanner.ReadAsync();
                return text;
            }
        }


    }
}
