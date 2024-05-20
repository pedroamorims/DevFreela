namespace FreelApp.Core.Entities
{
    public class ProjectComment : BaseEntity
    {
        public ProjectComment(string content, int idProject, int idUser)
        {
            Content = content;
            this.idProject = idProject;
            this.idUser = idUser;
            CreatedAt = DateTime.Now;
        }

        public string Content { get; private set; }

        public int idProject { get; private set; }

        public int idUser { get; private set; }

        public DateTime CreatedAt { get; private set; }
    }
}
