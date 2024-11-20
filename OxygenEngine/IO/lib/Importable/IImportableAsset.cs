using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxygenEngineImport.lib.Importable
{
    public interface IImportableAsset<T>
    {
        string Name { get; }
        string Path { get; }
        string Extension { get; }
        T Import();
    }
}
