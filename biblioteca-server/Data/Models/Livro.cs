using System.ComponentModel.DataAnnotations;

namespace biblioteca_server.Data.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Categoria { get; set; }
        public DateTime DataLancamento { get; set; }
        public bool? ENacional { get; set; }
        public string? Autor { get; set; }

    }
}
