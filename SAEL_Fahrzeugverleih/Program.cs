using System;
using System.Collections.Generic;

namespace SAEL_Fahrzeugverleih
{
    class Program
    {
        static void Main(string[] args)
        {
            List<FahrzeugReservierung> lstRes = FahrzeugReservierung.GetListOfReservierungen();
            Console.WriteLine("Anzahl Reservierungen: " + lstRes.Count);
            if (lstRes.Count > 0)
            {
                Console.WriteLine("Reservierung 1 - Id: " + lstRes[0].Id);
                Console.WriteLine("Reservierung 1 - Kennzeichen: " + lstRes[0].Kennzeichen);
            }
            Console.WriteLine("___________________________________________________________");

            FahrzeugReservierung f2 = FahrzeugReservierung.GetReservierung(2);
            if (f2.Id > 0)
            {
                Console.WriteLine("Ausgewählte Reservierung - Id: " + f2.Id);
                Console.WriteLine("Ausgewählte Reservierung - Kennzeichen: " + f2.Kennzeichen);
            }
            Console.ReadLine();
        }
    }

    static class GlobalVar
    {
        //Connection String: Hier Passwort abändern
        public static string connectionString = "Data Source=localhost;Initial Catalog=fahrzeugreservierung;Uid=root;pwd=test123";
    }
}
