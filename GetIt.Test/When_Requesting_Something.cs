using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GetIt.Test
{
    public class When_Requesting_Something
    {
        [Fact]
        public void Can_request_something()
        {

            var interactor = new GetItInteractor();
            var req = new TaskRequest()
            {
                Description = "Bring a bread"
            };

            var taskItem = interactor.QueueRequest(req);
            Assert.Equal(req.Description, taskItem.Task);
        }

        [Fact]
        public void FactMethodName()
        {
            
        }
    }

    public class TaskRequest
    {
        public string Description { get; set; }
    }

    public class GetItInteractor
    {
        public TaskItem QueueRequest(TaskRequest req)
        {
            return new TaskItem()
            {
                Task = req.Description
            };
        }
    }

    public class TaskItem
    {
        public int Id { get; set; }
        public string Task { get; set; }
    }
}
