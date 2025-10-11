using Framework.Application;

namespace SampleContext.Application.Contracts
{
    public class AddAuctionCommand: ICommand
    {
        public string Title { get; set; }     
    }
}
