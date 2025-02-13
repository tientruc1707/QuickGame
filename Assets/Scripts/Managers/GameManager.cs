using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    private void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.PlayerDeath += PlayerDead;
        }
    }
    private void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.PlayerDeath -= PlayerDead;
        }
    }
    // Update is called once per frame
    private void Update()
    {

    }
    public void PlayerDead()
    {
        UIManager.Instance.GameOver();
    }
}
