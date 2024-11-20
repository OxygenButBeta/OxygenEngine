/*
using OxygenEngineImport.Importables;
using OxygenEngineIO.Importables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxygenEngineImport
{
    public class Importer
    {
        public static IEnumerable<IMeshImporter> FindImportableAssets(string extension, string parentDir)
        {

            var x = Directory.GetFiles(parentDir, "*.*", SearchOption.AllDirectories)
               .Where(file => file.EndsWith(extension));



            if (extension == "obj")
            {
                List<ObjImporter> importables = new();
                foreach (var fileDir in x)
                {
                    importables.Add(new ObjImporter(Path.GetFileName(fileDir), fileDir));
                }
                return importables;
            }

            return default;

        }
    }
}
*/
