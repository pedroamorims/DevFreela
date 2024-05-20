using FreelApp.Core.Entities;

namespace FreelApp.Infraestructure.Persistence
{
    public class FreelAppDbContext
    {
        public FreelAppDbContext()
        {
            Projects = new()
            {
                new Project("Meu projeto ASPNET Core 1", "Minha Descrição de Projeto 1", 1, 1, 10000),
                new Project("Meu projeto ASPNET Core 2", "Minha Descrição de Projeto 2", 1, 1, 20000),
                new Project("Meu projeto ASPNET Core 3", "Minha Descrição de Projeto 3", 1, 1, 30000)
            };

            Users = new()
            {
                new User("Pedro Silva","pedro.silva@teste.com", new DateTime(1994,6,29))
            };

            Skills = new()
            {
                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")    
            };


        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }

        public List<ProjectComment> ProjectComments { get; set; }
    }
}
