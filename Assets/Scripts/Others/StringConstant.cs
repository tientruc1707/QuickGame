using UnityEngine;

public class StringConstant : MonoBehaviour
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
        public static string GAME_WIN = "You Win";
        public static string GAME_PAUSE = "Game Pause";
        public static string GAME_RESUME = "Game Resume";
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
    public static class SCENE
    {
        public static string MAIN_MENU = "MainMenu";
        public static string GAME = "Game";
        public static string GAME_OVER = "GameOver";
        public static string GAME_WIN = "GameWin";
    }
    public static class EVENT
    {
        public static string PLAYER_DEAD = "PlayerDead";
        public static string ENEMY_DEAD = "EnemyDead";
        public static string COIN_COLLECTED = "CoinCollected";
        public static string CHECKPOINT_REACHED = "CheckpointReached";
    }
    public static class VALUE
    {
        public static int COIN_VALUE = 1;
        public static int CHECKPOINT_VALUE = 1;
    }
}
