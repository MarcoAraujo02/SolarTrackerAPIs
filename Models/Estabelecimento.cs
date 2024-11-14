using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SolarTrackerAPIs.Models
{
    public class Estabelecimento
    {
        [Key]
        public int IdEstabelecimento { get; set; }


        [Column("nm_estabelecimento")]
        public string Nome { get; set; } = string.Empty;


        [Column("ds_localizacao")]
        public string Localizacao { get; set; } = string.Empty;

        [Column("id_usuario")]
        public int IdUsuario { get; set; }
    }
}
