using System.ComponentModel.DataAnnotations;

namespace Torneo.App.Dominio{
    public class Jugador{
            public int Id { get; set; }
            [Display(Name = "Nombre del jugador")]
            [Required(ErrorMessage = "El nombre es obligatorio")]
            public string Nombre { get; set; }
            public int Numero { get; set; }
            public Equipo Equipo { get; set; }
            public Posicion Posicion { get; set; }
        }
    }