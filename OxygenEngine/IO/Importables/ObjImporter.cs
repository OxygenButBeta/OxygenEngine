/*using OxygenEngineImport.lib.Importable;
using OxygenEngineIO.Importables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Mathematics;
using OxygenEngineCore.Primitive;

namespace OxygenEngineImport.Importables {
    public class ObjImporter : IMeshImporter {
        public string Name { get; }
        public string Path { get; }
        public string Extension { get; }

        public ObjImporter(string name, string path) {
            Name = name;
            Path = path;
            Extension = "obj";
        }

        public ObjImporter() {
            Name = "default";
            Path = "default";
            Extension = "obj";
        }

        Vector3 ParseVector3(string[] parts) {
            return new Vector3()
            {
                X = parseFloat(parts[1]),
                Y = parseFloat(parts[2]),
                Z = parseFloat(parts[3])
            };
        }

        Vector2 ParseVector2(string[] parts) {
            return new Vector2()
            {
                X = parseFloat(parts[1]),
                Y = parseFloat(parts[2])
            };
        }

        float parseFloat(string str) {
            return float.Parse(str, CultureInfo.InvariantCulture);
        }

        public Mesh Import() {
            List<Vector3> vertices = new();
            List<Vector3> normals = new();
            List<Vector2> uvs = new();
            List<uint> indices = new();
            using (var reader = new StreamReader(Path))
            {
                while (reader.ReadLine() is { } line)
                {
                    var parts = line.Split(' ');
                    var indicator = parts[0];
                    switch (indicator)
                    {
                        // Collect Vertex positions
                        case "v":
                            vertices.Add(ParseVector3(parts));
                            break;
                        // Normals
                        case "vn":
                            normals.Add(ParseVector3(parts));
                            break;
                        // UVs
                        case "vt":
                            uvs.Add(ParseVector2(parts));
                            break;
                        // Tangents
                        case "f": {
                            for (int i = 1; i < parts.Length; i++)
                            {
                                var values = parts[i].Split('/');
                                for (int j = 0; j < values.Length; j++)
                                {
                                    if (string.IsNullOrWhiteSpace(values[j]))
                                    {
                                        continue;
                                    }

                                    indices.Add(uint.Parse(values[j]));
                                }
                            }

                            break;
                        }
                    }
                }
            }

            return new Mesh()
            {
                Vertices = vertices.ToArray(),
                Normals = normals.ToArray(),
                UVs = uvs.ToArray(),
                Indices = indices.ToArray()
            };
        }
    }
}*/