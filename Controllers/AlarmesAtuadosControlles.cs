using System;
using System.Collections.Generic;
using System.Linq;
using api.Data.Repositories;
using api.DTOs.AlarmeAtuado;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    // api/alarmesatuados
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmesAtuadosController : Controller
    {
        private readonly IAlarmeAtuadoRepository _repository;
        private readonly IMapper _mapper;

        public AlarmesAtuadosController(IAlarmeAtuadoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/alarmesatuados/
        [HttpGet]
        public ActionResult<IEnumerable<AlarmeAtuadoReadDTO>> Get([FromQuery] string nrserie)
        {
            var alarmes = _repository.GetAllAlarmesAtuados();

            //alarmes = !string.IsNullOrWhiteSpace(nrserie) ? alarmes.Where(a => a.EquipamentoPK == nrserie) : alarmes;

            return Ok(_mapper.Map<IEnumerable<AlarmeAtuadoReadDTO>>(alarmes));
        }

        // GET api/alarmesatuados/{id}
        [HttpGet("{id}", Name = "GetAlarmeAtuadoById")]
        public ActionResult<AlarmeAtuadoReadDTO> GetAlarmeAtuadoById(int id)
        {
            var alarme = _repository.GetAlarmeAtuadoById(id);

            if (alarme == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AlarmeAtuadoReadDTO>(alarme));
        }

        // POST api/alarmesatuados
        [HttpPost]
        public ActionResult<AlarmeAtuadoReadDTO> Post([FromBody] AlarmeAtuadoCreateDTO alarmeAtuadoCreateDTO)
        {
            try
            {
                var alarme = _mapper.Map<AlarmeAtuado>(alarmeAtuadoCreateDTO);
                alarme.Status = true;

                _repository.Create(alarme);

                if (!_repository.SaveChanges())
                {

                }

                var alarmeReadDTO = _mapper.Map<AlarmeAtuadoReadDTO>(alarme);

                return CreatedAtRoute(nameof(GetAlarmeAtuadoById), new { Id = alarme.Id }, alarmeReadDTO);
            }
            catch (System.Exception)
            {
                return NotFound(new { message = $"The object {alarmeAtuadoCreateDTO.DescricaoAlarme} data was not found."});
            }
        }

        // PUT api/alarmesatuados/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AlarmeAtuadoUpdateDTO alarmeUpdateDTO)
        {
            var alarmeFromRepository = _repository.GetAlarmeAtuadoById(id);

            if (alarmeFromRepository == null)
            {
                return NotFound();
            }

            _mapper.Map(alarmeUpdateDTO, alarmeFromRepository);

            _repository.Update(alarmeFromRepository);

            if (!_repository.SaveChanges())
            {

            }

            return NoContent();
        }

        // PATCH api/alarmesatuados/{id}
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<AlarmeAtuadoUpdateDTO> patchDocument)
        {
            var alarmeFromRepository = _repository.GetAlarmeAtuadoById(id);

            if (alarmeFromRepository == null)
            {
                return NotFound();
            }

            var alarmeToPatch = _mapper.Map<AlarmeAtuadoUpdateDTO>(alarmeFromRepository);
            patchDocument.ApplyTo(alarmeToPatch, ModelState);

            if (!TryValidateModel(alarmeToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(alarmeToPatch, alarmeFromRepository);

            _repository.Update(alarmeFromRepository);

            if (!_repository.SaveChanges())
            {

            }

            return NoContent();
        }

        // DELETE api/alarmesatuados/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var alarmeFromRepository = _repository.GetAlarmeAtuadoById(id);

            if (alarmeFromRepository == null)
            {
                return NotFound();
            }

            _repository.Delete(alarmeFromRepository);

            if (!_repository.SaveChanges())
            {

            }

            return NoContent();
        }
    }
}