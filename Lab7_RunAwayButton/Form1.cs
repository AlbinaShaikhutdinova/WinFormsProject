using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Lab7_RunAwayButton
{
    public partial class Form1 : Form
    {

        //Сделай костыль для момента когда кнопка у границы формы
        // она не должна оставаться ровно на границе
        Point point1;
 
        private Size FormOrig;
        private Point but1Orig;
        private Timer MoveTimer = new Timer();

        int r;
        int x;
        int y;
        int dx ;
        int dy;

        public Form1()
        {
            InitializeComponent();
            button1.Location = new Point((ClientSize.Width / 2 - button1.Width/2),
                (ClientSize.Height / 2 - button1.Height/2));
            MoveTimer.Interval = 1000;
            MoveTimer.Tick += new System.EventHandler(MoveTimer_Tick);
        }
     
        private void MoveTimer_Tick(object sender, EventArgs e)
        {
           
            r = 10;
            // Вектор направления движения
             x = Math.Abs(point1.X - button1.Location.X);
             y = Math.Abs(point1.Y - button1.Location.Y);
            // Двигаться никуда не нужно, защита от деления на 0
            if (x == 0 && y == 0) return;
            // Длина вектора
            double k = Math.Sqrt(x * x + y * y);
            // Вектор заданного направления с желаемой длиной
            dx = (int)(r * x / k);
            dy = (int)(r * y / k);
            // button1.Location = new Point(button1.Location.X - dx, button1.Location.Y - dy);
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            MoveTimer.Start();
            if (e.X >= button1.Location.X - 30 & e.X <= button1.Location.X + button1.Width + 30
                & e.Y >= button1.Location.Y - 30 & e.Y <= button1.Location.Y + 30)
            {
             
             point1 = new Point(e.X, e.Y);
              
              
                if ((e.X >= button1.Location.X + button1.Width / 2) & (button1.Left > 0))
                {

                    button1.Location = new Point(button1.Location.X - dx, button1.Location.Y);
                    
                }
                 if ((e.X <= button1.Location.X + button1.Width / 2) & 
                    (button1.Left+button1.Width < ClientSize.Width))
                 { 
                    button1.Location = new Point(button1.Location.X + dx, button1.Location.Y);
                  
                 }

                if ((e.Y >= button1.Location.Y + button1.Height / 2) & (button1.Top > 0 ))
                {
                    button1.Location = new Point(button1.Location.X, button1.Location.Y - dy);
                    
                }

                if ((e.Y <= button1.Location.Y + button1.Height / 2) & 
                    (button1.Top + button1.Height < ClientSize.Height))
                { button1.Location = new Point(button1.Location.X, button1.Location.Y + dy); }
                   
            }

            //MoveTimer.Stop();
            but1Orig = button1.Location;
            FormOrig = ClientSize;
        }
         
        
        private void Form1_Load(object sender, EventArgs e)
        {
            FormOrig =ClientSize;
            
            but1Orig = new Point(button1.Location.X, button1.Location.Y);

        }
        private void ResizeChildrenControls()
        {
            ResizeControl(but1Orig, button1);
        }
        private void ResizeControl(Point OrigPlace, Control control)
        {
            int newX;
            int newY;

            float xratio = (float)(ClientSize.Width) / (float)(FormOrig.Width);
            float yratio = (float)(ClientSize.Height) / (float)(FormOrig.Height);

            if (OrigPlace.X <= 0)
                newX = 0;
            else if (OrigPlace.X >= FormOrig.Width - button1.Width)
                newX = ClientSize.Width - button1.Width;
            else newX = (int)(OrigPlace.X * xratio);

            if (OrigPlace.Y <= 0)
                newY = 0;
            else if (OrigPlace.Y >= FormOrig.Height - button1.Height)
                newY = ClientSize.Height - button1.Height;
            else newY = (int)(OrigPlace.Y * yratio);

            control.Location = new Point(newX, newY);
            
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
         
            ResizeChildrenControls();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Congratulations! You have caught the button!");
            button1.Location = new Point((ClientSize.Width / 2 - button1.Width / 2),
              (ClientSize.Height / 2 - button1.Height / 2));
        }
    }
}
