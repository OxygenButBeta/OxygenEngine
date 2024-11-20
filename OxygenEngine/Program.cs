using OpenTK.Mathematics;
using OxygenEngineCore;
using OxygenEngineCore.Primitive;


using var renderView = new RenderWindow(1280, 720);
renderView.OnAwake += (window) => {
    var mesh = new Mesh(@"C:\Models\cube1.obj");
    mesh.ImportMesh();
    mesh.TransformMatrix = Matrix4.CreateTranslation(0, 0, 0);
    window.Meshes.Add(mesh);

    var catmesh = new Mesh(@"C:\Models\cat.obj","cat.jpg");
    catmesh.ImportMesh();
    catmesh.TransformMatrix = Matrix4.CreateTranslation(1, 0, 0);
    catmesh.ScaleMatrix = Matrix4.CreateScale(4f);
    window.Meshes.Add(catmesh);
    
    var rockmesh = new Mesh(@"C:\Models\rock.obj","rock.jpg");
    rockmesh.ImportMesh();
    rockmesh.TransformMatrix = Matrix4.CreateTranslation(1, 5, 0);
    window.Meshes.Add(rockmesh);
};

renderView.Run();