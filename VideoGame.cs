namespace VideoGameApi
{
    /// Modelo de dados que representa um videogame na aplicação
    /// Corresponde à tabela VideoGames no banco de dados   
    public class VideoGame 
    {
        // Chave primária - gerada automaticamente pelo banco 
        public int Id { get; set; }
        
        // Nome/título do jogo
        public string? Title { get; set; }
        
        // Plataforma onde o jogo roda (ex: PC, PS5, Xbox, Switch)
        public string? Platform { get; set; }
        
        // Empresa/estúdio que desenvolveu o jogo
        public string? Developer { get; set; }
        
        // Empresa responsável pela publicação/distribuição do jogo
        public string? Publisher { get; set; }
    }
}