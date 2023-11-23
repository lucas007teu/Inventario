using System.ComponentModel.DataAnnotations;

namespace WebINV.Models
{
    public class CadProd 
    {
        [Key]
        public int idProd { get; set; }
        public int Nserie { get; set; }
        public string Modelo { get; set; }
        public string Descr { get; set; }
        public string Obs { get; set; }
       
    }
}
