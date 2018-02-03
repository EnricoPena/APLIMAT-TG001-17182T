using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aplimat_labs.Models
{
    public class CubeMesh
    {
        public Vector3 Position;

        public CubeMesh()
        {
            this.Position = new Vector3();
        }

        public CubeMesh(Vector3 initPos)
        {
            this.Position = initPos;
        }
        public CubeMesh(float x, float y, float z)
        {
            this.Position = new Vector3(x, y, z);
        }

        public void Draw(OpenGL gl)
        {
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);

            //front
            gl.Vertex(this.Position.x - 1, this.Position.y + 1, this.Position.z + 1);
            gl.Vertex(this.Position.x - 1, this.Position.y - 1, this.Position.z + 1);
            gl.Vertex(this.Position.x + 1, this.Position.y + 1, this.Position.z + 1);
            gl.Vertex(this.Position.x + 1, this.Position.y - 1, this.Position.z + 1);

            //right
            gl.Vertex(this.Position.x + 1, this.Position.y + 1, this.Position.z - 1);
            gl.Vertex(this.Position.x + 1, this.Position.y - 1, this.Position.z + 1);

            //back
            gl.Vertex(this.Position.x - 1, this.Position.y + 1, this.Position.z - 1);
            gl.Vertex(this.Position.x + 1, this.Position.y - 1, this.Position.z - 0.5f);

            //left
            gl.Vertex(this.Position.x - 1, this.Position.y + 1, this.Position.z + 1);
            gl.Vertex(this.Position.x - 1, this.Position.y - 1, this.Position.z + 1);

            //top
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            gl.Vertex(this.Position.x - 1, this.Position.y + 1, this.Position.z + 1);
            gl.Vertex(this.Position.x + 1, this.Position.y + 1, this.Position.z + 1);
            gl.Vertex(this.Position.x - 1, this.Position.y + 1, this.Position.z - 1);
            gl.Vertex(this.Position.x + 1, this.Position.y + 1, this.Position.z - 1);
            gl.End();
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);

            //bottom
            gl.Begin(OpenGL.GL_TRIANGLE_STRIP);
            gl.Vertex(this.Position.x - 1, this.Position.y - 1, this.Position.z + 1);
            gl.Vertex(this.Position.x + 1, this.Position.y - 1, this.Position.z + 1);
            gl.Vertex(this.Position.x - 1, this.Position.y - 1, this.Position.z - 1);
            gl.Vertex(this.Position.x + 1, this.Position.y - 1, this.Position.z - 1);
            gl.End();

        }
    }
}
