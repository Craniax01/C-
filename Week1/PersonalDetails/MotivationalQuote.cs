namespace PersonalDetails
{
    public class MotivationalQuote
    {
        
        private readonly string quote;

        public MotivationalQuote(string quote)
        {
            this.quote = quote;   
        }

        public void PrintQuote()
        {
            // TODO 3
            Console.WriteLine("========== Quote of the Day ==========");
            Console.WriteLine("\"" + quote + "\"");
        }
    }
}