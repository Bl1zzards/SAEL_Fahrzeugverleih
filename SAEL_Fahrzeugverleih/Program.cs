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
            for (int i = 0; i < lstRes.Count; i++)
            {
                Console.WriteLine("___________________________________________________________");
                Console.WriteLine($"Reservierung {i + 1}");
                Console.WriteLine("");
                Console.WriteLine($"Id: " + lstRes[i].Id);
                Console.WriteLine($"Beginn: " + lstRes[i].Beginn.ToShortDateString());
                Console.WriteLine($"Ende: " + lstRes[i].Ende.ToShortDateString());
                Console.WriteLine($"Zweck: " + lstRes[i].Zweck);
                Console.WriteLine($"Hersteller: " + lstRes[i].HerstellerName);
                Console.WriteLine($"Modell: " + lstRes[i].ModellName);
                Console.WriteLine($"Kennzeichen: " + lstRes[i].Kennzeichen);
            }
            FahrzeugReservierung f2 = FahrzeugReservierung.GetReservierung(2);
            if (f2.Id > 0)
            {
                Console.WriteLine("___________________________________________________________");
                Console.WriteLine("Ausgewählte Reservierung:");
                Console.WriteLine("");
                Console.WriteLine("Id:" + f2.Id);
                Console.WriteLine($"Beginn: " + f2.Beginn.ToShortDateString());
                Console.WriteLine($"Ende: " + f2.Ende.ToShortDateString());
                Console.WriteLine($"Zweck: " + f2.Zweck);
                Console.WriteLine($"Hersteller: " + f2.HerstellerName);
                Console.WriteLine($"Modell: " + f2.ModellName);
                Console.WriteLine($"Kennzeichen: " + f2.Kennzeichen);
            }
            Console.ReadLine();
        }
    }
    //Eine statische Klasse für Globale Variablen zu erstellen war schneller als sich Daten aus einer app.config zu ziehen... Daher der Ansatz
    static class GlobalVar
    {
        //Connection String: Passwort fehlt
        public static string connectionString = "Data Source=localhost;Initial Catalog=fahrzeugreservierung;Uid=root;pwd=";
    }
}
