using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoManager.Model
{
    class Snapshot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public List<Snapshot> Children { get; set; } = new();

        public override string ToString()
        {
            return listAll();
        }

        private string listAll(string indent = "")
        {
            string result = Name + ";" + Description + ";" + Id + "\n";
            if (Children.Count == 0)
            {
                return result;
            }
            // all but last item
            Snapshot item;
            for (int i = 0; i < Children.Count - 1; i++)
            {
                item = Children[i];
                result += indent + "├─" + item.listAll("│ ");
            }
            // last item
            item = Children[Children.Count - 1];
            result += indent + "└─" + item.listAll("  ");
            return result;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
