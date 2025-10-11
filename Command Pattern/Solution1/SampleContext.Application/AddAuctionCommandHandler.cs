using Framework.Application;
using SampleContext.Application.Contracts;

namespace SampleContext.Application
{
    public class AddAuctionCommandHandler : ICommandHandler<AddAuctionCommand>
    {
        public Task Handle(AddAuctionCommand command)
        {
            Console.WriteLine("Handling AddAuctionCommand");
            return Task.CompletedTask;
        }
    }
}
