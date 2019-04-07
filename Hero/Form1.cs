using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hero.NetWorking;

namespace Hero
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            List<HeroInfo> heroes;
            InitializeComponent();
            Directory.CreateDirectory("heroes");
            List<string> names = GetHeroesList();
            UpdateInfo(names);
        }

        List<string> GetHeroesList()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                                   SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            HttpWebRequest request = Net.GetRequest("https://dotabuff.com/heroes");
            string page = Net.GetPage(request);
            List<string> names = Net.GetHeroesNameList(page);
            return names;
        }

        async void UpdateInfo(List<string> names)
        {
            List<HeroInfo> heroes = new List<HeroInfo>();
            await Task.Run(() =>
            {
                int i = 0;
                foreach (string name in names)
                {
                    PictureBox pic = new PictureBox();
                    HeroInfo newHero = new HeroInfo(name);
                    heroes.Add(newHero);
                    pic.Image = Net.GetImage("https://dotabuff.com/assets/heroes/" + name.ToLower() + ".jpg");
                    newHero.heroIcon = pic.Image;
                    pic.Size = new Size(2 * pic.Image.Width / 5, 2 * pic.Image.Height / 5);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    Invoke(new Action(() => HeroList.Controls.Add(pic)));
                    i++;
                }
            });

            await Task.Run(() =>
            {
                foreach (HeroInfo hero in heroes)
                {
                    Net.GetHeroRoles(hero.heroName, hero.roles);
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("heroes\\" + hero.heroName + ".txt", FileMode.Create,
                        FileAccess.Write);
                    formatter.Serialize(stream, hero);
                    stream.Close();
                }
            });
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

        private void Roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
