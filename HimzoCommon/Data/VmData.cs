using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoManager.Data
{
    public class VmData
    {
        public string Name = "";
        public string Id = "";
        public string SnapshotID = "";
        public DateTime? StartDate;
        public TimeSpan? ResetInterval;

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
