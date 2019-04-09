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
        List<PictureBox> enemies=new List<PictureBox>();
        public MainWindow()
        {
            List<HeroInfo> heroes=new List<HeroInfo>();
            List<Task> allTasks=new List<Task>();
            InitializeComponent();
            enemies.Add(hero1);
            enemies.Add(hero2);
            enemies.Add(hero3);
            enemies.Add(hero4);
            enemies.Add(hero5);
            Directory.CreateDirectory("heroes");
            List<string> names = GetHeroesList();            
            CreateHeroList(names, heroes);
            allTasks.Add(UpdatePics(heroes));
            allTasks.Add(UpdateRoles(heroes));
            allTasks.Add(UpdateCounters(heroes));
            SaveHeroesInfo(heroes, allTasks);
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

        void CreateHeroList(List<string> names, List<HeroInfo> heroes)
        {
            foreach (string name in names)
            {
                HeroInfo newHero = new HeroInfo(name);
                heroes.Add(newHero);
            }
        }

        async Task UpdateRoles(List<HeroInfo> heroes)
        {
            await Task.Run(() =>
            {
                foreach (HeroInfo hero in heroes)
                {
                    Net.GetHeroRoles(hero.heroName, hero.roles);
                }
            });
        }

        async Task UpdatePics(List<HeroInfo> heroes)
        {
            await Task.Run(() =>
            {
                int i = 0;
                foreach (HeroInfo hero in heroes)
                {
                    PictureBox pic = new PictureBox();
                    pic.Image = Net.GetImage("https://dotabuff.com/assets/heroes/" + hero.heroName.ToLower() + ".jpg");
                    hero.heroIcon = pic.Image;
                    pic.Size = new Size(2 * pic.Image.Width / 5, 2 * pic.Image.Height / 5);
                    pic.SizeMode = PictureBoxSizeMode.Zoom;
                    pic.DoubleClick += new EventHandler(HeroPick);
                    pic.Tag=hero;
                    Invoke(new Action(() => HeroList.Controls.Add(pic)));
                    i++;
                }
            });
        }

        async Task UpdateCounters(List<HeroInfo> heroes)
        {
            await Task.Run(() =>
            {
                foreach (HeroInfo hero in heroes)
                {
                    Net.GetHeroCounters(hero.heroName, hero.info);
                }
            });
        }

        async void SaveHeroesInfo(List<HeroInfo> heroes, List<Task> allTasks)
        {
            await Task.WhenAll(allTasks);
            await Task.Run(() =>
            {
                foreach (HeroInfo hero in heroes)
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream("heroes\\" + hero.heroName + ".txt", FileMode.Create,
                        FileAccess.Write);
                    formatter.Serialize(stream, hero);
                    stream.Close();
                    Debug.WriteLine(hero.heroName + " writing has been done");
                }
            });
        }

        private void HeroPick(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            foreach (PictureBox enemy in enemies)
            {
                if (!(enemy is null) && enemy.Tag is null)
                {
                    enemy.Image = pic.Image;
                    enemy.Tag = pic.Tag;
                    break;
                }
            }
        }

        private void HeroUnpick(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Tag=null;
            pic.Image=null;
        }
        

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void Roles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
