using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7_ColorPalette
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       /* private Rectangle PanOrig;
       

        private Size FormOrig;

        private void Form1_Load(object sender, EventArgs e)
        {
            FormOrig = this.Size;
            PanOrig = new Rectangle(panel1.Location.X, panel1.Location.Y,
                panel1.Width, panel1.Height);          
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            ResizeChildrenControls();
        }
        private void ResizeChildrenControls()
        {
           
            ResizeControl(PanOrig, panel1);
        }
        private void ResizeControl(Rectangle OrigSize, Control control)
        {
            float xratio = (float)(this.Width) / (float)(FormOrig.Width);
            float yratio = (float)(this.Height) / (float)(FormOrig.Height);

            int newX = (int)(OrigSize.X * xratio);
            int newY = (int)(OrigSize.Y * yratio);
            int newW = (int)(OrigSize.Width * xratio);
            int newH = (int)(OrigSize.Height * yratio);

            control.Location = new Point(newX, newY);
            control.Size = new Size(newW, newH);
        }*/

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(trackBar1.Value,trackBar2.Value,trackBar3.Value);
            Clipboard.SetText("#" + trackBar1.Value.ToString("X2") +
                trackBar2.Value.ToString("X2") + trackBar3.Value.ToString("X2"));
           // string color = Clipboard.GetText();
        }

        private void panel1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("#" + trackBar1.Value.ToString("X2") + 
                trackBar2.Value.ToString("X2") + trackBar3.Value.ToString("X2"),panel1);
        }

       
    }
}
