using aplimat_labs.Models;
using aplimat_labs.Utilities;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplimat_labs
{
    public partial class MainWindow : Window
    {

        private const float LINE_SMOOTHNESS = 0.02f;
        private const float GRAPH_LIMIT = 15;
        private const int TOTAL_CIRCLE_ANGLE = 360;

        //private Vector3 a = new Vector3(15, 15, 0);
        //private Vector3 b = new Vector3(-2, 10, 0);

        //private const int one = 0;
        //private const int two = 1;
        //private const int three = 2;
        //private const int four = 3;
        //private const int five = 4;
        //private const int six = 5;
        //private const int seven = 6;
        //private const int eight = 7;


        //private Randomizer rng = new Randomizer(0, 7);
        //private Randomizer yAxis = new Randomizer(-20, 20);
        //private Randomizer RGB = new Randomizer(0, 1);

        public MainWindow()
        {
            InitializeComponent();

            //myVector = a;
            //onsole.WriteLine(myVector.GetMagnitude());
            //this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);

            //Vector3 c = a + b;
            //Console.WriteLine("vector c values: x:" + c.x + "y:" + c.y + " z:" + c.z);

            //Vector3 d = a - b;
            //Console.WriteLine("vector d values: x:" + d.x + "y:" + d.y + " z:" + d.z);

        }
        private CubeMesh lightCube = new CubeMesh()
        {
            //Acceleration = new Vector3(0.1f, 0, 0),
            Position = new Vector3(-25, 0, 0)
        };

        private CubeMesh middleWeightCube = new CubeMesh()
        {
            Position = new Vector3(-25, 10, 0),
            Mass = 5
        };

        private CubeMesh heavyCube = new CubeMesh()
        {
            Position = new Vector3(-25, -10, 0),
            Mass = 10
        };



        private Vector3 gravity = new Vector3(0, 0.01f, 0);
        private Vector3 wind = new Vector3(0.01f, 0, 0);
        //private Vector3 acceleration = Vector3.down * 9.81f;

        private CubeMesh mover = new CubeMesh(-25, 0, 0);
        private Vector3 acceleration = new Vector3(0.01f, 0, 0);


        //private Vector3 deceleration = new Vector3(-0.01f, 0, 0);

        //private CubeMesh myCube = new CubeMesh();
        //private Randomizer rng = new Randomizer(-1, 1);
        ////private CubeMesh myCube = new CubeMesh();
        //private Vector3 velocity = new Vector3(1, 0, 0);
        //private float speed = 2.0f;

        //private Vector3 myVector = new Vector3();
        //private Vector3 a = new Vector3(5, 7, 0);
        //private Vector3 b = new Vector3(-7, -6, 0);



        //private List<CubeMesh> myCubes = new List<CubeMesh>();

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;
            //this.Title = "Vectors";

            //myVector = a;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            gl.Translate(0.0f, 0.0f, -40.0f);

            lightCube.Draw(gl);
            lightCube.ApplyForce(wind);
            lightCube.ApplyForce(gravity);
            gl.Color(1.0f, 0.0f, 0.0f);


            middleWeightCube.Draw(gl);
            middleWeightCube.ApplyForce(wind);
            middleWeightCube.ApplyForce(gravity);
            gl.Color(0.0f, 0.0f, 1.0f);

            heavyCube.Draw(gl);
            heavyCube.ApplyForce(wind);
            heavyCube.ApplyForce(gravity);
            gl.Color(0.0f, 1.0f, 0.0f);



            //mover.Draw(gl);
            //mover.Velocity += acceleration;
            ////mover.Velocity -= deceleration;
            //mover.Velocity.Clamp(2.0f);

            if (lightCube.Position.x >= 25.0f)
            {
                lightCube.Position.y = -25;
            }
            else if (mover.Position.x >= 25.0f)
            {
                lightCube.Position.y = 0;
            }

            //gl.DrawText(20, 20, 1, 0, 0, "Arial", 25, mover.Velocity.x + " ");


            //OpenGL.GL_LINE_WIDTH(1.0f, 1.0f, 0);
            //gl.Color(0.0f, 0.0f, 1.0f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Vertex(15, 0);
            //gl.Vertex(a.x, a.y);
            //gl.End();
            //mousePos.Normalize();
            //mousePos *= 10;

            //gl.LineWidth(30.0f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Color(1.0f, 0.0f, 0.0f);
            //gl.Color(0.0f, 1.0f, 0.0f);
            //gl.Vertex(0, 0, 0);
            //gl.Vertex(mousePos.x, mousePos.y, 0);
            //gl.End();

            //gl.LineWidth(3.0f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Color(1.0f, 1.0f, 1.0f);
            //gl.Vertex(0, 0, 0);
            //gl.Vertex(mousePos.x, mousePos.y, 0);
            //gl.End();

            //gl.Color(1.0f, 0.0f, 0.0f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Vertex(0, 0);
            //gl.Vertex(a.x, a.y);
            //gl.End();

            //gl.Color(0.0f, 1.0f, 0.0f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Vertex(0, 0);
            //gl.Vertex(a.x, a.y);
            //gl.Vertex(b.x, b.y);
            //gl.End();

            //gl.Color(0.0f, 0.0f, 1.0f);
            //gl.Begin(OpenGL.GL_LINE_STRIP);
            //gl.Vertex(b.x, b.y);
            //gl.Vertex(0,0);
            //gl.End();

            //gl.DrawText(0, 0, 1, 1, 1 "Arial", 15, "myVector magnitude");

            //CubeMesh myCube = new CubeMesh();
            //myCube.Position = new Vector3(Gaussian.Generate(0, 15), yAxis.GenerateDouble(), 0);
            //myCubes.Add(myCube);

            //myCube.Draw(gl);
            //myCube.Position += velocity * speed;

            //if (myCube.Position.x >= 25.0f)
            //{
            //    velocity.x = -1;
            //}
            //else if (myCube.Position.x <= -25.0f)
            //{
            //    velocity.x = 1;
            //}
            // if (myCube.Position.y >= 10.0f)
            // {
            //     velocity.y = -1;
            // }
            // else if (myCube.Position.y <= -10.0f)
            // {
            //     velocity.y = 1;
            // }
            //if (myCube.Position.y >= 30.0f)
            //{
            //    velocity.x = -1;
            //}
            //if (myCube.Position.y <= 30.0f)
            //{
            //    velocity.y = 1;
            //}
            //CubeMesh myCube2 = new CubeMesh();
            //myCube2.Position = new Vector3(Generate(-20, 20),0);
            //myCubes.Add(myCube2);

            //foreach (var cube in myCubes)
            //{
            ////    //gl.Color(RGB.Generate(), RGB.Generate(), RGB.Generate());
            //    cube.Draw(gl);
            //}

        }


        private void DrawCartesianPlane(OpenGL gl)
        {

            //draw y-axis
            gl.Begin(OpenGL.GL_LINE_STRIP);

            gl.Color(1.0f, 0.0f, 1.0f);
            gl.Vertex(0, -GRAPH_LIMIT, 0);
            gl.Vertex(0, GRAPH_LIMIT, 0);
            gl.End();

            //draw x-axis
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Vertex(-GRAPH_LIMIT, 0, 0);
            gl.Vertex(GRAPH_LIMIT, 0, 0);
            gl.End();

            //draw unit lines
            for (int i = -15; i <= 15; i++)
            {
                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(-0.2f, i, 0);
                gl.Vertex(0.2f, i, 0);
                gl.End();

                gl.Begin(OpenGL.GL_LINE_STRIP);
                gl.Vertex(i, -0.2f, 0);
                gl.Vertex(i, 0.2f, 0);
                gl.End();
            }
        }

        private void DrawPoint(OpenGL gl, float x, float y)
        {
            gl.PointSize(5.0f);
            gl.Begin(OpenGL.GL_POINTS);
            gl.Vertex(x, y);
            gl.End();
        }

        private void DrawLinearFunction(OpenGL gl)
        {
            /*
             * f(x) = x + 2;
             * Let x be 4, then y = 6 (4, 6)
             * Let x be -5, then y = -3 (-5, -3)
             * */
            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x += LINE_SMOOTHNESS)
            {
                gl.Vertex(x, x + 2);
            }
            gl.End();

            DrawText(gl, "f(x) = x + 2", 500, 400);

        }


        private void DrawQuadraticFunction(OpenGL gl)
        {
            /*
             * f(x) = x^2 + 2x - 5;
             * Let x be 2, then y = 3
             * Let x be -1, then y = -6
             */

            //gl.PointSize(1.0f);
            //gl.Begin(OpenGL.GL_POINTS);
            //for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x += LINE_SMOOTHNESS)
            //{
            //    gl.Vertex(x, Math.Pow(x, 2) + (2 * x) - 5);
            //}
            //gl.End();

            /*
             * f(x) = x^2
             * 
             */
            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (float x = -(GRAPH_LIMIT - 5); x <= (GRAPH_LIMIT - 5); x += LINE_SMOOTHNESS)
            {
                gl.Vertex(x, Math.Pow(x, 2));
            }
            gl.End();

            DrawText(gl, "f(x) = x ^ 2", 360, 380);

        }

        private void DrawCircle(OpenGL gl)
        {
            float radius = 3.0f;

            gl.PointSize(2.0f);
            gl.Begin(OpenGL.GL_POINTS);
            for (int i = 0; i <= TOTAL_CIRCLE_ANGLE; i++)
            {
                gl.Vertex(Math.Cos(i) * radius, Math.Sin(i) * radius);
            }
            gl.End();

            DrawText(gl, "(cos(x), sin(x))", 350, 200);
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                    break;
            }
        }
        #region opengl init
        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);
            //gl.Color(RGB.GenerateDouble(), RGB.GenerateDouble(), RGB.GenerateDouble());
            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);
            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            gl.Disable(OpenGL.GL_LIGHTING);
            gl.Disable(OpenGL.GL_LIGHT0);



            gl.ShadeModel(OpenGL.GL_SMOOTH);

        }
        private Vector3 mousePos = new Vector3();
        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            //mousePos = new Vector3(e.GetPosition(this).x, e.GetPosition(this).y, 0);
            var pos = e.GetPosition(this);
            mousePos.x = (float)pos.X - (float)Width / 2.0f;
            mousePos.y = (float)pos.Y - (float)Height / 2.0f;

            mousePos.y = -mousePos.y;

            Console.WriteLine("mouse x;" + mousePos.x + " y:" + mousePos.y);
        }
        #endregion

        #region draw text
        private void DrawText(OpenGL gl, string text, int x, int y)
        {
            gl.DrawText(x, y, 1, 1, 1, "Arial", 12, text);
        }
        #endregion

        private void OpenGLControl_MouseMove_1(object sender, MouseEventArgs e)
        {

        }
    }
}