using System; 
using NUnit.Framework;
using SmartHome;
using System.Reflection;

namespace SmartHome_Tests
{
    [TestFixture]
    public class AtfogoTesztek
    {
        private DeviceManager T_manager;

        [SetUp]
        public void Alaphelyzet()
        {
            T_manager = new DeviceManager();
        }

        [Test]
        public void Redony_Ertek_Teszt()
        {
            var redony = new SmartBlinds(1, "teszt redõny");
            redony.Connect();

            redony.SetLevel(150);
            int tulNagyErtek = redony.OpenPercentage;

            redony.SetLevel(-20);
            int tulKicsiErtek = redony.OpenPercentage; 

            Assert.That(tulNagyErtek, Is.EqualTo(100), "Az érték nem maradt 50%-on, amikor túl nagy értéket adtunk meg."); 
            Assert.That(tulKicsiErtek, Is.EqualTo(0), "Az érték nem maradt 0%-on, amikor túl kicsi értéket adtunk meg.");
        }


        [Test]
        public void DupliklatID_Teszt()
        {
            var lampa1 = new SmartLight(1, "Lámpa 1");
            var lampa2 = new SmartLight(1, "Lámpa 2");
            lampa1.Connect();
            lampa2.Connect();
            T_manager.AddDevice(lampa1); 
            

            var ex = Assert.Throws<InvalidOperationException>(() => T_manager.AddDevice(lampa2));

            Assert.That(ex.Message, Is.EqualTo("Már létezik egy eszköz ezzel az ID-vel: 1"));

        }

        [Test]
        public void ZeneLejatszoTeszt()
        { 
            var hangszoro = new MusicHub(1, "Nappali Hnagszóró"); 
            hangszoro.Connect();

            Song zene = new Song("ahogy elképzeltem", "30Y", 3.5);

            hangszoro.PlayMusic(zene);
            Assert.That(hangszoro.CurrentSong, Is.EqualTo(zene), "A lejátszott dal nem egyezik a megadott dallal.");
        }

        [Test]
        public void OkosLampaKategoriaAttrbutumTeszt()
        { 
            Type tipus = typeof(SmartLight);
            var attr = (DeviceCategoryAttribute)Attribute.GetCustomAttribute(tipus, typeof(DeviceCategoryAttribute));
            Assert.That(attr, Is.Not.Null, "A SmartLight osztályon nincs DeviceCategoryAttribute.");
            Assert.That(attr.Category, Is.EqualTo("Világítás"), "A SmartLight kategória neve nem 'Világítás'."); 
            Assert.That(attr.SecurityLevel, Is.EqualTo(2), "A SmartLight biztonsági szintje nem 2.");

        }

        [Test]
        public void EszkozOffline()
        {
            SmartLight lampa = new SmartLight(101, "offline lámpa");

            lampa.TurnOn();

            Assert.That(lampa.Brightness, Is.EqualTo(0));

        }

    }
}