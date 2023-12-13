using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoCommon.Reader
{
    public interface IDataReader
    {
        T Read<T>(string path);
    }
}
