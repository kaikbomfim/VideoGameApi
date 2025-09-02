using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi;
using VideoGameApi.Data;

namespace VideoGameApi.Controllers
{
    // Define a rota base como "api/videogame" e marca como controlador de API
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(VideoGameDbContext context) : ControllerBase
    {
        // Injeção de dependência do contexto do banco de dados
        private readonly VideoGameDbContext _context = context;

        // GET: api/videogame - Retorna todos os jogos
        [HttpGet]
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            // Busca todos os jogos no banco de dados de forma assíncrona
            return Ok(await _context.VideoGames.ToListAsync());
        }

        // GET: api/videogame/{id} - Retorna um jogo específico pelo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id)
        {
            // Busca o jogo pelo ID no banco de dados
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound(); // Retorna 404 se não encontrar

            return Ok(game); // Retorna o jogo encontrado
        }

        // POST: api/videogame - Cria um novo jogo
        [HttpPost]
        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            // Valida se o objeto não é nulo
            if (newGame is null)
                return BadRequest();

            // Adiciona o novo jogo ao contexto e salva no banco
            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            
            // Retorna 201 Created com a localização do recurso criado
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);
        }

        // PUT: api/videogame/{id} - Atualiza um jogo existente
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVideoGame(int id, VideoGame updatedGame)
        {
            // Busca o jogo existente no banco
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound(); // Retorna 404 se não encontrar

            // Atualiza as propriedades do jogo existente
            game.Title = updatedGame.Title;
            game.Platform = updatedGame.Platform;
            game.Developer = updatedGame.Developer;
            game.Publisher = updatedGame.Publisher;

            // Salva as alterações no banco de dados
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna 204 No Content indicando sucesso
        }

        // DELETE: api/videogame/{id} - Remove um jogo
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            // Busca o jogo a ser removido
            var game = await _context.VideoGames.FindAsync(id);
            if (game is null)
                return NotFound(); // Retorna 404 se não encontrar

            // Remove o jogo do contexto e salva as alterações
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent(); // Retorna 204 No Content indicando sucesso
        }
    }
}
