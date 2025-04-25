using GamePlayer;
using GameBoard;
using Mark;
using Print;

namespace GameManager
{
    public class Manager
    {
        private Board board;
        private Player player1;
        private Player player2;
        private Player currentPlayer;
        private bool isGameOver;        

        public Manager(Player player1, Player player2)
        {
            this.board = new Board();
            this.player1 = player1;
            this.player2 = player2;
            isGameOver = false;
            currentPlayer = player1;
        }

        public void GameStart()
        {
            board.ResetBoard();

            while (!isGameOver)
            {
                PlayTurn();
                CheckWinner();
                SwitchPlayer();
            }
        }
        private void PlayTurn()
        {
            UI.ShowBoard(board);
            Move move = currentPlayer.GetMove(board);
            board.PutStone(move);
        }

        private void CheckWinner()
        {
            if (CheckFive(currentPlayer))
            {
                UI.ShowBoard(board);
                UI.ShowMessage($"{currentPlayer.name}의 승리입니다!");
                isGameOver = true;
            }
        }

        private bool CheckFive(Player player)
        {
            int[,] state = board.BoardState();
            int stone = player.stone;

            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    if (state[y, x] == stone)
                    {
                        // 4방향에 대해 연속된 5개의 돌을 확인
                        foreach (var direction in new (int x, int y)[]
                        {
                            (1, 0),  // 가로
                            (0, 1),  // 세로
                            (1, 1),  // 대각선 ↘
                            (1, -1)  // 대각선 ↗
                        })
                        {
                            // 5개의 돌이 연속으로 있는지 확인
                            bool checkfive = true;
                            for (int i = 0; i < 5; i++)
                            {
                                int nx = x + direction.x * i;
                                int ny = y + direction.y * i;

                                if (nx < 0 || nx >= 15 || ny < 0 || ny >= 15 || state[ny, nx] != stone)
                                {
                                    checkfive = false;
                                    break;
                                }
                            }
                            if (checkfive) return true;
                        }
                    }
                }
            }
            return false;
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == player1) ? player2 : player1;
        }
    }
}