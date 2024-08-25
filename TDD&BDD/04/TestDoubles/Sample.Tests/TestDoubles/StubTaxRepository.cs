namespace Sample.Tests.TestDoubles
{
    internal class StubTaxRepository : ITaxRepository
    {
        private double _taxRate;

        private StubTaxRepository()
        {
            
        }

        public static StubTaxRepository CreateNewStub()
        {
            return new StubTaxRepository();
        }


        public StubTaxRepository WitchReturnsTaxRateAs(double taxRate)
        {
            this._taxRate = taxRate;    
            return this;
        }

        public double GetCurrentTaxRate()
        {
            return _taxRate;
        }
    }
}
