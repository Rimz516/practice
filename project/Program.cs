using MainGame;
using GamePlayer;

namespace ConsoleProject
{
    internal class Program
    {        
        //게임 시작
        static void PlayGame(Player player1, Player player2)
        {
            Console.Clear();

            Console.WriteLine($"{player1.name}과 {player2.name}의 대결이 시작됩니다.");
                        
            Thread.Sleep(1000); 

            Console.Clear();

            GameManager.Manager game = new GameManager.Manager(player1, player2);
            game.GameStart();
                        
            Console.WriteLine("다시 시작하시려면 아무 키를 누르십시오.");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            while (true) 
            {
                MainMenu mainMenu = new MainMenu();
                mainMenu.ShowMenu();  //메뉴 화면을 출력
                int selectedMode = mainMenu.KeyInput();  //메뉴 입력 받기

                //게임모드 선택에 따른 게임 시작
                switch (selectedMode)
                {
                    case 0:
                        PlayGame(new HumanPlayer("플레이어1", 1), new HumanPlayer("플레이어2", 2));
                        break;

                    case 1:
                        PlayGame(new HumanPlayer("플레이어1", 1), new AIPlayer("컴퓨터", 2));
                        break;

                    case 2:
                        Console.WriteLine("게임을 종료합니다.");
                        return;
                }
            }
        }
    }
}
