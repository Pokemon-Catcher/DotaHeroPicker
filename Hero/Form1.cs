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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hero.NetWorking;

namespace Hero
{
    public partial class MainWindow : Form
    {
        private List<string> previousHeroes = new List<string>();
        private List<PictureBox> bestHeroesPictures = new List<PictureBox>();
        private List<PictureBox> enemies=new List<PictureBox>();
        private List<HeroInfo> heroes=new List<HeroInfo>();
        private Task bestHeroUpdate;
        private SemaphoreSlim semaphore = new SemaphoreSlim(1);
        private CancellationTokenSource tokenSource = new CancellationTokenSource();
        private CancellationToken token;
        public MainWindow()
        {
            InitializeComponent();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                       SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
            List<Task> allTasks=new List<Task>();
            token = tokenSource.Token;
            enemies.Add(hero1);
            enemies.Add(hero2);
            enemies.Add(hero3);
            previousHeroes = GetHeroesList();
            enemies.Add(hero4);
            enemies.Add(hero5);
            Directory.CreateDirectory("heroes");
            DialogResult dialogResult = MessageBox.Show("Loading", "Load from disk?", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.No)
            {
                List<string> names = GetHeroesList();
                CreateHeroList(names, heroes);
                allTasks.Add(UpdatePics(heroes,LoadHeroPictures(heroes)));
                allTasks.Add(UpdateRoles(heroes));
                allTasks.Add(UpdateCounters(heroes));
                SaveHeroesInfo(heroes, allTasks);
            }
            else if (dialogResult == DialogResult.Yes)
            {
                UpdatePics(heroes,LoadHeroesInfo(heroes));
            }

        }

        List<string> GetHeroesList()
        {

            HttpWebRequest request = Net.GetRequest("https://dotabuff.com/heroes");
            string page = Net.GetPage(request);
            List<string> names = Net.GetHeroesNameList(page);
            return names;
        }

        void CreateHeroList(List<string> names, List<HeroInfo> heroes)
        {
            Task.Run(()=>{
                semaphore.Wait();
                foreach (string name in names)
                {
                    HeroInfo newHero = new HeroInfo(name);
                    heroes.Add(newHero);
                }
                semaphore.Release();
            });
        }

        async Task LoadHeroPictures(List<HeroInfo> heroes)
        {
            await Task.Run(() =>
            {
                semaphore.Wait();
                foreach (HeroInfo hero in heroes)
                {
                    hero.heroIcon = Net.GetImage("https://dotabuff.com/assets/heroes/" +
                                                 hero.heroName.ToLower().Replace(" ", "-") + ".jpg");
                }
                semaphore.Release();
            });
        }


        async Task UpdateRoles(List<HeroInfo> heroes)
        {
            await Task.Run(() =>
            {
                semaphore.Wait();
                foreach (HeroInfo hero in heroes)
                {
                    Net.GetHeroRoles(hero.heroName, hero.roles);
                }
                semaphore.Release();
            });
        }

        async Task UpdatePics(List<HeroInfo> heroes, Task loadPics=null)
        {

            await Task.Run(() =>
            {
                if (!(loadPics is null))
                {
                   loadPics.Wait();
                }
                int i = 0;
                foreach (HeroInfo hero in heroes)
                {
                    PictureBox pic = new PictureBox();
                    pic.Image = hero.heroIcon;
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
                semaphore.Wait();
                foreach (HeroInfo hero in heroes)
                {
                    Net.GetHeroCounters(hero.heroName, hero.info);
                }
                semaphore.Release();
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

        async Task LoadHeroesInfo(List<HeroInfo> heroes)
        {
            await Task.Run(() =>
            {
                foreach (string filename in Directory.GetFiles("heroes\\"))
                {
                    IFormatter formatter = new BinaryFormatter();
                    Stream stream = new FileStream(filename, FileMode.Open,
                        FileAccess.Read);
                    HeroInfo hero = formatter.Deserialize(stream) as HeroInfo;
                    heroes.Add(hero);
                    stream.Close();
                    Debug.WriteLine( hero.heroName + " loading has been done");
                }
            });
        }


        private void HeroPick(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            if(IsThereSuchEnemy(pic.Tag as HeroInfo)) return;
            foreach (PictureBox enemy in enemies)
            {
                if (!(enemy is null) && enemy.Tag is null)
                {
                    enemy.Image = pic.Image;
                    enemy.Tag = pic.Tag;
                    break;
                }
            }
            if (!(bestHeroUpdate is null))
            {
                bestHeroUpdate.Wait();
            }
            bestHeroUpdate=GetBestHeroes(heroes,token);
        }

        private void HeroUnpick(object sender, EventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            pic.Tag=null;
            pic.Image=null;
            if (!(bestHeroUpdate is null))
            {
                bestHeroUpdate.Wait();
            }
            bestHeroUpdate=GetBestHeroes(heroes,token);
        }

        private async Task GetBestHeroes(List<HeroInfo> heroes, CancellationToken token)
        {

            await Task.Run(() =>
            {
                try
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    foreach (PictureBox pic in bestHeroesPictures)
                    {
                        Invoke(new Action(() =>
                        {
                            bestHeroes.Controls.Remove(pic);
                        }));
                    }

                    HeroComparer comparer = new HeroComparer(enemies, GetWhichInfo());
                    heroes.Sort(comparer);
                    foreach (HeroInfo hero in heroes)
                    {
                        if (IsThereSuchEnemy(hero)) continue;
                        PictureBox pic = new PictureBox();
                        pic.Image = hero.heroIcon;
                        pic.Size = new Size(2 * pic.Image.Width / 5, 2 * pic.Image.Height / 5);
                        pic.SizeMode = PictureBoxSizeMode.Zoom;
                        pic.Tag = hero;
                    Invoke(new Action(() => {
                        ToolTip tip = new ToolTip();
                        string values = "";
                        foreach (PictureBox enemy in enemies)
                        {
                            if (enemy is null || enemy.Tag is null) continue;
                            HeroInfo enemyInfo = enemy.Tag as HeroInfo;
                            values += enemyInfo.heroName + ": " + hero.info[enemyInfo.heroName][GetWhichInfo()] + "\n";
                        }
                        tip.SetToolTip(pic, values);
 ;                        bestHeroes.Controls.Add(pic);
                        
                    }));
                        bestHeroesPictures.Add(pic);
                    }
                }
                catch (InvalidOperationException e)
                {
                    return;
                }
            });
        }

        private bool IsThereSuchEnemy(HeroInfo hero)
        {
            bool passHero=false;
            foreach (PictureBox enemy in enemies)
            {
                if (passHero || enemy.Tag is null) break;
                HeroInfo enemyInfo = enemy.Tag as HeroInfo;
                passHero = enemyInfo.heroName == hero.heroName;
            }

            return passHero;
        }

        private int GetWhichInfo()
        {
            if (ByWinrate.Checked) return 1;
            else return 0;
        }

        private void ByWinrate_CheckedChanged(object sender, EventArgs e)
        {
            if (!(bestHeroUpdate is null))
            {
                bestHeroUpdate.Wait();
            }
            bestHeroUpdate = GetBestHeroes(heroes, token);
        }

    }
}
