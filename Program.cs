namespace Program
{    
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;

            int[,] map = new int[50, 50];
            int x = 0;
            int y = 0;

            while (true)
            {
                
                Console.CursorVisible = false;

                Console.SetCursorPosition(x, y);
                Console.WriteLine("▣");                

                key = Console.ReadKey(true);

                Console.SetCursorPosition(x, y);
                Console.Write("  ");

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        if(x > 0)
                        x--;
                        break;
                    case ConsoleKey.RightArrow:  
                        if(x < 49)
                        x++;
                        break;
                    case ConsoleKey.UpArrow:  
                        if(y > 0)
                        y--;
                        break;
                    case ConsoleKey.DownArrow:   
                        if(y < 49)
                        y++;
                        break;
                }                
            }           
        }
    }
}
