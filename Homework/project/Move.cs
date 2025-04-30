using GamePlayer;

namespace Mark
{
    public class Move
    {
        public int x { get; }
        public int y { get; }
        public Player player { get; }

        public Move(int x, int y, Player player)
        {
            this.x = x;
            this.y = y;
            this.player = player;
        }
    }
}
