using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola {
class Program {
private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
private static IRepositorioDT _repoDT = new RepositorioDT();
private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
    static void Main(string[] args) {
        int opcion=0;

        do {
            Console.WriteLine("1. Insertar Municipio");
            Console.WriteLine("2. Insertar Director Tecnico");
            Console.WriteLine("3. Insertar Equipo");
            Console.WriteLine("4. Mostrar Municipios");
            Console.WriteLine("5. Mostrar Directores Tecnicos");
            Console.WriteLine("6. Mostrar Equipos");
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
                    GetAllMunicipios();
                    break;
                case 5:
                    GetAllDTs();
                    break;
                case 6:
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

    }
}

