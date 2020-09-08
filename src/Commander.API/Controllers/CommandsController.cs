using AutoMapper;
using Commander.API.Data;
using Commander.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Commander.API.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace Commander.API.Controllers
{
    //api/Commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDTO>> GetCommandes()
        {
            var commandItems = _mapper.Map<IEnumerable<CommandReadDTO>>(_repository.GetAllCommands());
            return Ok(commandItems);
        }

        [HttpGet("{id:int}",Name = "GetCommanderById")]
        public ActionResult<CommandReadDTO> GetCommanderById(int id)
        {
            var comand = _repository.GetCommandById(id);

            if (comand != null)
                return Ok(_mapper.Map<CommandReadDTO>(comand));

            return NotFound();
        }

        [HttpPost]
        public ActionResult<CommandReadDTO> CreateCommand(CommandCreateDTO command)
        {
            var commandModel = _mapper.Map<Command>(command);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDTO>(commandModel);
            return CreatedAtRoute(nameof(GetCommanderById), new { Id = commandReadDto.Id }, commandReadDto);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CommandReadDTO> UpdateCommand(int id, CommandUpdateDTO commandUpdate)
        {
            var commandModel = _repository.GetCommandById(id);
            if (commandModel == null) return NotFound();

            _mapper.Map(commandUpdate, commandModel);

            _repository.UpdateCommand(commandModel);
            _repository.SaveChanges();

            return NoContent();
        }


        [HttpPatch("{id:int}")]
        public ActionResult PatchCommand(int id, JsonPatchDocument<CommandUpdateDTO> patchDocument)
        {
            var commandModel = _repository.GetCommandById(id);
            if (commandModel == null) return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDTO>(commandModel);
            patchDocument.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch)) return ValidationProblem(ModelState);


            _mapper.Map(commandToPatch, commandModel);

            _repository.UpdateCommand(commandModel);
            _repository.SaveChanges();

            return NoContent();
        }


        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var commandModel = _repository.GetCommandById(id);
            if (commandModel == null) return NotFound();
            _repository.Delete(commandModel);
            _repository.SaveChanges();


            return NoContent();

        }
    }
}