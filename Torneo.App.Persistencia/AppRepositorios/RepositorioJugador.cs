using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia {
public class RepositorioJugador : IRepositorioJugador{

    private readonly DataContext _dataContext = new DataContext();
        public Jugador AddJugador(Jugador jugador, int idEquipo, int idPosicion) {
            var EquipoEncontrado = _dataContext.Equipos.Find(idEquipo);
            var PosicionEncontrada = _dataContext.Posiciones.Find(idPosicion);
            jugador.Equipo = EquipoEncontrado;
            jugador.Posicion = PosicionEncontrada;
            var jugadorInsertado = _dataContext.Jugadores.Add(jugador);
            _dataContext.SaveChanges();
            return jugadorInsertado.Entity;
            }

            public IEnumerable<Jugador> GetAllJugador(){
                return _dataContext.Jugadores; 
            }
    }
}