using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace VideoBD.Model
{
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(250)]
        public String nombre { get; set; }

        [MaxLength(250)]
        public String descripcion { get; set; }

        [MaxLength(250)]
        public String path { get; set; }
    }
}
