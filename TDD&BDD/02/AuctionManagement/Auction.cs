
namespace AuctionManagement
{
    public class Auction
    {
        public Auction(int sellerId, DateTime endDateTime, string product, int startingPrice)
        {
            if (endDateTime < DateTime.Now) throw new InvalidEndDateException();

            SellerId = sellerId;
            EndDateTime = endDateTime;
            Product = product;
            StartingPrice = startingPrice;
            WinningBid = null;
        }

        public int SellerId { get; }
        public DateTime EndDateTime { get; }
        public string Product { get; }
        public int StartingPrice { get; }
        public Bid WinningBid { get; set; }

        public void PlaceBid(Bid bid)
        {
            if (this.SellerId==bid.BidderId)
            {
                throw new InvalidBidderException();
            }

            if (bid.Amount <= this.StartingPrice)
            {
                throw new InvalidBidAmountException();
            }

            this.WinningBid = bid;
        }
    }
}
