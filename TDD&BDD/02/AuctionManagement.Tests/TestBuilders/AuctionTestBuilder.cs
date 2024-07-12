using static AuctionManagement.Tests.TestBuilders.TestConstants;

namespace AuctionManagement.Tests.TestBuilders
{
    internal class AuctionTestBuilder
    {
        private int _sellerId = Sellers.Jack;
        private DateTime _endDateTime = DateTime.Now.AddDays(1);
        private string _product = "ASUS FW4435";
        private int _startingPrice = 1000;

        public AuctionTestBuilder WithSeller(int sellerId)
        {
            _sellerId = sellerId;
            return this;
        }

        public AuctionTestBuilder WithStartingPrice(int startingPrice)
        {
            _startingPrice = startingPrice;
            return this;
        }

        public Auction Build()
        {
            return new Auction(_sellerId, _endDateTime, _product, _startingPrice);
        }

        //public static implicit operator Auction(AuctionTestBuilder builder)
        //{
        //    return builder.Build();
        //}
    }
}
