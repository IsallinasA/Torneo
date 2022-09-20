using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public interface IRepositorioDT
    {
    public DirectorTecnico AddDT (DirectorTecnico directortecnico);
    public IEnumerable<DirectorTecnico> GetAllDTs();
    public DirectorTecnico GetDirectorTecnico(int idDirectorTecnico);
        public DirectorTecnico UpdateDirectorTecnico(DirectorTecnico dt);
    }
}