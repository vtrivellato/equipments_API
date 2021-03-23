using System.Collections.Generic;
using api.Models;

namespace api.Data.Repositories
{
    public interface IAlarmeAtuadoRepository
    {
        bool SaveChanges();

        IEnumerable<AlarmeAtuado> GetAllAlarmesAtuados(int equipamento = 0);

        AlarmeAtuado GetAlarmeAtuadoById(int id);

        void Create(AlarmeAtuado alarmeAtuado);

        void Update(AlarmeAtuado alarmeAtuado);

        void Delete(AlarmeAtuado alarmeAtuado);
    }
}