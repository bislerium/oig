namespace oig.pdf
{
    internal class Config
    {
        public static char CurrencySymbol { get; set; }

        static Config()
        {
            CurrencySymbol = '$';
        }
    }
}
