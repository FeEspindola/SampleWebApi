using System;
using System.Collections.Generic;
using System.Linq;
using Commander.API.Models;

namespace Commander.API.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommandsContext _commanderRepo;

        public SqlCommanderRepo(CommandsContext commanderRepo)
        {
            _commanderRepo = commanderRepo;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _commanderRepo.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _commanderRepo.Commands.FirstOrDefault(w => w.Id == id);
        }

        public void CreateCommand(Command command)
        {
            if(command == null)
                throw new ArgumentException(nameof(command));

            _commanderRepo.Commands.Add(command);
        }

        public void UpdateCommand(Command command)
        {
            _commanderRepo.Commands.Update(command);
        }

        public void Delete(Command command)
        {
            if (command == null)
                throw new ArgumentException(nameof(command));

            _commanderRepo.Commands.Remove(command);
        }

        public bool SaveChanges()
        {
            return (_commanderRepo.SaveChanges() > 0);
        }
    }
}