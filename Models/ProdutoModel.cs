using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProdutosApiWeb.Models
{
    public class ProdutoModel
    {
        [Key]

        public int IdProduto { get; set; }

        [Required, MaxLength(128)]
        public string Marca { get; set; }

        [Required, MaxLength(128)]
        public string Modelo { get; set; }

        [Required]
        public string Cor { get; set; }
        [Required]
        public decimal Preco { get; set; }

        [Required]
        public int Estoque { get; set; }
        public DateTime? DataCadastro { get; } = DateTime.Now;

    }
}
