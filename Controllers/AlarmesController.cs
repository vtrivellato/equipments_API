using System;
using System.Collections.Generic;
using System.Linq;
using api.Data.Repositories;
using api.DTOs.Alarme;
using api.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    // api/alarmes
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmesController : Controller
    {
        private readonly IAlarmeRepository _repository;
        private readonly IMapper _mapper;

        public AlarmesController(IAlarmeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/alarmes/
        [HttpGet]
        public ActionResult<IEnumerable<AlarmeReadDTO>> Get([FromQuery] string nrserie)
        {
            var alarmes = _repository.GetAllAlarmes();

            alarmes = !string.IsNullOrWhiteSpace(nrserie) ? alarmes.Where(a => a.EquipamentoPK == nrserie) : alarmes;

            return Ok(_mapper.Map<IEnumerable<AlarmeReadDTO>>(alarmes));
        }

        // GET api/alarmes/{id}
        [HttpGet("{id}", Name = "GetAlarmeById")]
        public ActionResult<AlarmeReadDTO> GetAlarmeById(int id)
        {
            var alarme = _repository.GetAlarmeById(id);

            if (alarme == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<AlarmeReadDTO>(alarme));
        }

        // POST api/alarmes
        [HttpPost]
        public ActionResult<AlarmeReadDTO> Post([FromBody] AlarmeCreateDTO alarmeCreateDTO)
        {
            try
            {
                var alarme = _mapper.Map<Alarme>(alarmeCreateDTO);

                _repository.Create(alarme);

                if (!_repository.SaveChanges())
                {

                }

                var alarmeReadDTO = _mapper.Map<AlarmeReadDTO>(alarme);

                return CreatedAtRoute(nameof(GetAlarmeById), new { Id = alarmeReadDTO.Id }, alarmeReadDTO);
            }
            catch (System.Exception)
            {
                return NotFound(new { message = $"The object {alarmeCreateDTO.EquipamentoPK} data was not found."});
            }
        }

        // PUT api/alarmes/{id}
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AlarmeUpdateDTO alarmeUpdateDTO)
        {
            var alarmeFromRepository = _repository.GetAlarmeById(id);

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

        // PATCH api/alarmes/{id}
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, [FromBody] JsonPatchDocument<AlarmeUpdateDTO> patchDocument)
        {
            var alarmeFromRepository = _repository.GetAlarmeById(id);

            if (alarmeFromRepository == null)
            {
                return NotFound();
            }

            var alarmeToPatch = _mapper.Map<AlarmeUpdateDTO>(alarmeFromRepository);
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

        // DELETE api/alarmes/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var alarmeFromRepository = _repository.GetAlarmeById(id);

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