using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Frontend.Pages.Jugadores
{
    public class DetailsModel : PageModel
    {        private readonly IRepositorioJugador _repojugador;
        public Jugador jugador {get; set;}

        public DetailsModel(IRepositorioJugador repoJugador)
        {
            _repojugador = repoJugador;
        }
        public IActionResult OnGet(int id)
        {
            jugador = _repojugador.GetJugador(id);
            if (jugador == null)
            {
            return NotFound();
            }
                else
                {
                return Page();
                }
        }
    }
}