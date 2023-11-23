using System.ComponentModel.DataAnnotations;

namespace WebINV.Models
{
    public class InvMaqui 
    {
        [Key]
        public int idInventario { get; set; }
        public int Nserie { get; set; }
        public string Equipamento { get; set; }
        public string AnoModelo { get; set; }
        public string Estatus { get; set; }
        public string Descrição { get; set;}
    }
}
