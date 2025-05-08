public static class StringConstant
{
    public static class PLAYER_DETAIL
    {
        public static int HEALTH = 100;
        public static int DAMAGE = 25;
        public static int SPEED = 100;
        public static int JUMP_FORCE = 5;
    }
    public static class ENEMY_DETAIL
    {
        public static class BOAR
        {
            public static int HEALTH = 50;
            public static int DAMAGE = 10;
            public static int SPEED = 5;
            public static int VALUE = 5;
            public static int ATTACK_RANGE = 2;
        }

        public static class BEE
        {
            public static int HEALTH = 30;
            public static int DAMAGE = 15;
            public static int SPEED = 7;
            public static int VALUE = 8;
            public static int ATTACK_RANGE = 3;
        }
    }
    public static class UI
    {
        public static string GAME_OVER = "Game Over";
        public static string GAME_WIN = "Game Win";
        public static string GAME_PAUSE = "Game Pause";
        public static string GAME_PLAY = "Game Play";
    }
    public static class TAGS
    {
        public static string PLAYER = "Player";
        public static string ENEMY = "Enemy";
        public static string COIN = "Coin";
        public static string TRAP = "Trap";
        public static string CHECKPOINT = "Checkpoint";
    }
    public static class LAYER
    {
        public static string PLAYER = "Player";
        public static string ENEMY = "Enemy";
        public static string COIN = "Coin";
        public static string TRAP = "Trap";
        public static string CHECKPOINT = "Checkpoint";
    }
    public static class EVENT
    {
        public static string PLAYER_DEAD = "PlayerDead";
        public static string ENEMY_DEAD = "EnemyDead";
        public static string CHECKPOINT_REACHED = "CheckpointReached";
    }
    public static class ITEMTYPE
    {
        public static string COIN = "Coin";
        public static string POTION = "Potion";
        public static string WEAPON = "Weapon";
    }
    public static class ANIMATION
    {
        public static string IDLE = "Idle";
        public static string RUN = "Run";
        public static string JUMP = "Jump";
        public static string ATTACK = "Attack";
        public static string DIE = "Die";
    }
    public static class SOUND
    {
        public static string BACKGROUND_MUSIC = "BackgroundMusic";
        public static string YOOOOO = "Yooooo";
        public static string ITEM_PICKUP = "CoinPickup";
        public static string PLAYER_HIT = "PlayerHit";
        public static string GAME_OVER = "GameOver";
        public static string GAME_WIN = "GameWin";
        public static string PLAYER_RUN = "PlayerRun";
        public static string SKILL1 = "KatonGokakyoNoJutsu";

    }
    public static class SCENES
    {
        public static string MAIN_MENU = "GameStart";
    }
    public static class ENEMYTYPE
    {
        public static string BOAR = "Boar";
        public static string BEE = "Bee";
    }
    public static class WEAPONTYPE
    {
        public static string KUNAI = "Kunai";
        public static string SHURIKEN = "Shuriken";
    }
}
