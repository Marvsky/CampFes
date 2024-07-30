using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CampFes.Models.System
{
    public class ErrorLog
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? MACHINE_NAME { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? TIMESTAMP { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string? LOGLEVEL { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string? LOGGER { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? CALLSITE { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? MESSAGE { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string? EXCETION { get; set; }

    }
}
