namespace SmartHome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Okosotthon indítása");

            DeviceManager manager = new DeviceManager();

            try
            { 
                SmartLight nappaliLampa = new SmartLight(1,"Nappali Lámpa");
                SmartThermostat furdoszobaThermo = new SmartThermostat(2,"Fürdőszoba Termosztát", 20.5);

                nappaliLampa.Connect();
                furdoszobaThermo.Connect();

                manager.AddDevice(nappaliLampa);
                manager.AddDevice(furdoszobaThermo);

                Console.WriteLine("Vezérlés teszt:");

                nappaliLampa.TurnOn();
                Console.WriteLine(nappaliLampa.GetStatus());

                furdoszobaThermo.SetTargetTemperature(24.0);
                Console.WriteLine(furdoszobaThermo.GetStatus());

                manager.ListAllDevices();


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }




        }
    }
}
