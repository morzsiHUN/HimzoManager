using System.Diagnostics;
using Vbox;

namespace HimzoCommon.Model.VboxClient
{
    //TODO: A VboxClient legyen absztakt, majd legyen egy adatot csak olvasó része és egy adatot módosító része. Az olvasót az editor, a módosítót a service használja. Akár az is lehet, hogy a olvasó az az editor projekten belül legyen, a módosító pedig a service-ben legyen.
    public class VboxClient
    {
        private vboxPortTypeClient vbox = new();

        private string loginToken = "";

        public VboxClient(vboxPortTypeClient client)
        {
            vbox = client;
            loginToken = getToken();
        }

        private string getToken()
        {
            var token = vbox.IWebsessionManager_logonAsync("test", "test").Result;
            return token.returnval;
        }
        // TODO: a token egy időután lejárt, ezért nem a tokenes gépeket és snapshotokat kellene visszaadni, hanem azoknak az id-jét. Ezek után meg minden metódus az ID alapján működne.
        // TODO: ha a token lejárt azt érzékelni, majd megújakítani
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
