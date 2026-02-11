using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public class DeviceManager
    {
        private List<SmartDevice> devices;

        public DeviceManager()
        { 
            devices = new List<SmartDevice>();
        }

        public void AddDevice(SmartDevice device)
        {
            
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device), "Adja meg az eszközt");
            }

            if (devices.Any(d => d.Id == device.Id))
            {
                throw new InvalidOperationException($"Már létezik egy eszköz ezzel az ID-vel: {device.Id}");
            }

            devices.Add(device);
        }





    }
}
