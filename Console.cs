using Custom;
using System.Text;
using static System.Console;
class Console {
    static void Main()
    {
        OutputEncoding = Encoding.UTF8;
        InputEncoding = Encoding.UTF8;

        while (true)
        {
            Clear();
            WriteLine("\n=== Base64 Console ===");
            WriteLine("1. Encode single string");
            WriteLine("2. Decode single string");
            WriteLine("3. Encode multiple strings (comma-separated)");
            WriteLine("4. Decode multiple strings (joined with ===)");
            WriteLine("0. Exit");
            Write("Choose: ");

            var choice = ReadLine();

            switch (choice)
            {
                case "1":
                    Write("Enter string: ");
                    var input1 = ReadLine();
                    var encoded1 = Base64.Encode(input1);
                    WriteLine($"Encoded: {encoded1}");
                    break;

                case "2":
                    Write("Enter encoded string: ");
                    var input2 = ReadLine();
                    var decoded2 = Base64.Decode(input2);
                    WriteLine($"Decoded: {decoded2}");
                    break;

                case "3":
                    Write("Enter strings (comma-separated): ");
                    var input3 = ReadLine()?.Split(',');
                    var encoded3 = Base64.MultiString.Encode(input3);
                    WriteLine($"Encoded: {encoded3}");
                    break;

                case "4":
                    Write("Enter encoded string: ");
                    var input4 = ReadLine();
                    var decoded4 = Base64.MultiString.Decode(input4);
                    WriteLine("Decoded:" + string.Join(",", decoded4));
                    break;

                case "0":
                    return;

                default:
                    WriteLine("Invalid choice.");
                    break;
            }
            WriteLine("\nPress any key to continue...");
            ReadKey(intercept: true);
        }
            


        }



}