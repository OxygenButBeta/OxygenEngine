using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OxygenEngine.Shaders;
using OxygenEngineCore.Primitive.Lib;
using OxygenEngineCore.Rendering;
using ImGuiNET;


namespace OxygenEngineCore {
    public class OpenGL_RenderWindow : GameWindow {
        public event Action<FrameEventArgs, OpenGL_RenderWindow> OnUpdate;
        public event Action<FrameEventArgs, OpenGL_RenderWindow> EarlyUpdate;
        public event Action<FrameEventArgs, OpenGL_RenderWindow> LateUpdate;
        public event Action OPENGL_OverlayUpdate;
        public event Action<OpenGL_RenderWindow> OnAwake;
        public  List<IDrawCallElement> DrawCallElements;
        Shader generalShader;
        Camera m_RenderCamera;
        int width, height;
        readonly ImGuiController imGuiController;

        public void AttachToDrawQueue(IDrawCallElement drawCallElement) {
            DrawCallElements.Add(drawCallElement);
            foreach (var element in DrawCallElements)
            {  
                element.PrepareToRender();
            }
        }

        public void DetachFromDrawQueue(IDrawCallElement drawCallElement) {
            DrawCallElements.Remove(drawCallElement);
            foreach (var element in DrawCallElements)
            {
                element.Dispose();
                element.PrepareToRender();
            }
        }

        public OpenGL_RenderWindow(int width, int height) : base(GameWindowSettings.Default,
            NativeWindowSettings.Default) {
            this.width = width;
            this.height = height;
            Title = "Oxygen Engine | Graphic API: OpenGL " + APIVersion;
            DrawCallElements = new();
            CenterWindow(new Vector2i(width, height));
            imGuiController = new ImGuiController(width, height);
        }

        protected override void OnResize(ResizeEventArgs e) {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
            this.width = e.Width;
            this.height = e.Height;
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
            OnAwake?.Invoke(this);
        }

        protected override void OnUnload() {
            base.OnUnload();
            DrawCallElements.ForEach(x => x.Dispose());
        }

        protected override void OnRenderFrame(FrameEventArgs args) {
            base.OnRenderFrame(args);

            GL.ClearColor(0.0f, 0.4f, 0.7f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit |
                     ClearBufferMask.StencilBufferBit);


            var view = m_RenderCamera.GetViewMatrix();
            var projection = m_RenderCamera.GetProjectionMatrix();


            var viewLocation = GL.GetUniformLocation(generalShader.ID, "view");
            var projectionLocation = GL.GetUniformLocation(generalShader.ID, "projection");

            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionLocation, true, ref projection);

            foreach (var drawCallElement in DrawCallElements)
                drawCallElement.DrawCall(generalShader);

            imGuiController.Update(this, (float)args.Time);

            OPENGL_OverlayUpdate?.Invoke();
            m_RenderCamera.DrawBottomRightInfo();
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