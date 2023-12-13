using HimzoManager.Model;
using HimzoCommon.Writer;
using HimzoManager.Data;
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
        private IDataWriter dataWriter;
        public Machine? SelectedMachine { get; set; }

        private VmData? selectedVmData;
        public VmData? SelectedVmData
        {
            get
            {
                return selectedVmData;
            }
        }
        public List<Machine> Machines { get; set; } = [];

        public VboxEditorViewModel(IDataWriter dataWriter)
        {
            this.vboxClient = new VboxClient(new Vbox.vboxPortTypeClient());
            getMachines();
            this.dataWriter = dataWriter;
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

        private Snapshot getSnapshotRecursive(string machine, Snapshot snapshot)
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
                getSnapshotRecursive(machine, snapshotData);
            }
            return snapshot;
        }

        public void LoadSnapshots(Machine machine)
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
            machine.Snapshots = getSnapshotRecursive(machineToken, snapshotData);
        }

        public void SelectMachine(Machine machine)
        {
            SelectedMachine = machine;
            this.LoadSnapshots(machine);
            this.selectedVmData = new VmData
            {
                Name = machine.Name,
                Id = machine.Id,
                SnapshotID = machine.Snapshots.Id
            };
        }

        public void SetStartDate(DateTime startDate)
        {
            if (SelectedVmData != null)
            {
                SelectedVmData.StartDate = startDate;
            }
        }

        public void SetResetInterval(TimeSpan resetInterval)
        {
            if (SelectedVmData != null)
            {
                SelectedVmData.ResetInterval = resetInterval;
            }
        }

        public void SaveMachine(string path)
        {
            dataWriter.Write(path+$"{selectedVmData.Name}.xml", selectedVmData);
        }

        public void LoadMachine(string path)
        {
            // TODO
        }
    }
}
