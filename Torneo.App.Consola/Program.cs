using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola {
class Program {
private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
private static IRepositorioDT _repoDT = new RepositorioDT();
private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();  
private static IRepositorioJugador _repoJugador = new RepositorioJugador();
    static void Main(string[] args) {
        int opcion=0;

        do {
            Console.WriteLine("1. Insertar Municipio");
            Console.WriteLine("2. Insertar Director Tecnico");
            Console.WriteLine("3. Insertar Equipo");
            Console.WriteLine("4. Insertar Posicion"); 
            Console.WriteLine("5. Insertar Jugador");
            Console.WriteLine("6. Mostrar Municipios");
            Console.WriteLine("7. Mostrar Directores Tecnicos");
            Console.WriteLine("8. Mostrar Equipos");
            Console.WriteLine("9. Mostrar Posiciones");
            Console.WriteLine("0. Salir");
            Console.WriteLine("Seleccione una opcion");
            opcion=Int32.Parse(Console.ReadLine());
            switch(opcion){
                case 1:
                    AddMunicipio ();
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
                    GetAllMunicipios();
                    break;
                case 7:
                    GetAllDTs();
                    break;
                case 8:
                    GetAllEquipos();
                    break;
            }
        }
        while(opcion!=0);    
    }

        private static void AddMunicipio() {
            Console.WriteLine("Ingrese el nombre del Municipio");
            string nombre=Console.ReadLine();
            
            var municipio = new Municipio {
            Nombre = nombre,
            };
            _repoMunicipio.AddMunicipio(municipio);
        }
        private static void AddDT() {
            Console.WriteLine("Ingrese el nombre del Director Tecnico");
            string nombre=Console.ReadLine();
            Console.WriteLine("Ingrese el documento del Director Tecnico");
            string documento=Console.ReadLine();
            Console.WriteLine("Ingrese el telefono del Director Tecnico");
            string telefono=Console.ReadLine();

            var directorTecnico = new DirectorTecnico {
            Nombre = nombre,
            Documento=documento,
            Telefono=telefono,
            };
            _repoDT.AddDT(directorTecnico);
        }

        private static void AddEquipo(){
            Console.WriteLine("Ingrese el nombre del Equipo");
            string nombre=Console.ReadLine();
            Console.WriteLine("Ingrese el ID del Municipio");
            int idMunicipio= Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id del Director Tecnico");
            int idDT = Int32.Parse(Console.ReadLine());
            
            var equipo = new Equipo {
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

        private static void AddJugador(){
            Console.WriteLine("Ingrese el nombre del Jugador");
            string nombre=Console.ReadLine();
            Console.WriteLine("Ingrese el Numero del Jugador");
            int numero= Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el ID del Equipo");
            int idEquipo= Int32.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese el id de la Posicion");
            int idPosicion = Int32.Parse(Console.ReadLine());
            
            var jugador = new Jugador {
            Nombre = nombre,
            Numero = numero,
            
            };
            _repoJugador.AddJugador(jugador, idEquipo, idPosicion);
        }           

        private static void GetAllMunicipios() {
            foreach (var municipio in _repoMunicipio.GetAllMunicipios()){
            Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
        }

        private static void GetAllDTs() {
            foreach (var dt in _repoDT.GetAllDTs()){
            Console.WriteLine(dt.Id + " " + dt.Nombre+ " " +dt.Documento+ " " +dt.Telefono);
            }
        }

        private static void GetAllEquipos() {
            foreach (var equipo in _repoEquipo.GetAllEquipos()){
            Console.WriteLine(equipo.Id + " " + equipo.Nombre+ " " +equipo.Municipio.Nombre+ " " +equipo.DirectorTecnico.Nombre);
            }
        }

         private static void GetAllPosiciones()
            {
                foreach (var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine(posicion.Id + " " + posicion.Nombre);
            }
            }  

    }
}

