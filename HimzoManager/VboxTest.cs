using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoManager
{
    class VboxTest
    {
        private Vbox.vboxPortTypeClient vbox = new Vbox.vboxPortTypeClient();

        public VboxTest()
        {
            Task<string> token = GetToken();
            var machines = GetMachine(token.Result);
            foreach (var item in machines.Result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(token.Result);
        }

        public async Task<string> GetToken()
        {
            var token = await vbox.IWebsessionManager_logonAsync("test", "test");
            return token.returnval;
        }

        public async Task<string[]> GetMachine(string token)
        {
            var items = await vbox.IVirtualBox_getMachinesAsync(token);
            return items.returnval;
        }
    }
}
