using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hero
{
    public enum HeroRoles
    {
        Carry,Support,Durable,Disabler,Melee,Nuker,Initiator,Escape,Jungler,Pusher,Ranged,NotARole
    }

    public class HeroHashtable : Hashtable
    {
    }

    public class HeroComparer : IComparer<HeroInfo>
    {
        public List<PictureBox> enemies;
        public int info = 0;

        public HeroComparer(List<PictureBox> enemies, int whichInfo)
        {
            this.enemies = enemies;
            info = whichInfo;
        }

        int IComparer<HeroInfo>.Compare(HeroInfo x, HeroInfo y)  
        {
            float weightX = 0, weightY = 0;
            foreach (PictureBox enemy in enemies)
            {
                Debug.WriteLine(x.heroName);
                HeroInfo enemyInfo = enemy.Tag as HeroInfo;
                if (enemyInfo is null || x.heroName == enemyInfo.heroName || y.heroName == enemyInfo.heroName) continue;
                weightX += enemyInfo.info[x.heroName][info];
                weightY += enemyInfo.info[y.heroName][info];
            }

            if (weightX > weightY) return 1;
            else if (weightX == weightY) return 0;
            return -1;
        }
    }

    [Serializable]
    public class HeroInfo
    {
        public string heroName;
        public HashSet<HeroRoles> roles;
        public Image heroIcon;
        public Dictionary<string, List<float>> info;
        public HeroInfo(string name)
        {
            heroName=name;
            roles = new HashSet<HeroRoles>();
            info = new Dictionary<string, List<float>>();
        }

        public static HeroRoles ToRole(string role)
        {
            switch (role.ToLower())
            {
                case "carry":
                    return HeroRoles.Carry;
                case "support":
                    return HeroRoles.Support;
                case "durable":
                    return HeroRoles.Durable;
                case "melee":
                    return HeroRoles.Melee;
                case "nuker":
                    return HeroRoles.Nuker;
                case "initiator":
                    return HeroRoles.Initiator;
                case "escape":
                    return HeroRoles.Escape;
                case "jungler":
                    return HeroRoles.Jungler;
                case "pusher":
                    return HeroRoles.Pusher;
                case "ranged":
                    return HeroRoles.Ranged;
                case "disabler":
                    return HeroRoles.Disabler;
                default:
                    return HeroRoles.NotARole;
            }
        }
    }
}
