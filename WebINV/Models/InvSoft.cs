using System.ComponentModel.DataAnnotations;

namespace WebINV.Models
{
    public class InvSoft
    {
        [Key]
        public int idSoft { get; set; }
        public string CodSoft { get; set; }
        public string Soft { get; set; }

    }
}
