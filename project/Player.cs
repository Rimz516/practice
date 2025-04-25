using GameBoard;
using Mark;
using Print;


namespace GamePlayer
{
    //플레이어 인터페이스 정의
    public interface Player
    {
        //플레이어 이름과 돌 색       
        string name { get; } 
        int stone { get; }   
        //플레이어가 돌을 놓은 방식
        Move GetMove(Board board);
    }
    //사람플레이어 클래스
    public class HumanPlayer : Player
    {
        public string name { get; set; }
        public int stone { get; set; }
        //커서 초기 위치
        private int cursorX = 7;
        private int cursorY = 7;
        //생성자
        public HumanPlayer(string name, int stone)
        {
            this.name = name;
            this.stone = stone;
        }
        //사람플레이어의 돌을 놓는 방식
        public Move GetMove(Board board)
        {
            UI.ShowBoard(board);

            while (true)
            {                
                UI.DrawCursor(cursorX, cursorY, this.stone, board);
                //키 입력값
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        if (cursorX > 0) cursorX--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (cursorX < 14) cursorX++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (cursorY > 0) cursorY--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (cursorY < 14) cursorY++;
                        break;
                    case ConsoleKey.Spacebar:
                        if (board.ValidSpot(cursorX, cursorY))
                        {
                            return new Move(cursorX, cursorY, this);
                        }
                        else
                        {                            
                            UI.ShowMessage("해당 위치에 이미 돌이 있습니다");
                        }
                        break;
                }
            }
        }
    }
    //AI플레이어 클래스
    public class AIPlayer : Player
    {
        public string name { get; set; }
        public int stone { get; set; }
        private Random rand = new Random();
        //생성자
        public AIPlayer(string name, int stone)
        {
            this.name = name;
            this.stone = stone;
        }
        //AI플레이어의 돌 놓는 방식
        public Move GetMove(Board board)
        {
            //상대방 돌 색상 계산
            int opponentstone = stone == 1 ? 2 : 1;

            //상대의 5목을 차단하고 자신의 5목 만들기
            var move = FindSpot(board, opponentstone, false) ?? FindSpot(board, stone, true);                        
            if (move != null)
                return new Move(move.Value.x, move.Value.y, this);

            //위 조건에 해당하지 않으면 랜덤 자리 찾기
            var emptyspot = EmptySpot(board);
            var randomspot = emptyspot[rand.Next(emptyspot.Count)];
            return new Move(randomspot.x, randomspot.y, this);
        }      
       
        //특정 방향에 돌 개수 검사
        private bool CheckDirection(int x, int y, int dx, int dy, int stone, int target, Board board)
        {
            int count = 1;

            for (int i = 1; i < target; i++)
            {
                int nx = x + dx * i;
                int ny = y + dy * i;
                if (nx < 0 || nx >= 15 || ny < 0 || ny >= 15 || board.BoardState()[ny, nx] != stone)
                    break;
                count++;
            }
            for (int i = 1; i < target; i++)
            {
                int nx = x - dx * i;
                int ny = y - dy * i;
                if (nx < 0 || nx >= 15 || ny < 0 || ny >= 15 || board.BoardState()[ny, nx] != stone)
                    break;
                count++;
            }
            return count >= target;
        }
      
        //찾은 위치 승리나 차단할 수 있는지 확인
        private bool CheckSpot(int x, int y, int stone, int target, bool findtype, Board board)
        {
            return CheckDirection(x, y, 1, 0, stone, target, board) ||
                   CheckDirection(x, y, 0, 1, stone, target, board) ||
                   CheckDirection(x, y, 1, 1, stone, target, board) ||
                   CheckDirection(x, y, 1, -1, stone, target, board); 
        }

        //빈 자리 찾기
        private List<(int x, int y)> EmptySpot(Board board)
        {
            var emptyspot = new List<(int x, int y)>();
            for (int y = 0; y < 15; y++)
                for (int x = 0; x < 15; x++)
                    if (board.BoardState()[y, x] == 0)
                        emptyspot.Add((x, y));
            return emptyspot;
        }

        //승리나 차단할 자리 찾기
        private (int x, int y)? FindSpot(Board board, int stone, bool findtype)
        {
            for (int target = 5; target >= 3; target--)
            {
                for (int y = 0; y < 15; y++)
                {
                    for (int x = 0; x < 15; x++)
                    {
                        if (board.BoardState()[y, x] == 0 && CheckSpot(x, y, stone, target, findtype, board))
                        {
                            return (x, y);
                        }
                    }
                }
            }
            return null;
        }
    }
}

    




 