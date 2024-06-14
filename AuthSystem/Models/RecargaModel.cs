using System;
using System.ComponentModel.DataAnnotations;

namespace AuthSystem.Models
{
    public class RecargaModel
    {
        [Key]
        public int IdTabela { get; set; }

        public string IdUsuario { get; set; } // Alterado para string

        [Required(ErrorMessage = "O campo Valor de Recarga é obrigatório.")]
        [Range(1, 50, ErrorMessage = "O valor de recarga deve estar entre 1 e 50.")]
        public int ValorRecarga { get; set; }

        public DateTime DataRecarga { get; set; }
    }
}
