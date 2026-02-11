using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    //Lámpa
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

    //Termosztát
    public class SmartThermostat : SmartDevice, ISensor
    {
        public double CurrentTemperature { get; private set; }

        public double TargetTemperature { get; private set; } = 22.0;


        public SmartThermostat(int id, string name, double currentTemprature) : base(id, name)
        {
            CurrentTemperature = currentTemprature;
        }

        public double GetData()
        {
            if (!IsOnline)
            {
                Console.WriteLine($"Hiba a/az {Name} offline!");
                return 0.0;
            }

            LastActive = DateTime.Now;
            return CurrentTemperature;
        
        }

        public void Calibrate()
        {
            if (!IsOnline) return;
            Console.WriteLine($"{Name} kalibrálása folyamatban");
            LastActive = DateTime.Now;
        }

        public void SetTargetTemperature(double target)
        {
            if (!IsOnline)
            {
                Console.WriteLine($"Hiba a/az {Name} offline!");
                return;
            }

            TargetTemperature = target;
        }

        public void SetCurrentTemperature(double temp)
        {
            if (!IsOnline)
            {
                Console.WriteLine($"Hiba a/az {Name} offline!");
                return;
            }

            CurrentTemperature = temp;
        }

        public override string GetStatus()
        {
            string active = CurrentTemperature < TargetTemperature ? "Fűt" : "Készenlét";
            return $"Hőmérséklet: {CurrentTemperature} fok, (Cél: {TargetTemperature} fok) -> {active}";
        }
    }
}
