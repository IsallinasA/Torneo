using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();     
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();    
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();    

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar Municipio");
                Console.WriteLine("2. Insertar DT");
                Console.WriteLine("3. Insertar Equipo"); 
                Console.WriteLine("4. Insertar Posicion"); 
                Console.WriteLine("5. Insertar Jugador"); 
                Console.WriteLine("6. Insertar Partido");  
                Console.WriteLine("7. Mostrar Municipios");  
                Console.WriteLine("8. Mostrar DTs");   
                Console.WriteLine("9. Mostrar Equipos");   
                Console.WriteLine("10. Mostrar Posiciones");
                Console.WriteLine("11. Mostrar Jugadores");
                Console.WriteLine("12. Mostrar Partidos");                            
                      
                Console.WriteLine("0. Salir");
                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;
                    case 2:
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break; 
                    case 4:
                        AddPosicion();
                        break;
                    case 5:
                        AddJugador();
                        break;  
                    case 6:
                        AddPartido();
                        break;                    
                    case 7:
                        GetAllMunicipios();
                        break;
                    case 8:
                        GetAllDTs();
                        break;  
                    case 9:
                        GetAllEquipos();
                        break;   
                    case 10:
                        GetAllPosiciones();
                        break;  
                    case 11:
                        GetAllJugadores();
                        break;    
                    case 12:
                        GetAllPartidos();
                        break;                                                       
                }
            } while (opcion != 0);
        }

        private static void AddMunicipio()
        {
            Console.WriteLine("Ingrese el nombre del Municipio");
            string nombre = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = nombre,
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void AddDT()
        {
            Console.WriteLine("Ingrese el nombre del DT");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el documento del DT");
            string documento = Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del DT");
            string telefono = Console.ReadLine();
            var directorTecnico = new DirectorTecnico
            {
                Nombre = nombre,
                Documento = documento,
                Telefono = telefono,
            };
            _repoDT.AddDT(directorTecnico);
        }

        private static void AddEquipo()
        {
            Console.WriteLine("Ingrese el nombre del Equipo");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el id del municipio");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del DT");
            int idDT = Int32.Parse(Console.ReadLine());

            var equipo = new Equipo
            {
                Nombre = nombre,
            };
            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
        }

        private static void AddPosicion()
        {
            Console.WriteLine("Ingrese el nombre de la posicion");
            string nombre = Console.ReadLine();
            var posicion = new Posicion
            {
                Nombre = nombre,
            };
            _repoPosicion.AddPosicion(posicion);
        }            

        private static void AddJugador()
        {
            Console.WriteLine("Ingrese el nombre del jugador");
            string nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el numero del jugador");
            int numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del Equipo");
            int idEquipo = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id de la Posicion");
            int idPosicion = Int32.Parse(Console.ReadLine());

            var jugador = new Jugador
            {
                Nombre = nombre,
                Numero = numero,
            };
            _repoJugador.AddJugador(jugador, idEquipo, idPosicion);
        }

private static void AddPartido()
        {
            Console.WriteLine("Ingrese la fecha y hora del partido");
            DateTime fechahora = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Id del Equipo Local");
            int idEquipoLocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el marcador del Equipo Local");
            int marcadorlocal = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el Id del Equipo Visitante");
            int idEquipoVisitante = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el marcador del Equipo Vistante");
            int marcadorvisitante = Int32.Parse(Console.ReadLine());  
                      
            var partido = new Partido
            {
                FechaHora = fechahora,
                MarcadorLocal = marcadorlocal, 
                MarcadorVisitante = marcadorvisitante, 
            };
            _repoPartido.AddPartido(partido, idEquipoLocal, idEquipoVisitante);
        }

            private static void GetAllMunicipios()
            {
                foreach (var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
            }



            private static void GetAllDTs()
            {
            foreach (var dt in _repoDT.GetAllDTs())
            {
            Console.WriteLine(dt.Id + " " + dt.Nombre + " " + dt.Documento + " " + dt.Telefono);
            }
            }
            private static void GetAllEquipos()
            {
            foreach (var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine(equipo.Id + " " + equipo.Nombre + " " + equipo.Municipio.Nombre + " " + equipo.DirectorTecnico.Nombre);
            }
            }    

            private static void GetAllPosiciones()
            {
                foreach (var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine(posicion.Id + " " + posicion.Nombre);
            }
            }  

            private static void GetAllJugadores()
            {
            foreach (var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine(jugador.Id + " " + jugador.Nombre + " " + jugador.Numero + " " + jugador.Equipo.Nombre + " " + jugador.Posicion.Nombre);
            }
            }  

            private static void GetAllPartidos()
            {
            foreach (var partido in _repoPartido.GetAllPartidos())
            {
                Console.WriteLine(partido.Id + " " + partido.FechaHora + " " + partido.Local.Nombre + " " + partido.Visitante.Nombre + " " + partido.MarcadorLocal + " " + partido.MarcadorVisitante);
            }
            }      
    }
}

