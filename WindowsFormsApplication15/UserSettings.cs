using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace WindowsFormsApplication15
{
    public partial class Form5 : Form
    {

        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "4nbPNvdASa82MlQddfymR1KH5mhxBrHPja4MQcDI",
            BasePath = "https://fir-b1ecc.firebaseio.com/"
        };

        IFirebaseClient client;

        public Form5()
        {
            InitializeComponent();
            button1.FlatAppearance.BorderSize = 0;
            this.Opacity = 0;
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(pictureBox1.DisplayRectangle);
            pictureBox1.Region = new Region(gp);
            label7.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            label9.Hide();
            label10.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.05;

            if (this.Opacity == 1)
            {
                timer1.Stop();
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.LimeGreen;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.White;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = global::WindowsFormsApplication15.Properties.Resources.icons8_change_theme_48;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = global::WindowsFormsApplication15.Properties.Resources.icons8_change_theme_48__1_;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            label7.Show();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label7.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            textBox2.Show();
            textBox3.Show();
            textBox4.Show();
            pictureBox2.Show();
            pictureBox3.Show();
            pictureBox4.Show();
            pictureBox5.Show();
           
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Tomato;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.ForeColor = Color.LimeGreen;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.White;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.White;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            label9.Show();
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            label9.Hide();
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            label10.Show();
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            label10.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void pictureBox4_Click(object sender, EventArgs e)
        {

            FirebaseResponse resp = await client.GetTaskAsync("Counter/node");
            Counter_class get = resp.ResultAs<Counter_class>();

            var data = new Data
            {
                Id = (Convert.ToInt32(get.cnt) + 1).ToString(),
                Name = textBox1.Text,
                Age = textBox2.Text,
                Instrument = textBox3.Text,
                Genre = textBox4.Text,

               

            };

            SetResponse response = await client.SetTaskAsync("Information/" + data.Id, data);
            Data result = response.ResultAs<Data>();

            MessageBox.Show("Data Inserted" + result.Id);

            var obj = new Counter_class
            {
                cnt = data.Id
            };

            SetResponse respose1 = await client.SetTaskAsync("Counter/node", obj);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
