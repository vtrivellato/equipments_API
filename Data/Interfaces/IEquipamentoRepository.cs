using System.Collections.Generic;
using api.Models;

namespace api.Data.Repositories
{
    public interface IEquipamentoRepository
    {
        bool SaveChanges();

        IEnumerable<Equipamento> GetAllEquipamentos();

        Equipamento GetEquipamentoById(int id);

        Equipamento GetEquipamentoByPK(string chassi);

        void Create(Equipamento equipamento);

        void Update(Equipamento equipamento);

        void Delete(Equipamento equipamento);
    }
}