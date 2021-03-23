using System;
using System.Collections.Generic;
using System.Linq;
using api.Data.Contexts;
using api.Models;

namespace api.Data.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly ApiDBContext _context;

        public EquipamentoRepository(ApiDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipamento> GetAllEquipamentos()
        {
            return _context.Equipamentos.ToList();
        }

        public Equipamento GetEquipamentoById(int id)
        {
            return _context.Equipamentos.FirstOrDefault(p => p.Id == id);
        }

        public Equipamento GetEquipamentoByPK(string numeroSerie)
        {
            return _context.Equipamentos.FirstOrDefault(p => p.NumeroSerie == numeroSerie);
        }

        public void Create(Equipamento equipamento)
        {
            if (equipamento == null)
            {
                throw new ArgumentNullException(nameof(equipamento));
            }

            equipamento.CreatedAt = DateTime.Now;
            _context.Equipamentos.Add(equipamento);
        }
        
        public void Update(Equipamento equipamento)
        {
            equipamento.ModifiedAt = DateTime.Now;
        }
        
        public void Delete(Equipamento equipamento)
        {
            if (equipamento == null)
            {
                throw new ArgumentNullException(nameof(equipamento));
            }

            _context.Equipamentos.Remove(equipamento);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}