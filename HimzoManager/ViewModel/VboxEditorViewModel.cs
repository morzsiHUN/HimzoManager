using HimzoManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoManager.ViewModel
{
    class VboxEditorViewModel
    {
        private VboxClient vboxClient;
        //private Machine selectedVM { get; set; }
        public List<Machine> Machines { get; set; } = [];

        public VboxEditorViewModel()
        {
            vboxClient = new VboxClient(new Vbox.vboxPortTypeClient());
            getMachines();
        }

        private void loadMachines()
        {

        }

        private void getMachines()
        {
            var machineTokens =  vboxClient.GetMachines();
            foreach (var item in machineTokens)
            {
                var machineName = vboxClient.GetMachineName(item);
                var machineId = vboxClient.GetMachineID(item);
                var machineData = new Machine
                {
                    Name = machineName,
                    Id = machineId
                };
                Machines.Add(machineData);
            }
        }

        private Snapshot GetSnapshotRecursive(string machine, Snapshot snapshot)
        {
            var snapshotToken = vboxClient.FindSnapshotById(machine, snapshot.Id);
            var children = vboxClient.GetSnapshotChildren(snapshotToken);
            foreach (var child in children)
            {
                var snapshotName = vboxClient.GetSnapshotName(child);
                var snapshotDescription = vboxClient.GetSnapshotDescription(child);
                var snapshotId = vboxClient.GetSnapshotId(child);
                var snapshotData = new Snapshot
                {
                    Name = snapshotName,
                    Description = snapshotDescription,
                    Id = snapshotId
                };
                snapshot.Children.Add(snapshotData);
                GetSnapshotRecursive(machine, snapshotData);
            }
            return snapshot;
        }

        public void getSnapshots(Machine machine)
        {
            string machineToken = vboxClient.FindMachineById(machine.Id);
            var snapshots = vboxClient.GetFirstSnapShot(machineToken);
            var snapshotName = vboxClient.GetSnapshotName(snapshots);
            var snapshotDescription = vboxClient.GetSnapshotDescription(snapshots);
            var snapshotId = vboxClient.GetSnapshotId(snapshots);
            var snapshotData = new Snapshot
            {
                Name = snapshotName,
                Description = snapshotDescription,
                Id = snapshotId
            };
            machine.CurrentSnapshot = GetSnapshotRecursive(machineToken, snapshotData);
            //machine.CurrentSnapshot.Children.Add(GetSnapshotRecursive(machineToken, snapshotData));
            return;
        }
    }
}
