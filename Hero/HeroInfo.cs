using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Hero
{
    public enum HeroRoles
    {
        Carry,Support,Durable,Melee,Nuker,Initiator,Escape,Jungler,Pusher,Ranged
    }
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
    }
}
