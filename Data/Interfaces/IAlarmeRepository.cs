using System.Collections.Generic;
using api.Models;

namespace api.Data.Repositories
{
    public interface IAlarmeRepository
    {
        bool SaveChanges();

        IEnumerable<Alarme> GetAllAlarmes(string equipamento = null);

        Alarme GetAlarmeById(int id);

        void Create(Alarme alarme);

        void Update(Alarme alarme);

        void Delete(Alarme alarme);
    }
}