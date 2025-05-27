
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    private int _currentLevel;

    void Start()
    {
        _currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EventManager.Instance.TriggerEvent(StringConstant.EVENT.CHECKPOINT_REACHED);
            DataManager.Instance.SetLevel(_currentLevel + 1);
        }
    }
}
