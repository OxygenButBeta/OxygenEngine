using OxygenEngineCore.Rendering;

namespace OxygenEngineCore.Primitive;

public partial class MeshRenderer {
    bool m_Rendering;

    internal override void OnActiveStateChange(bool active) {
        switch (m_Rendering)
        {
            case true when !active:
                OxygenEngine.GlRenderEngine.DetachFromDrawQueue(this);
                m_Rendering = false;
                break;
            case false when active:
                OxygenEngine.GlRenderEngine.AttachToDrawQueue(this);
                break;
        }

        Console.WriteLine("Active State Changed" + active);
    }

    public void PrepareToRender() {
        if (!m_meshImported && mesh != null)
        {
            mesh = mesh.ImportAsset();
            m_meshImported = true;
            Console.WriteLine("Mesh Imported");
        }

        Vao = new VertexArrayObject();

        Vertex_VBO = new VertexBufferObject(mesh.Vertices);

        Vao.BindVertexArray(0, 3);

        UV_VBO = new VertexBufferObject(mesh.UVs);
        UV_VBO.BindBuffer();

        Vao.BindVertexArray(1, 2);

        Index_IBO = new IndexBufferObject(mesh.Indices);

        Vao.Bind();
        Index_IBO.BindBuffer();
        texture = texture ??= new Texture();
        texture.Bind();

        OxygenEngine.GlRenderEngine.AttachToDrawQueue(this);
        m_Rendering = true;
    }
}