using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication15
{
    public partial class PlaySong : Form
    {
        public PlaySong()
        {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void PlaySong_Load(object sender, EventArgs e)
        {
            button1.FlatAppearance.BorderSize = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.05;

            if (this.Opacity == 1)
            {
                timer1.Stop();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
