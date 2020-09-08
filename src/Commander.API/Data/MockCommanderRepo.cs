using System.Collections.Generic;
using Commander.API.Models;

namespace Commander.API.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        

        public IEnumerable<Command> GetAllCommands()
        {
            
            var commands = new List<Command>()
            {
                new Command() {Id = 0, HowTo = "Boil an egg", Line = "Boil water", PlatForm = "Kettle & Pan"},
                new Command() {Id = 1, HowTo = "Cut bread", Line = "Get a knife", PlatForm = "Knife & Chopping board"},
                new Command() {Id = 2, HowTo = "Make cup of tea", Line = "Place teabag in cup", PlatForm = "Kettle & cup"}
            };
            return commands;
        }

        public Command GetCommandById(int id)
        => new Command() { Id = 0, HowTo = "Boil an egg", Line = "Boil water", PlatForm = "Kettle & Pan" };

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void PatchCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}