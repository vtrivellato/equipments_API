using System.Collections.Generic;
using api.Data.Repositories;
using api.DTOs.Equipamento;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    // api/equipamentos
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : Controller
    {
        private readonly IEquipamentoRepository _repository;
        private readonly IMapper _mapper;

        public EquipamentosController(IEquipamentoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/equipamentos/
        [HttpGet]
        public ActionResult<IEnumerable<EquipamentoReadDTO>> Get()
        {
            var equipamentos = _repository.GetAllEquipamentos();

            return Ok(_mapper.Map<IEnumerable<EquipamentoReadDTO>>(equipamentos));
        }

        // GET api/equipamentos/{nrserie}
        [HttpGet("{nrserie}", Name="GetEquipamentoById")]
        public ActionResult<EquipamentoReadDTO> GetEquipamentoById(string nrserie)
        {
            var equipamento = _repository.GetEquipamentoByPK(nrserie);

            if (equipamento == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EquipamentoReadDTO>(equipamento));
        }

        // POST api/equipamentos
        [HttpPost]
        public ActionResult<EquipamentoReadDTO> Post([FromBody] EquipamentoCreateDTO equipamentoCreateDTO)
        {
            var equipamento = _mapper.Map<Equipamento>(equipamentoCreateDTO);

            _repository.Create(equipamento);

            if (!_repository.SaveChanges())
            {

            }

            var equipamentoReadDTO = _mapper.Map<EquipamentoReadDTO>(equipamento);

            return CreatedAtRoute(nameof(GetEquipamentoById), new { nrserie = equipamentoReadDTO.NumeroSerie }, equipamentoReadDTO);
        }

        // PUT api/equipamentos/{nrserie}
        [HttpPut("{nrserie}")]
        public ActionResult Put(string nrserie, [FromBody] EquipamentoUpdateDTO equipamentoUpdateDTO)
        {
            var equipamentoFromRepository = _repository.GetEquipamentoByPK(nrserie);

            if (equipamentoFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(equipamentoUpdateDTO, equipamentoFromRepository);

            _repository.Update(equipamentoFromRepository);

            if (!_repository.SaveChanges())
            {

            }

            return NoContent();
        }

        // PATCH api/equipamentos/{nrserie}
        [HttpPatch("{nrserie}")]
        public ActionResult Patch(string nrserie, [FromBody] JsonPatchDocument<EquipamentoUpdateDTO> patchDocument)
        {
            var equipamentoFromRepository = _repository.GetEquipamentoByPK(nrserie);

            if (equipamentoFromRepository == null)
            {
                return NotFound();
            }

            var equipamentoToPatch = _mapper.Map<EquipamentoUpdateDTO>(equipamentoFromRepository);
            patchDocument.ApplyTo(equipamentoToPatch, ModelState);
            
            if (!TryValidateModel(equipamentoToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(equipamentoToPatch, equipamentoFromRepository);

            _repository.Update(equipamentoFromRepository);

            if (!_repository.SaveChanges())
            {

            }

            return NoContent();
        }

        // DELETE api/equipamentos/{nrserie}
        [HttpDelete("{nrserie}")]
        public ActionResult Delete(string nrserie)
        {
            var equipamentoFromRepository = _repository.GetEquipamentoByPK(nrserie);

            if (equipamentoFromRepository == null)
            {
                return NotFound();
            }

            _repository.Delete(equipamentoFromRepository);

            if (!_repository.SaveChanges())
            {

            }

            return NoContent();
        }
    }
}