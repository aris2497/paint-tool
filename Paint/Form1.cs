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

namespace Paint
{
    public partial class Form1 : Form
    {
        Pen MyPen;
        Graphics g = null;

        int x = -1;
        int y = -1;

        private bool pressed = false;
        private bool draw = false;
        private bool erase = false;

        //erasing tools
        private Rectangle rect;
        private Size size = new Size(5, 5);

        public Form1()
        {
            InitializeComponent();
            MyPen = new Pen(Color.Red, 5);
            g = canvas.CreateGraphics(); //creates the Graphics for the Control

        }

        private void erase_btn_Click(object sender, EventArgs e)
        {
            erase = true;
            draw = false;

        }

        private void stop_btn_Click(object sender, EventArgs e)
        {
            draw = false;
            erase = false;
        }

        private void start_btn_Click(object sender, EventArgs e)
        {
            draw = true;

            erase = false;
        }

        private void canvas_MouseClick(object sender, MouseEventArgs e) //ocurs when the mouse button is realised
        {
            pressed = false;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e) //occurs when the mouse button is pressed
        {
            pressed = true;
            x = e.X;
            y = e.Y;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e) //occurs when the mouse is moving
        {
            rect = new Rectangle(e.Location, size);

            if (pressed & draw)
            {
                g.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias; //smoothing the lines
                g.DrawLine(MyPen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
            else if (erase & pressed)
            {
                canvas.Invalidate(rect, false);
            }
        }

        private void DrawPointer(Rectangle rect)
        {
            g.DrawRectangle(MyPen, rect);

        }

        private void DisplayEraser(Rectangle rect)
        {
            g.DrawRectangle(MyPen, rect); //area to erase
            
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            canvas.Invalidate(); //clear the canvas
        }
    }
}
