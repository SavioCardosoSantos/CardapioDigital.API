using System.ComponentModel.DataAnnotations;

namespace CardapioDigital.Infra.Ioc.Models.Base
{
    public class ItemCardapioBase
    {
        [Required(ErrorMessage = "O AbaCardapioId é obrigatório")]
        public int AbaCardapioId { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O Nome não pode ter mais de 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A Descrição é obrigatória")]
        [MaxLength(100, ErrorMessage = "O Nome não pode ter mais de 500 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "A Imagem do item é obrigatória")]
        public string ImagemBase64 { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A Quantidade de Pessoas que o item serve é obrigatória")]
        public int ServeQtdPessoas { get; set; }
    }
}
