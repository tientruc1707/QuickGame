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
            public static int ATTACK_RANGE = 2;
        }
    }
    public static class TAGS
    {
        public static string PLAYER = "Player";
        public static string ENEMY = "Enemy";
        public static string ITEM = "Item";
        public static string DEADZONE = "DeadZone";
        public static string CHECKPOINT = "Checkpoint";
        public static string GROUND = "Ground";
        public static string BOSS = "Boss";
        public static string WEAPON = "Weapon";
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
        public static string DEFEAT = "Defeat";
        public static string ENEMY_DEAD = "EnemyDead";
        public static string VICTORY = "Victory";
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
        public static string BOSSHIDAN = "BossHidan";

    }
    public static class SCENES
    {
        public static string MAIN_MENU = "GameStart";
    }
    public static class BOSS
    {
        public static int HEALTH = 100;
        public static int DAMAGE = 20;
        public static int SPEED = 2;
        public static int ATTACK_RANGE = 4;
    }
}
