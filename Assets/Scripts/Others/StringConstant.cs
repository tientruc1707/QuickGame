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
        public static int HEALTH = 60;
        public static int DAMAGE = 20;
        public static int SPEED = 8;
        public static int VALUE = 10;
        public static int ATTACK_RANGE = 5;
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
    public static class VALUE
    {
        public static int COIN_VALUE = 1;
        public static int CHECKPOINT_VALUE = 1;
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
}
