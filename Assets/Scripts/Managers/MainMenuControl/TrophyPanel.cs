using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewTrophyPanel : MonoBehaviour
{
    [SerializeField] private Text _bestScoreText;
    private int _bestScore;
    void Start()
    {
        _bestScoreText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _bestScore = DataManager.Instance.GetBestScore();
        _bestScoreText.text = "Best Score: " + _bestScore.ToString();
    }
}
