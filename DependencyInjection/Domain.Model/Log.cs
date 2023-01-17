namespace DependencyInjection.Domain.Model
{
    public class Log
    {
        public int Id { get; set; }
        public string User { get; set; }
        public DateTime LogDateTime { get; set; }
        public string Description { get; set; }
    }
}
