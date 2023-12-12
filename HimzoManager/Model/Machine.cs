using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoManager.Model
{
    class Machine
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public Snapshot CurrentSnapshot { get; set; }
        //public HashSet<Snapshot> Snapshots { get; set; } = new();

        public override string ToString()
        {
            return Name + ";" + Id + ";" + CurrentSnapshot;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
