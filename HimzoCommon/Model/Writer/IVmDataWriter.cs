using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoCommon.Model.Writer
{
    public interface IDataWriter
    {
        void Write<T>(string path, T data);
    }
}
