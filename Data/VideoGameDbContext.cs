using Microsoft.EntityFrameworkCore;

namespace VideoGameApi.Data
{
    // Contexto do banco de dados para gerenciar operações com videogames
    // Utiliza injeção de dependência primária (Primary Constructor)
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        // DbSet representa a tabela VideoGames no banco de dados
        // Permite operações CRUD (Create, Read, Update, Delete)
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        // Método chamado quando o modelo do banco está sendo criado
        // Usado para configurações adicionais das entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data - Dados iniciais inseridos automaticamente no banco
            // Útil para popular a base com dados de exemplo durante desenvolvimento
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "The Witcher 3: Wild Hunt", Platform = "PC", Developer = "CD Projekt Red", Publisher = "CD Projekt" },
                new VideoGame { Id = 2, Title = "The Last of Us", Platform = "PS4", Developer = "Naughty Dog", Publisher = "Sony Interactive Entertainment" },
                new VideoGame { Id = 3, Title = "The Legend of Zelda: Breath of the Wild", Platform = "Switch", Developer = "Nintendo", Publisher = "Nintendo" }
            );
        }
    }
}