namespace GetIt.Core
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Task { get; set; }
        public int RequestId { get; set; }
        public int UserId { get; set; }
    }
}