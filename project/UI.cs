using GameBoard;
using GamePlayer;

namespace Print
{
    public class UI
    {
        //보드 그리기
        private static void DrawBoard(int x, int y)
        {
            if (y == 0 && x == 0) Console.Write("┌");
            else if (y == 0 && x == 14) Console.Write("┐");
            else if (y == 14 && x == 0) Console.Write("└");
            else if (y == 14 && x == 14) Console.Write("┘");
            else if (y == 0) Console.Write("┬");
            else if (y == 14) Console.Write("┴");
            else if (x == 0) Console.Write("├");
            else if (x == 14) Console.Write("┤");
            else Console.Write("┼");
        }
        //보드 출력
        public static void ShowBoard(Board board)
        {            
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    Console.SetCursorPosition(x * 2, y);
                    int stoneColor = board.BoardState()[y, x];

                    if (stoneColor == 1)
                        Console.Write("○");
                    else if (stoneColor == 2)
                        Console.Write("●");
                    else
                        DrawBoard(x, y);
                }               
            }
        }

        public static void DrawCursor(int x, int y, int stone, Board board)
        {
            //다시 전체 보드를 그림
            ShowBoard(board);

            // 플레이어별 색상 설정
            Console.ForegroundColor = (stone == 1) ? ConsoleColor.DarkGreen : ConsoleColor.DarkRed;
                    
            Console.SetCursorPosition(x * 2, y);
            Console.Write("+");

            Console.ResetColor();
        }
        // 메시지 출력
        public static void ShowMessage(string message)
        {
            Console.SetCursorPosition(0, 16);
            Console.WriteLine(message);
        }
    }
}

       
       
    

