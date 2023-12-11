using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vbox;

namespace HimzoManager
{
    class VboxTest
    {
        private vboxPortTypeClient vbox = new();
        private string token = "";

        public VboxTest()
        {
            token = GetToken().Result;
            Console.WriteLine("Login token:"+token);


            Console.WriteLine("Elérhető gépek:");
            var machines = GetMachine(token);
            foreach (var item in machines.Result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Snapshot-ok:");
            var snapshots = getSnapShots(machines.Result[6]);
            foreach (var item in snapshots.Result)
            {
                Console.WriteLine(getSnapshotName(item).Result);
                Console.WriteLine(" \\-"+getSnapshotDescription(item).Result);
            }
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

        public async Task<string> getFirstSnapShot(string machine)
        {
            var snapshot = await vbox.IMachine_findSnapshotAsync(machine, null);
            return snapshot.returnval;
        }

        public async Task<string[]> getSnapShots(string machine)
        {
            string root = getFirstSnapShot(machine).Result;
            var leaves = await vbox.ISnapshot_getChildrenAsync(root);
            string[] tree = new string[leaves.returnval.Length+1];
            tree[0] = root;
            for (int i = 1; i < tree.Length; i++)
            {
                tree[i] = leaves.returnval[i - 1];
            }
            return tree;
        }

        public async Task<string> getSnapshotName(string snapshot)
        {
            var name = await vbox.ISnapshot_getNameAsync(snapshot);
            return name.returnval;
        }

        public async Task<string> getSnapshotDescription(string snapshot)
        {
            var description = await vbox.ISnapshot_getDescriptionAsync(snapshot);
            return description.returnval;
        }
    }
}
