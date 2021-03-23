using System;
using System.Collections.Generic;
using System.Linq;
using api.Data.Contexts;
using api.Models;

namespace api.Data.Repositories
{
    public class AlarmeAtuadoRepository : IAlarmeAtuadoRepository
    {
        private readonly ApiDBContext _context;

        public AlarmeAtuadoRepository(ApiDBContext context)
        {
            _context = context;
        }

        public IEnumerable<AlarmeAtuado> GetAllAlarmesAtuados(int equipamento = 0)
        {
            var alarmesAtuados = _context.AlarmesAtuados.ToList();
            
            if (equipamento == 0)
            {
                return alarmesAtuados;
            }
            else 
            {
                return alarmesAtuados.Where(r => r.Equipamento.Id == equipamento);
            }
        }

        public AlarmeAtuado GetAlarmeAtuadoById(int id)
        {
            return _context.AlarmesAtuados.FirstOrDefault(p => p.Id == id);
        }

        public void Create(AlarmeAtuado alarmeAtuado)
        {
            if (alarmeAtuado == null)
            {
                throw new ArgumentNullException(nameof(alarmeAtuado));
            }

            alarmeAtuado.CreatedAt = DateTime.Now;
            _context.AlarmesAtuados.Add(alarmeAtuado);
        }
        
        public void Update(AlarmeAtuado AlarmeAtuado)
        {
            AlarmeAtuado.ModifiedAt = DateTime.Now;
        }
        
        public void Delete(AlarmeAtuado alarmeAtuado)
        {
            if (alarmeAtuado == null)
            {
                throw new ArgumentNullException(nameof(alarmeAtuado));
            }

            _context.AlarmesAtuados.Remove(alarmeAtuado);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}