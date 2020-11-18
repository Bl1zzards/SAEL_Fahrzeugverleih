using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Linq;

namespace SAEL_Fahrzeugverleih
{
    class FahrzeugReservierung
    {
        public int Id { get; set; }
        public DateTime Beginn { get; set; }
        public DateTime Ende { get; set; }
        public string Zweck { get; set; }
        public string HerstellerName { get; set; }
        public string ModellName { get; set; }
        public string Kennzeichen { get; set; }
        public FahrzeugReservierung(int id, DateTime beginn, DateTime ende)
        {
            Id = id;
            Beginn = beginn;
            Ende = ende;
        }

        public FahrzeugReservierung()
        {
            List<FahrzeugReservierung> lstRes = new List<FahrzeugReservierung>();
        }

        //Holt sich EINE Reservierung anhand der mitgegebenen ID.
        public static FahrzeugReservierung GetReservierung(int id)
        {
            List<FahrzeugReservierung> lstReturn = new List<FahrzeugReservierung>();
            string sSQL = "select r.id as reservierung_id, r.beginn, r.ende, r.zweck,h.name as herstellername,m.modellname, f.kennzeichen ";
            sSQL += "from reservierung as r ";
            sSQL += "inner join fahrzeug as f on r.fahrzeug_id = f.id ";
            sSQL += "inner join fahrzeugmodell as m on f.modell_id = m.id ";
            sSQL += "inner join fahrzeughersteller as h on m.hersteller_id = h.id ";
            sSQL += $"Where r.id={id}; ";


            MySqlConnection connection = new MySqlConnection(GlobalVar.connectionString);
            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sSQL, connection);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    FahrzeugReservierung res = new FahrzeugReservierung();
                    res.Id = rdr.GetInt32("reservierung_id");
                    res.Beginn = rdr.GetDateTime("beginn");
                    res.Ende = rdr.GetDateTime("ende");
                    res.Zweck = rdr.GetString("zweck");
                    res.HerstellerName = rdr.GetString("herstellername");
                    res.ModellName = rdr.GetString("modellname");
                    res.Kennzeichen = rdr.GetString("kennzeichen");
                    lstReturn.Add(res);
                }
                connection.Close();
            }
            return lstReturn.FirstOrDefault();
        }

        //Holt sich die List ALLER Reservierungen
        public static List<FahrzeugReservierung> GetListOfReservierungen()
        {
            List<FahrzeugReservierung> lstReturn = new List<FahrzeugReservierung>();
            string sSQL = "select r.id as reservierung_id, r.beginn, r.ende, r.zweck,h.name as herstellername,m.modellname, f.kennzeichen ";
            sSQL += "from reservierung as r ";
            sSQL += "inner join fahrzeug as f on r.fahrzeug_id = f.id ";
            sSQL += "inner join fahrzeugmodell as m on f.modell_id = m.id ";
            sSQL += "inner join fahrzeughersteller as h on m.hersteller_id = h.id ";

            MySqlConnection connection = new MySqlConnection(GlobalVar.connectionString);
            using (connection)
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(sSQL, connection);
                using MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    FahrzeugReservierung res = new FahrzeugReservierung();
                    res.Id = rdr.GetInt32("reservierung_id");
                    res.Beginn = rdr.GetDateTime("beginn");
                    res.Ende = rdr.GetDateTime("ende");
                    res.Zweck = rdr.GetString("zweck");
                    res.HerstellerName = rdr.GetString("herstellername");
                    res.ModellName = rdr.GetString("modellname");
                    res.Kennzeichen = rdr.GetString("kennzeichen");
                    lstReturn.Add(res);
                }
                connection.Close();
            }
            return lstReturn;
            }
    }
}
