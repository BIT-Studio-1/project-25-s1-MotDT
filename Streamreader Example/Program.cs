namespace Streamreader
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //File variable can be assigned different value depending on what frame is to be displayed
            string file = "Test3.txt";
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            //If file could not be found in expected directory
            catch (Exception ex)
            {
                Console.WriteLine("File could not be read");
                //Will report expected directory
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
