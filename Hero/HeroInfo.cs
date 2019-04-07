using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Hero
{
    public enum HeroRoles
    {
        Carry,Support,Durable,Disabler,Melee,Nuker,Initiator,Escape,Jungler,Pusher,Ranged,NotARole
    }
    [Serializable]
    class HeroInfo
    {
        public string heroName;
        public HashSet<HeroRoles> roles;
        public Image heroIcon;
        public Hashtable disadvantages;
        public HeroInfo(string name)
        {
            heroName=name;
            roles = new HashSet<HeroRoles>();
            disadvantages = new Hashtable();
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
