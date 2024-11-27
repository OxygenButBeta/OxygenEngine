using ImGuiNET;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using OxygenEngine.Shaders;
using OxygenEngineCore.Primitive.Lib;
using OxygenEngineCore.Rendering;


namespace OxygenEngineCore {
    public class GLRenderWindow : GameWindow {
        public event Action<FrameEventArgs, GLRenderWindow> OnUpdate;
        public event Action<FrameEventArgs, GLRenderWindow> EarlyUpdate;
        public event Action<FrameEventArgs, GLRenderWindow> LateUpdate;
        public event Action OPENGL_OverlayUpdate;
        public event Action<GLRenderWindow> OnAwake;
        public List<IDrawCallElement> DrawCallElements;
        Shader generalShader;
        Camera m_RenderCamera;
        int width, height;
        bool m_loaded;
        readonly ImGuiController imGuiController;

        public void AttachToDrawQueue(IDrawCallElement drawCallElement) {
            DrawCallElements.Add(drawCallElement);
        }

        public void DetachFromDrawQueue(IDrawCallElement drawCallElement) {
            DrawCallElements.Remove(drawCallElement);
        }

        public GLRenderWindow(int width, int height) : base(GameWindowSettings.Default,
            NativeWindowSettings.Default) {
            this.width = width;
            this.height = height;
            Title = "Oxygen Engine | Graphic API: OpenGL " + APIVersion;
            DrawCallElements = [];
            CenterWindow(new Vector2i(width, height));
            imGuiController = new ImGuiController(width, height);
            m_loaded = true;
        }

        protected override void OnResize(ResizeEventArgs e) {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            this.width = e.Width;
            this.height = e.Height;
            if (m_loaded)
            {
                imGuiController.WindowResized(this.width, height);
            }
        }

        protected override void OnLoad() {
            base.OnLoad();

            generalShader = new Shader(ShaderLoader.VertexShader, ShaderLoader.FragmentShader);

            GL.Enable(EnableCap.DepthTest);

            GL.FrontFace(FrontFaceDirection.Ccw);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Back);

            m_RenderCamera = new Camera(width, height, Vector3.Zero);

            Console.WriteLine("OnLoad");
            ImGui.GetIO().ConfigDockingWithShift = true;

            OnAwake?.Invoke(this);
        }

        protected override void OnUnload() {
            base.OnUnload();
            DrawCallElements.ForEach(x => x.Dispose());
        }

        protected override void OnRenderFrame(FrameEventArgs args) {
            base.OnRenderFrame(args);
            // Background color
            GL.ClearColor(0.0f, 0.4f, 0.7f, 1f);
            // Clear the color buffer
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit |
                     ClearBufferMask.StencilBufferBit);


            var view = m_RenderCamera.GetViewMatrix();
            var projection = m_RenderCamera.GetProjectionMatrix();


            var viewLocation = GL.GetUniformLocation(generalShader.ID, "view");
            var projectionLocation = GL.GetUniformLocation(generalShader.ID, "projection");

            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionLocation, true, ref projection);

            foreach (var drawCallElement in DrawCallElements)
            {
                drawCallElement.Vao.Bind();
                drawCallElement.DrawCall(generalShader);
            }

            imGuiController.Update(this, (float)args.Time);


            OPENGL_OverlayUpdate?.Invoke();
            m_RenderCamera.FrameUpdate();
            imGuiController.Render();

            ImGuiController.CheckGLError("End of frame");
            Context.SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs args) {
            EarlyUpdate?.Invoke(args, this);
            base.OnUpdateFrame(args);
            m_RenderCamera.Update(args, this);
            OnUpdate?.Invoke(args, this);
            LateUpdate?.Invoke(args, this);
        }
    }
}