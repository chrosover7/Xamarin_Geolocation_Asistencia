using System;
using SQLite;

namespace LocalDatabaseSample.Models
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int    ID        { get; set; }
        public string Name      { get; set; }
        public string LastName  { get; set; }
        public string DNI { get; set; }

        public DateTime hora_fecha { get; set; }
        public string tipo { get; set; }

        public string latitud{ get; set; }

        public string longitud { get; set; }
        public string ubicacion { get; set; }


    }
}
