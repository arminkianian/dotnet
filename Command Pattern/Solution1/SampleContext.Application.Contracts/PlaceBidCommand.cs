using Framework.Application;

namespace SampleContext.Application.Contracts
{
    public class PlaceBidCommand : ICommand
    {
        public int AuctionId { get; set; }
        public double Amount { get; set; }
    }
}
