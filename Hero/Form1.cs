using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Hero.NetWorking;

namespace Hero
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            List<HeroInfo> heroes=new List<HeroInfo>();
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            HttpWebRequest request= Net.GetRequest("https://dotabuff.com/heroes");
            string page=Net.GetPage(request);
            List<string> names=Net.GetHeroesNameList(page);
            int i = 0;
            foreach (string name in names)
            {
                PictureBox pic = new PictureBox();
                heroes.Add(new HeroInfo(name));
                pic.Image = Net.GetImage("https://dotabuff.com/assets/heroes/" + name.ToLower() + ".jpg");
                pic.Size = new Size(2*pic.Image.Width/5, 2*pic.Image.Height/5);
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                HeroList.Controls.Add(pic);
                i++;
            }

            foreach (HeroInfo hero in heroes)
            {

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
