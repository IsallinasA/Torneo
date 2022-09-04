using Torneo.App.Dominio;
using Torneo.App.Persistencia;
namespace Torneo.App.Consola {
class Program {
private static IRepositorioDT _repoDT = new RepositorioDT();
    static void Main(string[] args) {
        int opcion=0;

        do {
            Console.WriteLine("2. Insertar Director Tecnico");
            Console.WriteLine("0. Salir");
            opcion=Int32.Parse(Console.ReadLine());
            switch(opcion){
                case 2:
                    AddDT();
                    break;
            }
        }
        while(opcion!=0); 

        
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
    }
}