using System;
using System.Collections.Generic;
using Commander.API.Models;

namespace Commander.API.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);

        void Delete(Command command);
        bool SaveChanges();
    }
}