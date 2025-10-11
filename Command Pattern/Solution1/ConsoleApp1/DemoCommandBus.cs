using Framework.Application;
using SampleContext.Application;
using SampleContext.Application.Contracts;

namespace ConsoleApp1
{
    public class DemoCommandBus : ICommandBus
    {
        private List<object> list = new List<object>()
        {
            new AddAuctionCommandHandler(),
            new PlaceBidCommandHandler()
        };



        public Task Dispatch<T>(T command) where T : ICommand
        {
            var handlers = list.OfType<ICommandHandler<T>>().ToList();

            foreach (var handler in handlers)
            {
                handler.Handle(command);
            }
            return Task.CompletedTask;
        }
    }
}
