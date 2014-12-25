using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GetIt.Core;
using Moq;
using Xunit;

namespace GetIt.Test
{
    public class When_requesting_to_peer
    {

        [Fact]
        public void A_requester_can_only_request_its_peer_only()
        {
            
        }

        [Fact]
        public void Can_request_a_peer()
        {
            var mock = new Mock<IRequestGateway>();
            var interactor = new GetItInteractor(mock.Object, new Mock<ITaskGateway>().Object);
            var req = new Request()
            {
                RequestText = "Bring a bread",
                PeerId = 2,
                UserId = 1
            };

            interactor.RequestPeer(req);
        }

    }
}
