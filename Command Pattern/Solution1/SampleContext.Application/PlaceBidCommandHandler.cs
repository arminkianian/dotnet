using Framework.Application;
using SampleContext.Application.Contracts;

namespace SampleContext.Application
{
    public class PlaceBidCommandHandler : ICommandHandler<PlaceBidCommand>
    {

        public Task Handle(PlaceBidCommand command)
        {
            Console.WriteLine("Handling PlaceBidCommand");
            return Task.CompletedTask;
        }
    }
}
