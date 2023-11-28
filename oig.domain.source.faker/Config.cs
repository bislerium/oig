namespace oig.domain.source.faker
{
    public static class Config
    {        
        public static string Locale { get; set; }

        public static int CompanyFakerSeedValue { get; set; }
        public static int CustomerFakerSeedValue { get; set; }
        public static int InvoiceFakerSeedValue { get; set; }
        public static int OrderFakerSeedValue { get; set; }
        public static int LineItemFakerSeedValue { get; set; }
        public static int ProductFakerSeedValue { get; set; }

        static Config() 
        {
            Locale = "ne";
            CompanyFakerSeedValue = 1312;
            CustomerFakerSeedValue = 3223;
            InvoiceFakerSeedValue = 6121;
            OrderFakerSeedValue = 7331;
            LineItemFakerSeedValue = 8433;
            ProductFakerSeedValue = 9432;
        }
    }
}
