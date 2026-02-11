using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{
    public interface ISwitchable
    {
        void TurnOn();
        void TurnOff();
    }

    public interface ISensor
    {
        double GetData();
        void Calibrate();
    }


}
