using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using Hero.NetWorking;
using System.Collections.Generic;
using Hero;

namespace HeroTest
{
    [TestClass]
    public class NetTests
    {
        public void setup()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                   SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
        }

        [TestMethod]
        public void HttpWebRequestTest1()
        {
            setup();
            HttpWebRequest request = Net.GetRequest("https://www.dotabuff.com/");
            Assert.AreEqual(((HttpWebResponse)request.GetResponse()).ResponseUri, "https://www.dotabuff.com/");
            Assert.AreEqual(((HttpWebResponse)request.GetResponse()).StatusCode, HttpStatusCode.OK);
        }

        [TestMethod]
        public void GetHeroNameListTest()
        {
            string heroList = "<div class=\"name\">TestHero</div> ThereIsNoHero asdasdsad <div class=\"stake\">AndNoone</div>\n<div class=\"name\">Test's Hero2</div>";
            List<string> actualHeroes = Net.GetHeroesNameList(heroList);
            List<string> expectedHeroes = new List<string> { "TestHero", "Test's Hero2" };
            foreach (string h in actualHeroes)
            {
                Console.WriteLine(h);
            }
            CollectionAssert.AreEqual(actualHeroes, expectedHeroes);
        }

        [TestMethod]
        public void GetHeroRolesListTest()
        {
            setup();
            HashSet<HeroRoles> result = new HashSet<HeroRoles>();
            Net.GetHeroRoles("Pugna", result);
            HashSet<HeroRoles> expected = new HashSet<HeroRoles> { HeroRoles.Ranged, HeroRoles.Nuker, HeroRoles.Pusher };
            Assert.IsTrue(result.SetEquals(expected));
        }

        [TestMethod]
        public void StringToRoleTest()
        {
            string role1 = "Ranged";
            string role2 = "Banged";
            Assert.AreEqual(HeroInfo.ToRole(role1), HeroRoles.Ranged);
            Assert.AreEqual(HeroInfo.ToRole(role2), HeroRoles.NotARole);
        }
    }
}
