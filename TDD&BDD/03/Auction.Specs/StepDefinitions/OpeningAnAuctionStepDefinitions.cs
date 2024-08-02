using System;
using TechTalk.SpecFlow;

namespace Auction.Specs.StepDefinitions
{
    [Binding]
    public class OpeningAnAuctionStepDefinitions
    {
        [Given(@"I have an active seller account")]
        public void GivenIHaveAnActiveSellerAccount()
        {
        }

        [When(@"I open the auction for my product with following conditions")]
        public void WhenIOpenTheAuctionForMyProductWithFollowingConditions(Table table)
        {
            
        }

        [Then(@"my auction is available in the list of open auctions")]
        public void ThenMyAuctionIsAvailableInTheListOfOpenAuctions()
        {
            
        }
    }
}
