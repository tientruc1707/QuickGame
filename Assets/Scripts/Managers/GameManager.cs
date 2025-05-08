

public class GameManager : Singleton<GameManager>
{

    override public void Awake()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StartListening(StringConstant.EVENT.CHECKPOINT_REACHED, OnCheckPointReached);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.PLAYER_DEAD, OnPlayerDead);
        EventManager.Instance.StopListening(StringConstant.EVENT.CHECKPOINT_REACHED, OnCheckPointReached);
    }
    private void OnPlayerDead()
    {
        DataManager.Instance.SaveGameData();
    }
    private void OnCheckPointReached()
    {
        DataManager.Instance.SaveGameData();
    }
    private void OnGameStart()
    {

    }
}
