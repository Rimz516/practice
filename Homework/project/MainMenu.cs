namespace MainGame
{
    public class MainMenu
    {
        private string[] menulist = { "플레이어1 vs 플레이어2", "플레이어1 vs 컴퓨터", "게임 종료" };
        private int selectedIndex = 0;

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("======플레이 모드 선택======");

            //메뉴 항목 출력
            for (int i = 0; i < menulist.Length; i++)
            {
                if (i == selectedIndex)
                {
                    //선택된 항목
                    Console.WriteLine($"▶ {menulist[i]}");
                }
                else
                {
                    //선택되지 않은 항목
                    Console.WriteLine($"  {menulist[i]}");
                }
            }
            //안내 메시지 출력
            Console.WriteLine("스페이스바를 눌러 선택하세요");
        }
        
        public int KeyInput()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if (selectedIndex > 0)
                                selectedIndex--;  // 위로 이동
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        {
                            if (selectedIndex < menulist.Length - 1)
                                selectedIndex++;  // 아래로 이동
                        }
                        break;
                    case ConsoleKey.Spacebar:
                        {
                            return selectedIndex;  // 선택된 항목의 인덱스를 반환                            
                        }                        
                }
                ShowMenu();  // 메뉴를 다시 그리기
            }            
        }
    }
}
