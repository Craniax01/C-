namespace PersonalDetails
{
    class Program
    {
        public static void Main(string[] args)
        {
            string name = "Milan Thapa";
            string address = "Chauthe";
            string contactnumber = "9815699841";
            string email = "milanonethapa@gmail.com";
            string college = "ICP";
            string course = "BIT";
            string yearofstudy = "3rd";

            Console.WriteLine("========== Personal Details ==========");
            Console.WriteLine($"Name:{name}");
            Console.WriteLine($"Contact Number:{contactnumber}");
            Console.WriteLine($"College:{college}");
            Console.WriteLine($"Course:{course}");          // fixed: was {college}
            Console.WriteLine($"Year Of Study:{yearofstudy}");

            
            MotivationalQuote q = new MotivationalQuote("Small steps every day.");
            q.PrintQuote();
        }
    }
}