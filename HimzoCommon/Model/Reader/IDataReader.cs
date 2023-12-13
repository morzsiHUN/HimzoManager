using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HimzoCommon.Model.Reader
{
    public interface IDataReader
    {
        T Read<T>(string path);
    }
}
