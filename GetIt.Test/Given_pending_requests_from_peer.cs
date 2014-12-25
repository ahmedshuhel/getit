using GetIt.Core;
using Moq;
using Xunit;

namespace GetIt.Test
{
    public class Given_pending_requests_from_peer
    {
        private GetItInteractor _interactor;
        private Mock<IRequestGateway> _requestGateWay;
        private Request _request;
        private Mock<ITaskGateway> _taskGateWay;

        public Given_pending_requests_from_peer()
        {
            _taskGateWay = new Mock<ITaskGateway>();
            _requestGateWay = new  Mock<IRequestGateway>();
            _request = CreateRequest();
            _requestGateWay.Setup(g => g.GetById(1)).Returns(_request);
            _taskGateWay.Setup(g => g.SaveTask(It.IsAny<TaskItem>()));

            _interactor = new GetItInteractor(_requestGateWay.Object, _taskGateWay.Object);
        }

        [Fact]
        public void Receiver_can_convert_the_request_to_a_task()
        {
            var task = _interactor.ConvertToTask(new ConvertToTaskRequest()
            {
                RequestId = 1,
                UserId = UserId
            });

            Assert.Equal(RequstId, task.RequestId);
            Assert.Equal(RequstText, task.Task);
            Assert.Equal(UserId, task.UserId);
        }

        [Fact]
        public void After_conversion_the_new_task_is_saved()
        {
             var task = _interactor.ConvertToTask(new ConvertToTaskRequest()
            {
                RequestId = 1,
                UserId = UserId
            });

            _taskGateWay.Verify(g=> g.SaveTask(It.Is<TaskItem>(t=> t == task)), Times.Exactly(1));
        }

        private Request CreateRequest()
        {
            return new Request
            {
                Id = RequstId,
                RequestText = RequstText,
                PeerId = PeerId,
                UserId = UserId,
            };
        }

        [Fact]
        public void After_coversion_the_new_task_is_saved()
        {

            
        }
        public int UserId { get { return 5; } }
        public int PeerId { get { return 7; } }
        public string RequstText { get { return "This is a request"; } }
        public int RequstId { get { return 1; } }
    }
}