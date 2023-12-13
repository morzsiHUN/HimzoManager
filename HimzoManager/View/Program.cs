using HimzoManager.ViewModel;
using HimzoCommon.Model.Writer;

namespace HimzoManager.View
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VboxEditorViewModel vm = new VboxEditorViewModel(new XmlDataWriter());
            Console.WriteLine($"Elérhető gépek:");
            foreach (var item in vm.Machines)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine($"\n{vm.Machines[6]} gép snapshot-jai:");
            vm.LoadSnapshots(vm.Machines[6]);
            Console.WriteLine(vm.Machines[6].Snapshots);
            vm.SelectMachine(vm.Machines[6]);
            vm.SetStartDate(DateTime.UtcNow);
            vm.SetResetInterval(new TimeSpan(1, 0, 0, 0, 0));
            vm.SaveMachine(".\\Saves\\");
        }
    }
}
