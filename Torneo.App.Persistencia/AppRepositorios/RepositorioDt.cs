using Microsoft.EntityFrameworkCore;
using Torneo.App.Dominio;
namespace Torneo.App.Persistencia
{
    public class RepositorioDT : IRepositorioDT
    {
        private readonly DataContext _dataContext = new DataContext();
        public DirectorTecnico AddDT (DirectorTecnico directortecnico)  
        {
            var dtInsertado = _dataContext.DirectoresTecnicos.Add(directortecnico);
            _dataContext.SaveChanges();
            return dtInsertado.Entity;
        }
        public IEnumerable<DirectorTecnico> GetAllDTs()
        {
        return _dataContext.DirectoresTecnicos;
        }
        public DirectorTecnico GetDirectorTecnico(int idDirectorTecnico)
        {
            var directortecnicoEncontrado = _dataContext.DirectoresTecnicos.Find(idDirectorTecnico);
            return directortecnicoEncontrado;
        }
        public DirectorTecnico UpdateDirectorTecnico(DirectorTecnico dt)
        {
            var dtEncontrado = _dataContext.DirectoresTecnicos.Find(dt.Id);
            if (dtEncontrado != null)
            {
                dtEncontrado.Nombre = dt.Nombre;
                _dataContext.SaveChanges();
            }
            return dtEncontrado;
        }
    }
} 