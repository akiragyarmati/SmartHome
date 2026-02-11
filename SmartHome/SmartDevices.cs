using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public abstract class SmartDevice : IComparable<SmartDevice>
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOnline { get; private set; }
        public DateTime LastActive { get; set; }

        protected SmartDevice(int id, string name)
        {
            Id = id;
            Name = name;
            IsOnline = false;
            LastActive = DateTime.MinValue;
        }


        public abstract string GetStatus();

        public void Connect()
        {
            IsOnline = true;
            LastActive = DateTime.Now;
        }

        public void Disconnect()
        {
            IsOnline = false;
        }



        public int CompareTo(SmartDevice? other)
        {
            if (other == null) return 1;
            return this.Id.CompareTo(other.Id);
        }

        public override string? ToString()
        {
            return $"Device ID: {Id}, Name: {Name}, Online: {IsOnline}, Last Active: {LastActive}";
        }
    }
}
