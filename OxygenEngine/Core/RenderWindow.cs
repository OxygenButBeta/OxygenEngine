using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OxygenEngine.Shaders;
using OxygenEngineCore.Primitive;
using OxygenEngineCore.Primitive.Lib;
using OxygenEngineCore.Rendering;
using Mesh = OxygenEngineCore.Primitive.Mesh;


namespace OxygenEngineCore {
    internal class RenderWindow : GameWindow {
        public event Action<RenderWindow> OnUpdate;
        public event Action<RenderWindow> OnAwake;
        public List<IDrawCallElement> DrawCallElements;
        Shader generalShader;
        Camera camera;
        int width, height;

        public RenderWindow(int width, int height) : base(GameWindowSettings.Default, NativeWindowSettings.Default) {
            this.width = width;
            this.height = height;
            DrawCallElements = new();
            CenterWindow(new Vector2i(width, height));
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

            GL.FrontFace(FrontFaceDirection.Cw);
            GL.Enable(EnableCap.CullFace);
            GL.CullFace(CullFaceMode.Front);

            camera = new Camera(width, height, Vector3.Zero);
            CursorState = CursorState.Grabbed;
            Console.WriteLine("OnLoad");
            OnAwake?.Invoke(this);
        }

        protected override void OnUnload() {
            base.OnUnload();
            DrawCallElements.ForEach(x => x.Dispose());
        }

        protected override void OnRenderFrame(FrameEventArgs args) {
            GL.ClearColor(0.3f, 0.3f, 1f, 1f);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            var view = camera.GetViewMatrix();
            var projection = camera.GetProjectionMatrix();


            var viewLocation = GL.GetUniformLocation(generalShader.ID, "view");
            var projectionLocation = GL.GetUniformLocation(generalShader.ID, "projection");

            GL.UniformMatrix4(viewLocation, true, ref view);
            GL.UniformMatrix4(projectionLocation, true, ref projection);

            foreach (var drawCallElement in DrawCallElements)
                drawCallElement.DrawCall(generalShader);


            Context.SwapBuffers();
            base.OnRenderFrame(args);
        }

        protected override void OnUpdateFrame(FrameEventArgs args) {
            base.OnUpdateFrame(args);
            camera.Update(KeyboardState, MouseState, args);

            if (KeyboardState.IsKeyPressed(Keys.C))
            {
                var mesh = DrawCallElements[0];
                DrawCallElements.RemoveAt(0);
                mesh.Dispose();
            }

            OnUpdate?.Invoke(this);
        }
    }
}