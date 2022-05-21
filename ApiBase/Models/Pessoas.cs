using System.ComponentModel.DataAnnotations;

namespace ApiBase.Models
{
    public class Pessoas
    {
        [Key]
        
        public int ID { get; set; }


        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public string Nome { get; set; }
        public int Idade { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O peso deve ser maior do que zero")]
        public float Peso { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public float Altura { get; set; }

        [Required(ErrorMessage = "Esse campo é obrigatório")]
        public long CPF { get; set; }
    }
}
