using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_1024
{
    public partial class Form1 : Form
    {
        int rhoc;
        int rhop;
        int k1 = 10;
        int k2 = 30;
        public static Boolean toomanypeople = false;
        int picturestate = 1;


        /// <summary>
        /// Delay 함수 MS
        /// </summary>
        /// <param name="MS">(단위 : MS)
        ///
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        public Form1()
        {
            InitializeComponent();
            textBox3.Select();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rhoc = Convert.ToInt32(textBox1.Text);
            rhop = Convert.ToInt32(textBox2.Text);

            if (k1>rhop && Math.Abs(rhoc-rhop) > k2)
            {
                toomanypeople = true;
            }
            else
            {
                toomanypeople = false;
            }

            label1.Text = Convert.ToString(toomanypeople);


            if (picturestate == 1 && toomanypeople == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    pictureBox1.Image = Properties.Resources.scene2;
                    Delay(300);
                    pictureBox1.Image = Properties.Resources.scene1;
                    Delay(300);
                }

                pictureBox1.Image = Properties.Resources.scene3;

                picturestate = 3;
                    
                
            }
            else if (picturestate == 3 && toomanypeople == false)
            {

                for (int i = 0; i < 10; i++)
                {
                    pictureBox1.Image = Properties.Resources.scene4;
                    Delay(300);
                    pictureBox1.Image = Properties.Resources.scene3;
                    Delay(300);
                } 

                pictureBox1.Image = Properties.Resources.scene1;

                picturestate = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(textBox3.Text)<5 || Convert.ToInt32(textBox3.Text) >10)
            {
                toomanypeople = false;
                k1 = 3;
                k2 = 45;
            }
            else
            {
                toomanypeople = true;
                k2 = 15;
                k1 = 20;
            }
        }
    }
}
