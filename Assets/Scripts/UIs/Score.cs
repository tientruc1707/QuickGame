using UnityEngine;

public class Score : MonoBehaviour
{
    private void Start()
    {
        EventManager.Instance.StartListening(StringConstant.EVENT.ENEMY_DEAD, UpdateScore);
    }
    private void OnDestroy()
    {
        EventManager.Instance.StopListening(StringConstant.EVENT.ENEMY_DEAD, UpdateScore);
    }
    public void UpdateScore()
    {
    }
}
