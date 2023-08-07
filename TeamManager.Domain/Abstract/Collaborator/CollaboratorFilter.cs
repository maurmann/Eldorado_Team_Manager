namespace TeamManager.Domain.Abstract.Collaborator
{
    public class CollaboratorFilter
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? UnitId { get; set; }
        public int? TeamId { get; set; }
    }
}
