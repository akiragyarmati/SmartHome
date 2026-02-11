using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public class SmartLight : SmartDevice, ISwitchable
    {
        public int Brightness { get; set; }
        public SmartLight(int id, string name) : base(id, name)
        {
            Brightness = 0;
        }
        
        public void TurnOn()
        {

            if (!IsOnline)
            {
                Console.WriteLine($"Hiba a/az {Name} offline!");
                return;
            }


            Brightness = 100;
            LastActive = DateTime.Now;
        }

        public void TurnOff()
        {
            if (!IsOnline)
            {
                Console.WriteLine($"Hiba a/az {Name} offline!");
                return;
            }

            Brightness = 0;
            LastActive = DateTime.Now;
        }

        public override string GetStatus()
        {
            return $"Lámpa fényereje: {Brightness}%";
        }

    }


    
}
