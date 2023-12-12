using HimzoManager.Model;
using HimzoManager.ViewModel;
using System.Diagnostics;

namespace HimzoManager.View
{
    internal class Program
    {
        //static Stopwatch sw = new Stopwatch();
        static void Main(string[] args)
        {
            //sw.Start();
            //Console.WriteLine($"[{sw.Elapsed}] Program start");
            //VboxClient vboxClient = new VboxClient(new Vbox.vboxPortTypeClient(), sw);
            //Console.WriteLine($"[{sw.Elapsed}] Login token: {vboxClient.LoginToken}");
            //Console.WriteLine($"[{sw.Elapsed}] Elérhető gépek:");
            //int numbers = 0;
            //foreach (var item in vboxClient.Machines)
            //{
            //    Console.Write($"[{sw.Elapsed}]" + numbers++ + ". ");
            //    Console.WriteLine(vboxClient.GetMachineName(item));
            //}
            //int selectedMachine = 0;
            //while (true)
            //{
            //    Console.Write("Válassz egy gépet:");
            //    selectedMachine = Convert.ToInt32(Console.ReadLine());
            //    if (selectedMachine < vboxClient.Machines.Count && selectedMachine >= 0)
            //    {
            //        break;
            //    }
            //    else
            //    {

            //        Console.WriteLine("Nincs ilyen gép!");
            //    }
            //}
            //foreach (var item in vboxClient.GetSnapShots(vboxClient.Machines[selectedMachine]))
            //{
            //    Console.WriteLine(vboxClient.GetSnapshotName(item));
            //    Console.WriteLine(" └───" + vboxClient.GetSnapshotDescription(item));
            //}
            //VmData selecedVM = new VmData();
            //selecedVM.Name = vboxClient.GetMachineName(vboxClient.Machines[selectedMachine]);
            //selecedVM.Id = vboxClient.GetMachineID(vboxClient.Machines[selectedMachine]);
            //Console.WriteLine(selecedVM);
            //Console.WriteLine(vboxClient.GetMachineName(vboxClient.FindMachineById(vboxClient.LoginToken, selecedVM.Id)));
            VboxEditorViewModel vm = new VboxEditorViewModel();
            foreach (var item in vm.Machines)
            {
                Console.WriteLine(item);
            }
            vm.getSnapshots(vm.Machines[6]);
            Console.WriteLine(vm.Machines[6].CurrentSnapshot);
            //foreach (var item in vm.Machines[6].CurrentSnapshot)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
