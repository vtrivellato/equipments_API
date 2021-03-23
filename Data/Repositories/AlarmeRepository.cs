using System;
using System.Collections.Generic;
using System.Linq;
using api.Data.Contexts;
using api.Models;

namespace api.Data.Repositories
{
    public class AlarmeRepository : IAlarmeRepository
    {
        private readonly ApiDBContext _context;

        public AlarmeRepository(ApiDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Alarme> GetAllAlarmes(string equipamento = null)
        {
            var alarmes = _context.Alarmes.ToList();
            
            if (equipamento == null)
            {
                return alarmes;
            }
            else 
            {
                return alarmes.Where(r => r.EquipamentoPK == equipamento);
            }
        }

        public Alarme GetAlarmeById(int id)
        {
            return _context.Alarmes.FirstOrDefault(p => p.Id == id);
        }

        public void Create(Alarme alarme)
        {
            if (alarme == null)
            {
                throw new ArgumentNullException(nameof(alarme));
            }

            alarme.CreatedAt = DateTime.Now;
            _context.Alarmes.Add(alarme);
        }
        
        public void Update(Alarme alarme)
        {
            alarme.ModifiedAt = DateTime.Now;
        }
        
        public void Delete(Alarme alarme)
        {
            if (alarme == null)
            {
                throw new ArgumentNullException(nameof(alarme));
            }

            _context.Alarmes.Remove(alarme);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}