using CsGL.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG
{
    public class GLClass : OpenGLControl
    {
        public GLClass()
            : base()
        {
            this.KeyDown += new KeyEventHandler(onKeyDown);
        }
        // int: –2147483648 to 2147483647 uint: 0 to 4294967295 
        public uint[] texture = new uint[8];

        protected override void InitGLContext()
        {
            base.InitGLContext();

            GL.glGenTextures(texture.Length, this.texture);

            LoadTexture(0, Directory.GetCurrentDirectory() + "\\h.jpg");
            LoadTexture(1, Directory.GetCurrentDirectory() + "\\s.jpg");
            LoadTexture(2, Directory.GetCurrentDirectory() + "\\k1.jpg");
            LoadTexture(6, Directory.GetCurrentDirectory() + "\\Capture.png");
            LoadTexture(7, Directory.GetCurrentDirectory() + "\\gs.png");

      
            
        }

        public bool LoadTexture(int index, string file)
        {
            // A Bitmap is an object used to work with images defined by pixel data
            Bitmap image = null;

            try
            {
                // If the file doesn't exist or can't be found, an ArgumentException is thrown instead of
                // just returning null
                image = new Bitmap(file);
            }
            catch (System.ArgumentException)
            {
                MessageBox.Show("Could not load " + file + ".  Please make sure that Data is a subfolder from where the application is running.", "Error", MessageBoxButtons.OK);
            }


            if (image != null)
            {
                //image.RotateFlip(RotateFlipType.RotateNoneFlipY);

                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                // Specifies the attributes of a bitmap image.
                // The BitmapData class is used by the LockBits and UnlockBits(BitmapData) methods of the Bitmap class.
                BitmapData bitmapdata;

                // locks a bitmap into a system memory
                bitmapdata = image.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

                // Get the address of the first line.
                IntPtr ptr = bitmapdata.Scan0;

                // Used to perform a simple calculation as to how to text corresponds to screen pixels
                // Create Nearest Filtered Texture
                // bind a named texture to a texturing target
                // 1 par: Specifies the target to which the texture is bound. (1D, 2D, 3D, Map, ..)
                GL.glBindTexture(GL.GL_TEXTURE_2D, texture[index]);

                // set texture parameters
                // 2 par: Specifies the symbolic name of a single-valued texture parameter.
                // 3 par: For the scalar commands, specifies the value of pname.
                GL.glTexParameteri(GL.GL_TEXTURE_2D, GL.GL_TEXTURE_MIN_FILTER, GL.GL_NEAREST);

                GL.glTexImage2D(GL.GL_TEXTURE_2D, 0, (int)GL.GL_RGB, image.Width, image.Height, 0, GL.GL_BGR_EXT, GL.GL_UNSIGNED_BYTE, bitmapdata.Scan0);

                image.UnlockBits(bitmapdata);
                image.Dispose();
                return true;
            }
            return false;
        }
        float eyeX = 0f, eyeY = 0f, eyeZ = 33f;
        float centerX = 0, centerY = 0, centerZ = 0;
        float upX = 0, upY = 1, upZ = 0;
        Boolean b = true;
       
            
            
        
        public override void glDraw()
        {
            base.glDraw();
            GL.glClear(GL.GL_COLOR_BUFFER_BIT);
            GL.glLoadIdentity();

            GLU.gluLookAt(eyeX, eyeY, eyeZ, centerX, centerY, centerZ, upX, upY, upZ);


            if (b == true)
            {
                GL.glEnable(GL.GL_TEXTURE_2D);
                    back();
                    drowsquare();
                    randowmenemy1();
                    randowmenemy2();
                    randowmenemy3();
                    randowmenemy4();
                    scoree();

                    if (u == true)
                    {
                        drawbulit();

                    }
                    if (u2 == true)
                    {
                        drawbulit2();

                    }
                    if (u3 == true)
                    {
                        drawbulit3();

                    }
                    if (u4 == true)
                    {
                        drawbulit4();



                    }


                    GL.glDisable(GL.GL_TEXTURE_2D);
                }
            else
            {
                Console.Write("game over");
            }
            
            
            this.Refresh();
        }
        public Boolean u,u1,u2,u3,u4;
        float x,xx,xxx,xxxx,xxxxx;
        private void restartt()
        {
            b = true;
        
        }
        private void back()
        {

            GL.glPushMatrix();
            GL.glBindTexture(GL.GL_TEXTURE_2D, texture[0]);
            GL.glBegin(GL.GL_POLYGON);
            GL.glTexCoord2d(0, 0);GL.glVertex3d(66, 12, 1);     // right top
            GL.glTexCoord2d(1, 0);GL.glVertex3d(-66, 12, 1);    // left top
            GL.glTexCoord2d(1, 1);GL.glVertex3d(-66, -12, 1);   // left down
            GL.glTexCoord2d(0, 1);GL.glVertex3d(66, -12, 1);    // right down
            GL.glEnd();
            GL.glPopMatrix();
           

        }

        public void drowsquare()
        {
            
            GL.glPushMatrix();
            GL.glTranslated(2, 4, 0);

            GL.glPushMatrix();
             GL.glTranslated(x, 0, 0);

            GL.glBindTexture(GL.GL_TEXTURE_2D, texture[1]);
            GL.glBegin(GL.GL_POLYGON);

            //GL.glColor3d(0, 1, 0);
            GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 1, 0);
            GL.glTexCoord2d(1, 0); GL.glVertex3d(-6, 1, 0);
            GL.glTexCoord2d(1, 1); GL.glVertex3d(-6, -1, 0);
            GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -1, 0);
            
            GL.glEnd();

            GL.glPopMatrix();
            GL.glPopMatrix();

            
           
        }
       

        void drawbulit()
        {
            GL.glPushMatrix();
            GL.glTranslated(xx, step, 0);

            //GL.glPushMatrix();
           // GL.glTranslated(x, 0, 0);

            GL.glBindTexture(GL.GL_TEXTURE_2D, texture[2]);
            GL.glBegin(GL.GL_POLYGON);

            //GL.glColor3d(0, 1, 0);
            GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 1, 0);
            GL.glTexCoord2d(1, 0); GL.glVertex3d(-1, 1, 0);
            GL.glTexCoord2d(1, 1); GL.glVertex3d(-1, -1, 0);
            GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -1, 0);
            GL.glEnd();
            GL.glPopMatrix();
           // GL.glPopMatrix();
            
            
        }
        void drawbulit2()
        {




            GL.glPushMatrix();
            GL.glTranslated(xxx, step2, 0);

            //GL.glPushMatrix();
            // GL.glTranslated(x, 0, 0);

            GL.glBindTexture(GL.GL_TEXTURE_2D, texture[2]);
            GL.glBegin(GL.GL_POLYGON);

            //GL.glColor3d(0, 1, 0);
            GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 1, 0);
            GL.glTexCoord2d(1, 0); GL.glVertex3d(-1, 1, 0);
            GL.glTexCoord2d(1, 1); GL.glVertex3d(-1, -1, 0);
            GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -1, 0);
            GL.glEnd();
            GL.glPopMatrix();
            // GL.glPopMatrix();
           

        }
        void drawbulit3()
        {




            GL.glPushMatrix();
            GL.glTranslated(xxxx, step3, 0);

            //GL.glPushMatrix();
            // GL.glTranslated(x, 0, 0);

            GL.glBindTexture(GL.GL_TEXTURE_2D, texture[2]);
            GL.glBegin(GL.GL_POLYGON);

            //GL.glColor3d(0, 1, 0);
            GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 1, 0);
            GL.glTexCoord2d(1, 0); GL.glVertex3d(-1, 1, 0);
            GL.glTexCoord2d(1, 1); GL.glVertex3d(-1, -1, 0);
            GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -1, 0);
            GL.glEnd();
            GL.glPopMatrix();
            // GL.glPopMatrix();
           

        }
        void drawbulit4()
        {
            GL.glPushMatrix();
            GL.glTranslated(xxxxx, step4, 0);

            //GL.glPushMatrix();
            // GL.glTranslated(x, 0, 0);

            GL.glBindTexture(GL.GL_TEXTURE_2D, texture[2]);
            GL.glBegin(GL.GL_POLYGON);

            //GL.glColor3d(0, 1, 0);
            GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 1, 0);
            GL.glTexCoord2d(1, 0); GL.glVertex3d(-1, 1, 0);
            GL.glTexCoord2d(1, 1); GL.glVertex3d(-1, -1, 0);
            GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -1, 0);
            GL.glEnd();
            GL.glPopMatrix();
            // GL.glPopMatrix();

        }
        public static int rand(int r)
        {

            Random c = new Random();
            int rand1 = c.Next(-35, -18);
            int rand2 = c.Next(-18, -1);
            int rand3 = c.Next(0, 17);
            int rand4 = c.Next(18, 35);
            int randy1 = c.Next(-5, 0);
            int randy2 = c.Next(-5, 0);
            int randy3 = c.Next(-5, 0);
            int randy4 = c.Next(-5, 0);
            if (r == 1)
            {
                return rand1;
            }
            if (r == 2)
            {
                return rand2;
            }
            if (r == 3)
            {
                return rand3;
            }
            if (r == 4)
            {
                return rand4;
            }
            if (r == 5)
            {
                return randy1;
            }
            if (r == 6)
            {
                return randy2;
            }
            if (r == 7)
            {
                return randy3;
            }
            if (r == 7)
            {
                return randy4;
            }
            return 0;


        }
        int rand1 = rand(1);
        int rand2 = rand(2);
        int rand3 = rand(3);
        int rand4 = rand(4);
        int randy1 = rand(5);
        int randy2 = rand(6);
        int randy3 = rand(7);
        int randy4 = rand(8);

        public static int score1 ;
        public static int score2;
        public static int score3;
        public static int score4;
        public void randowmenemy1()
        {
            if (rand1 == (int)xx && randy1 > (int)step || rand1 == (int)xxx && randy1 > (int)step || rand1 == (int)xxxx && randy1 > (int)step || rand1 == (int)xxxxx && randy1 > (int)step || rand1 == (int)xx && randy1 > (int)step)
            {

                score1 = 1;
            }
            else 
            {
                GL.glPushMatrix();
                GL.glTranslated(rand1, randy1, 0);

                GL.glBindTexture(GL.GL_TEXTURE_2D, texture[7]);
                GL.glBegin(GL.GL_POLYGON);

                GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 0.5, 0);
                GL.glTexCoord2d(1, 0); GL.glVertex3d(-1, 0.5, 0);
                GL.glTexCoord2d(1, 1); GL.glVertex3d(-1, -0.5, 0);
                GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -0.5, 0);

                GL.glEnd();

                GL.glPopMatrix();
                score1 = 0;
            }
            

        }
        public void randowmenemy2()
        {

            if (rand2 == (int)xx && randy2 > (int)step2 || rand2 == (int)xxx && randy2 > (int)step2 || rand2 == (int)xxxx && randy2 > (int)step2 || rand2 == (int)xxxxx && randy2 > (int)step2 || rand2 == (int)xx && randy2 > (int)step2)
            {
                score2 = 2;
               
                
            }

            else
            {
                GL.glPushMatrix();
                GL.glTranslated(rand2, randy2, 0);


                GL.glBindTexture(GL.GL_TEXTURE_2D, texture[7]);
                GL.glBegin(GL.GL_POLYGON);


                GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 0.5, 0);
                GL.glTexCoord2d(1, 0); GL.glVertex3d(-1, 0.5, 0);
                GL.glTexCoord2d(1, 1); GL.glVertex3d(-1, -0.5, 0);
                GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -0.5, 0);
                GL.glEnd();
                GL.glPopMatrix();
                score2 = 0;
            }

        }
        public void randowmenemy3()
        {
            if (rand3 == (int)xx && randy3 > (int)step3 || rand3 == (int)xxx && randy3 > (int)step3 || rand3 == (int)xxxx && randy3 > (int)step3 || rand3 == (int)xxxxx && randy3 > (int)step3 || rand3 == (int)xx && randy3 > (int)step3)
            {

                score3 = 3;
                
                
            }
            else
            {
                GL.glPushMatrix();
                GL.glTranslated(rand3, randy3, 0);
               
                GL.glBindTexture(GL.GL_TEXTURE_2D, texture[7]);
                GL.glBegin(GL.GL_POLYGON);

                //GL.glColor3d(0, 1, 0);
                GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 0.5, 0);
                GL.glTexCoord2d(1, 0); GL.glVertex3d(-1, 0.5, 0);
                GL.glTexCoord2d(1, 1); GL.glVertex3d(-1, -0.5, 0);
                GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -0.5, 0);

                GL.glEnd();
                GL.glPopMatrix();
                score3 = 0;
            }
        }
        public void randowmenemy4()
        {
            if (rand4 == (int)xx && randy4 > (int)step4 || rand4 == (int)xxx && randy4 > (int)step4 || rand4 == (int)xxxx && randy4 > (int)step4 || rand4 == (int)xxxxx && randy4 > (int)step4 || rand4 == (int)xx && randy4 > (int)step4)
            {

                score4 = 4;
                
            }
            else
            {
                GL.glPushMatrix();
                GL.glTranslated(rand4, randy4, 0);
                GL.glBindTexture(GL.GL_TEXTURE_2D, texture[7]);
                GL.glBegin(GL.GL_POLYGON);

                // GL.glColor3d(0, 1, 0);
                GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 0.5, 0);
                GL.glTexCoord2d(1, 0); GL.glVertex3d(-1, 0.5, 0);
                GL.glTexCoord2d(1, 1); GL.glVertex3d(-1, -0.5, 0);
                GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -0.5, 0);

                GL.glEnd();
                GL.glPopMatrix();
                score4 = 0;
            }

        }
       
       public void scoree()
        {
           
            if(score1==1)
           {
               GL.glPushMatrix();
               GL.glTranslated(x, -5, 0);
               GL.glBindTexture(GL.GL_TEXTURE_2D, texture[6]);
               GL.glBegin(GL.GL_POLYGON);


               GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 0.5, 0);
               GL.glTexCoord2d(1, 0); GL.glVertex3d(-0.9, 0.5, 0);
               GL.glTexCoord2d(1, 1); GL.glVertex3d(-0.9, -0.5, 0);
               GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -0.5, 0);

               GL.glEnd();
               GL.glPopMatrix();
              
           }
            if (score2 == 2)
            {
                GL.glPushMatrix();
                GL.glTranslated(x+1, -5, 0);
                GL.glBindTexture(GL.GL_TEXTURE_2D, texture[6]);
                GL.glBegin(GL.GL_POLYGON);


                GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 0.5, 0);
                GL.glTexCoord2d(1, 0); GL.glVertex3d(-0.9, 0.5, 0);
                GL.glTexCoord2d(1, 1); GL.glVertex3d(-0.9, -0.5, 0);
                GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -0.5, 0);

                GL.glEnd();
                GL.glPopMatrix();
                
            }
            if (score3 == 3)
            {
                GL.glPushMatrix();
                GL.glTranslated(x+2, -5, 0);
                GL.glBindTexture(GL.GL_TEXTURE_2D, texture[6]);
                GL.glBegin(GL.GL_POLYGON);


                GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 0.5, 0);
                GL.glTexCoord2d(1, 0); GL.glVertex3d(-0.9, 0.5, 0);
                GL.glTexCoord2d(1, 1); GL.glVertex3d(-0.9, -0.5, 0);
                GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -0.5, 0);

                GL.glEnd();
                GL.glPopMatrix();
                
            }
            if (score4 == 4)
            {
                GL.glPushMatrix();
                GL.glTranslated(x + 3, -5, 0);
                GL.glBindTexture(GL.GL_TEXTURE_2D, texture[6]);
                GL.glBegin(GL.GL_POLYGON);


                GL.glTexCoord2d(0, 0); GL.glVertex3d(0, 0.5, 0);
                GL.glTexCoord2d(1, 0); GL.glVertex3d(-0.9, 0.5, 0);
                GL.glTexCoord2d(1, 1); GL.glVertex3d(-0.9, -0.5, 0);
                GL.glTexCoord2d(0, 1); GL.glVertex3d(0, -0.5, 0);

                GL.glEnd();
                GL.glPopMatrix();
               
            }
            
            
            
                  
                
            

        }

        public float step = 2;
        public float step2 = 2;
        public float step3 = 2;
        public float step4 = 2;


        Boolean u5;
        public override void Refresh()
        {
            base.Refresh();
            if (u5 == true)
            {

                step = step - 0.05f;
                step2 = step2 - 0.05f;
                step3 = step3 - 0.05f;
                step4 = step4 - 0.05f;
            }
            if( step <-100&&step2 <-100&&step3 <-100&&step4 <-100)
            {
                
            }
           
            

            
        }


        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            GL.glMatrixMode(GL.GL_PROJECTION);
            GL.gluPerspective(20.0f, (double)Size.Width / (double)Size.Height, 0.1f, 100.0f);
            GL.glMatrixMode(GL.GL_MODELVIEW);
            GL.glLoadIdentity();


        }
        public void onKeyDown(object Sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }

            if (key.KeyCode == Keys.D)
            {
                if (x < 35)
                {
                   
                    x += 0.5f;
                    centerX = x;
                }
            }
            if (key.KeyCode == Keys.A)
            {
                if (x > -35)
                {
                   
                    x -= 0.5f;
                    centerX = x;
                }
                
            }
            if (key.KeyCode == Keys.Q)
            {
                eyeZ = eyeZ + 0.5f;
            }
            if (key.KeyCode == Keys.E)
            {
                eyeZ = eyeZ - 0.5f;
               
            }
            if (key.KeyCode == Keys.D1)
            {
                u = true;
                xx = x;
            }
            if (key.KeyCode == Keys.D2)
            {
                u2 = true;
                xxx = x;
            }
            if (key.KeyCode == Keys.D3)
            {
                u3 = true;
                xxxx = x;
            }
            if (key.KeyCode == Keys.D4)
            {
                u4 = true;
                xxxxx = x;
            }

            if (key.KeyCode == Keys.Space)
            {
                if (u == true && u2 == true && u3 == true && u4 == true)
                {
                    u5 = true;
                }
               
            }
            if (key.KeyCode == Keys.R)
            {

                b = true;
               

            }
            if (key.KeyCode == Keys.T)
            {

                centerX = centerX + 0.5f;

            }
            if (key.KeyCode == Keys.Y) 
            {

               

            }
            

        }
        


    }
}