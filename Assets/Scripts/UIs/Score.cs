using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private Text currentScore;
    void Start()
    {
        currentScore = GetComponent<Text>();
    }
}
