using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoManager.Model
{
    class VmData
    {
        public string Name = "";
        public string Id = "";
        //public string Snapshot = "";
        //DateTime startDate;
        //DateTime resetDate;

        public override string ToString()
        {
            return Name + ";" + Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
