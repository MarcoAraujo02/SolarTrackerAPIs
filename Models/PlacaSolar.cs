using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolarTrackerAPIs.Models
{
    public class PlacaSolar
    {
        [Key]
        public int idPlacaSolar { get; set; }


        [Column("ds_placa_solar")]
        public string Descricao { get; set; } = string.Empty;


        [Column("st_placa_solar")]
        public Status Status { get; set; }


        [Column("Id_estabelecimento")]
        public int IdEstabelecimento { get; set; }
    }
}
