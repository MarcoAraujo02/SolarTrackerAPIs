using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolarTrackerAPIs.Models
{
    public class RegistroEnergia
    {
        [Key]
        public int idRegistroEnergia { get; set; }

        [Column("dt_registro")]
        public DateTime DataRegistro { get; set; } = DateTime.Now;

        [Column("nr_consumo_kwh")]
        public int Consumo { get; set; }

        [Column("nr_geracao_kwh")]
        public int Geracao { get; set; }

        [Column("nr_temperatura ")]
        public int Temperatura { get; set; }


        [Column("Id_PlacaSolar")]
        public int IdPlacaSolar { get; set; }
    }
}
