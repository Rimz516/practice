using Mark;

namespace GameBoard
{
    public class Board
    {
        private int[,] board = new int[15, 15];  // 15x15 보드 배열
                
        //초기 보드 상태
        public void ResetBoard()
        {
            for (int y = 0; y < 15; y++)
                for (int x = 0; x < 15; x++)
                    board[y, x] = 0;
        }
        //유효한 자리 확인
        public bool ValidSpot(int x, int y)
        {
            return x >= 0 && x < 15 && y >= 0 && y < 15 && board[y, x] == 0;
        }
        //착수
        public bool PutStone(Move move)
        {
            if (ValidSpot(move.x, move.y))
            {
                board[move.y, move.x] = move.player.stone;
                return true;
            }
            return false;
        }
        //보드 상태
        public int[,] BoardState() => board;
    }
}

