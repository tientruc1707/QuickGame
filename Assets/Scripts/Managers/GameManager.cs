

public class GameManager : Singleton<GameManager>
{

    override public void Awake()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StartListening(StringConstant.EVENT.ENEMY_DEAD, OnEnemyDead);
        EventManager.Instance.StartListening(StringConstant.EVENT.CHECKPOINT_REACHED, OnCheckPointReached);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StopListening(StringConstant.EVENT.ENEMY_DEAD, OnEnemyDead);
        EventManager.Instance.StopListening(StringConstant.EVENT.CHECKPOINT_REACHED, OnCheckPointReached);
    }
    public void OnPlayerDead()
    {
        DataManager.Instance.SaveGameData();
    }
    public void OnEnemyDead()
    {
        DataManager.Instance.SetScore(DataManager.Instance.GetScore() + StringConstant.ENEMY_DETAIL.VALUE);
    }
    private void OnCheckPointReached()
    {
        DataManager.Instance.SaveGameData();
    }
}
