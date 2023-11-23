using System.ComponentModel.DataAnnotations;

namespace WebINV.Models
{
    public class cadCli 
    {
        [Key]
       public int idCli { get; set; }
        public int idProd { get; set; }
        public int idInventario { get; set; }
        public string Nome { get; set; }
        public string telefone { get; set; }
        public string Cpf { get; set;}
      
    }
}
