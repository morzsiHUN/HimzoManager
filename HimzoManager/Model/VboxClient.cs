using System.Diagnostics;
using Vbox;

namespace HimzoManager.Model
{
    class VboxClient
    {
        private vboxPortTypeClient vbox = new();

        private string loginToken = "";
        public string LoginToken
        {
            get
            {
                return loginToken;
            }
        }

        //private List<string> machines = [];
        //public List<string> Machines
        //{
        //    get
        //    {
        //        return machines;
        //    }
        //}

        public VboxClient(vboxPortTypeClient client, Stopwatch sw)
        {
            vbox = client;
            Console.WriteLine($"[{sw.Elapsed}] VboxTest before token");
            loginToken = GetToken();
            Console.WriteLine($"[{sw.Elapsed}] VboxTest after token");

            //machines.AddRange(GetMachine(loginToken));
        }

        public VboxClient(vboxPortTypeClient client)
        {
            vbox = client;
            loginToken = GetToken();

            //machines.AddRange(GetMachine(loginToken));
        }

        public string GetToken()
        {
            var token = vbox.IWebsessionManager_logonAsync("test", "test").Result;
            return token.returnval;
        }

        #region Machine
        public string[] GetMachines()
        {
            var items = vbox.IVirtualBox_getMachinesAsync(loginToken).Result;
            return items.returnval;
        }
        public string GetMachineName(string machine)
        {
            var name = vbox.IMachine_getNameAsync(machine).Result;
            return name.returnval;
        }
        public string GetMachineID(string machine)
        {
            var description = vbox.IMachine_getIdAsync(machine).Result;
            return description.returnval;
        }
        public string FindMachineById(string id)
        {
            var machine = vbox.IVirtualBox_findMachineAsync(loginToken, id).Result;
            return machine.returnval;
        }
        #endregion

        #region Snapshot
        public string GetFirstSnapShot(string machine)
        {
            var snapshot = vbox.IMachine_findSnapshotAsync(machine, null).Result;
            return snapshot.returnval;
        }

        public string[] GetSnapshotChildren(string snapshot)
        {
            var children = vbox.ISnapshot_getChildrenAsync(snapshot).Result;
            return children.returnval;
        }

        //public string[] GetSnapShots(string machine)
        //{
        //    string root = GetFirstSnapShot(machine);
        //    var leaves = GetSnapshotChildren(root);
        //    string[] tree = new string[leaves.Length + 1];
        //    tree[0] = root;
        //    for (int i = 1; i < tree.Length; i++)
        //    {
        //        tree[i] = leaves[i - 1];
        //    }
        //    return tree;
        //}

        public string GetSnapshotName(string snapshot)
        {
            var name = vbox.ISnapshot_getNameAsync(snapshot).Result;
            return name.returnval;
        }

        public string GetSnapshotDescription(string snapshot)
        {
            var description = vbox.ISnapshot_getDescriptionAsync(snapshot).Result;
            return description.returnval;
        }

        public string GetSnapshotId(string snapshot)
        {
            var id = vbox.ISnapshot_getIdAsync(snapshot).Result;
            return id.returnval;
        }

        public string FindSnapshotById(string machine, string id)
        {
            var snapshot = vbox.IMachine_findSnapshotAsync(machine, id).Result;
            return snapshot.returnval;
        }
        #endregion
    }
}
