namespace biblioteca_server.Data.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Categoria { get; set; }
        public string? DataLancamento { get; set; }
        public DateTime DataDeTeste { get; set; }
        public bool? ENacional { get; set; }
    }
}
