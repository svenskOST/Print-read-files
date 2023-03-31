namespace Print_read
{
    class Program
    {
        static void Main(string[] args)
        {
            //Först definierar jag sökvägen till filen som skall läsas av.
            string input = @"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Print & read files (12)\Print-read\Print-read\Input.txt";

            //Innehållet i filen kommer grupperas in i listor.
            //I detta fall inehåller den första listan personer och andra listan deras egenskaper.
            List<string> lines = new();
            List<Post> poster = new();

            lines = File.ReadAllLines(input).ToList();
            //För varje person definieras egenskaperna genom att dela upp informationen i bitar.
            foreach (string line in lines)
            {
                string[] items = line.Split(',');
                Post p = new Post(items[0], items[1], items[2], items[3]);
                poster.Add(p);
            }

            //Denna lista lagrar informationen som jag senare sparar i output filen.
            List<string> outContents = new();

            //För att veta vilken person.
            int num = 0;

            //Information för varje person skrivs ut.
            foreach (Post p in poster)
            {
                num++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Person " + num);
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine(p);
                Console.WriteLine();
                outContents.Add(p.ToString());
            }

            //Informationen sparas i denna fil.
            string output = @"C:\Users\alexander.marini\OneDrive - Academedia\Desktop\Programmering 1\Print & read files (12)\Print-read\Print-read\Output.txt";
            File.WriteAllLines(output, outContents);
        }
    }

    //I denna klass finns konstruktorn för personerna och hur dessa definieras, samt en metod som säger vad som skall skrivas.
    class Post
    {
        public Post(string Name, string Surname, string Email, string Other)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Email = Email;
            this.Other = Other;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Other { get; set; }

        public override string ToString()
        {
            return "First Name: " + Name + "\r\nLast Name: " + Surname + "\r\nEmail: " + Email + "\r\nOther: " + Other;
        }

    }
}