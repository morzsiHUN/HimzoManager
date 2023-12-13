using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoManager.Data
{
    public class Machine
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public Snapshot Snapshots { get; set; }

        public override string ToString()
        {
            return Name + ";" + Id + ";" + Snapshots;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
