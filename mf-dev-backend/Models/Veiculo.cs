using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend.Models
{
    [Table("Veículos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Obrigatório inserir o nome!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Obrigatório inserir a placa!")]
        public string Placa { get; set;}
        [Required(ErrorMessage = "Obrigatório inserir o ano de fabricação!")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFabricacao { get; set; }
        [Required(ErrorMessage = "Obrigatório inserir o ano do modelo!")]
        [Display(Name = "Ano do modelo")]
        public int AnoModelo { get; set; }
    }
} 
