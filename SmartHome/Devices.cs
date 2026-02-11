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



    public class SmartBlinds : SmartDevice
    { 
        public int OpenPercentage { get; private set; }

        public SmartBlinds(int id, string name) : base(id, name)
        {
            OpenPercentage = 100;
        }

        public void SetLevel(int percentage)
        {
            if (!IsOnline) return;

            if (percentage < 0) percentage = 0;
            if (percentage > 100) percentage = 100;

            OpenPercentage = percentage;
            LastActive = DateTime.Now;
        
        }

        public override string GetStatus()
        {
            return $"Redőny állása: {OpenPercentage}%";
        }
    }

    public class MusicHub : SmartDevice, ISwitchable
    { 
        //Tömbbegyűjetni a zenéket, mint memória, max. 5 szám

        public int Volume { get; private set; }
        public Song? CurrentSong { get; private set; }

        public MusicHub(int id, string name) : base(id, name)
        { 
            
        }

        public void TurnOn()
        { 
            if (!IsOnline) return;
            Console.WriteLine($"{Name} Bekapcsolva");
        }

        public void TurnOff()
        { 
            CurrentSong = null;
        }

        public void PlayMusic(Song song)
        {
            if (!IsOnline) return;

            CurrentSong = song;
            LastActive = DateTime.Now;
            Console.WriteLine(CurrentSong.ToString);

        }

        public void SetVolume(int vol)
        {
            if (vol < 0) vol = 0;
            if (vol > 100) vol = 100;
            Volume = vol;
        }

        public override string GetStatus()
        {
            string songInfo = CurrentSong != null ? CurrentSong.ToString() : "---";
            return songInfo;

        }

    }


}
