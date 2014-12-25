namespace GetIt.Core
{
    public class GetItInteractor
    {
        private readonly IRequestGateway _requestGateway;
        private readonly ITaskGateway _taskGateway;

        public GetItInteractor(IRequestGateway requestGateway, ITaskGateway taskGateway)
        {
            _requestGateway = requestGateway;
            _taskGateway = taskGateway;
        }

        public TaskItem RequestPeer(Request req)
        {
            return new TaskItem()
            {
                Task = req.RequestText
            };
        }

        public TaskItem ConvertToTask(ConvertToTaskRequest req)
        {
            var request = _requestGateway.GetById(req.RequestId);
            var taskItem = new TaskItem()
            {
                RequestId = request.Id,
                Task = request.RequestText,
                UserId = req.UserId,
            };
            _taskGateway.SaveTask(taskItem);
            return taskItem;
        }
    }
}