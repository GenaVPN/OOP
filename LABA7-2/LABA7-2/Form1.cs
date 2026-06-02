using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LABA7_2
{
    public partial class Form1 : Form
    {
        
        Bitmap bmp;
        String fig = "линия";
        uint width = 1;

        List<Shape> shapes = new List<Shape>();
        List<Point> Points = new List<Point>();
        Shape selectedShape = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void paintPixels(Bitmap bmp, int i0 = 0, int j0 = 0)
        {
            if (i0 + 8 >= bmp.Width || j0 + 8 >= bmp.Height)
                return;
            Color c = bmp.GetPixel(i0 + 4, j0 + 4);
        
            for (int i = i0; i < i0 + 9; i++)
            {
                for (int j = j0; j < j0 + 9; j++)
                {
                    bmp.SetPixel(i, j, c);
                }
            }
        }

      
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                bmp = new Bitmap(pictureBox1.Image);

               
                for (int i = 0; i < bmp.Width; i++)
                    for (int j = 0; j < bmp.Height; j++)
                    {
                       
                        int R = bmp.GetPixel(i, j).R;
                      
                        int G = bmp.GetPixel(i, j).G;
              
                        int B = bmp.GetPixel(i, j).B;
                     
                        int Gray = (R + G + B) / 3;
                    
                        Color p = Color.FromArgb(255, Gray, Gray,
                            Gray);
                        
                        bmp.SetPixel(i, j, p);
                    }

                Image oldImage = pictureBox1.Image; 
                pictureBox1.Image = bmp;         
                oldImage.Dispose();

                pictureBox1.Refresh();
                
            }
            catch (Exception)
            {

                return;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                bmp = new Bitmap(pictureBox1.Image);

                int sizeX = bmp.Width;
                int sizeY = bmp.Height;
                for (int i = 0; i < sizeX; i += 9)
                {
                    for (int j = 0; j < sizeY; j += 9)
                    {

                        paintPixels(bmp, i, j);
                    }
                }
                Image oldImage = pictureBox1.Image;
                pictureBox1.Image = bmp;
                oldImage.Dispose();
                pictureBox1.Refresh();

            }
            catch (Exception)
            {

                return;
            }


        }


       

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

       

        
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            Point point = new Point(e.X, e.Y);
            Points.Add(point);
            if (Points.Count == 2)
            {
                
                AddShape(Points[0], Points[1]);
                pictureBox1.Invalidate();
                Points.Clear();
                
                
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            fig = "линия";
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox4.BorderStyle = BorderStyle.None;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fig = "круг";
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
            pictureBox4.BorderStyle = BorderStyle.None;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            fig = "прямоугольник";
            pictureBox2.BorderStyle = BorderStyle.None;
            pictureBox3.BorderStyle = BorderStyle.None;
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
        }

       

        private void panel2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                panel2.BackColor = selectedColor;
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Color selectedColor = colorDialog1.Color;
                panel3.BackColor = selectedColor;
            }
            colorDialog1.Dispose();
        }

        private void buttonSave(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG|*.png|JPEG|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(sfd.FileName);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            width = (uint)numericUpDown1.Value;
        }




        private void buttonMove_click(object sender, EventArgs e)
        {
            var s = shapes[shapes.Count - 1];
            if (s == null) return;

            int dx = 20, dy = 20;

            s.P1 = new Point(s.P1.X + dx, s.P1.Y + dy);
            s.P2 = new Point(s.P2.X + dx, s.P2.Y + dy);

            pictureBox1.Invalidate();
        }

        private void buttonSize_Click(object sender, EventArgs e)
        {
            var s = shapes[shapes.Count - 1];
            if (s == null) return;

            float k;
            try
            {
                k = float.Parse(textBoxSize.Text);
            }
            catch (Exception)
            {

                return;
            }

            Point c = new Point(
                (s.P1.X + s.P2.X) / 2,
                (s.P1.Y + s.P2.Y) / 2);

            s.P1 = new Point(
                (int)(c.X + (s.P1.X - c.X) * k),
                (int)(c.Y + (s.P1.Y - c.Y) * k));

            s.P2 = new Point(
                (int)(c.X + (s.P2.X - c.X) * k),
                (int)(c.Y + (s.P2.Y - c.Y) * k));

            pictureBox1.Invalidate();
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            if (shapes.Count == 0) return;

            Shape s = shapes.Last();

            s.Angle += (float)numericUpKUKUHA.Value;

            pictureBox1.Invalidate();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
            }

            pictureBox1.Image = bmp;
        }

        private void AddShape(Point p1, Point p2)
        {
            shapes.Add(new Shape
            {
                Type = fig,
                P1 = p1,
                P2 = p2,
                PenColor = panel2.BackColor,
                FillColor = panel3.BackColor,
                Width = (int)width,
                Fill = CheckBoxFILL.Checked,
                Angle = 0
            });
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Shape s in shapes)
            {
                using (Pen pen = new Pen(s.PenColor, s.Width))
                using (Brush brush = new SolidBrush(s.FillColor))
                {
                    Rectangle req = GetRect(s.P1, s.P2);

                    Point center = new Point(
                        req.X + req.Width / 2,
                        req.Y + req.Height / 2);

                    GraphicsState state = e.Graphics.Save();

                    e.Graphics.TranslateTransform(center.X, center.Y);
                    e.Graphics.RotateTransform(s.Angle);
                    e.Graphics.TranslateTransform(-center.X, -center.Y);

                    switch (s.Type)
                    {
                        case "линия":
                            e.Graphics.DrawLine(pen, s.P1, s.P2);
                            break;

                        case "круг":
                            if (s.Fill)
                                e.Graphics.FillEllipse(brush, req);
                            e.Graphics.DrawEllipse(pen, req);
                            break;

                        case "прямоугольник":
                            if (s.Fill)
                                e.Graphics.FillRectangle(brush, req);
                            e.Graphics.DrawRectangle(pen, req);
                            break;
                    }

                    e.Graphics.Restore(state);
                }
            }
        }

        private Rectangle GetRect(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }
    }


}