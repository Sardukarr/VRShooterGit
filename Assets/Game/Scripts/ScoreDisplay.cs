using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour
{

    public static int score;
    Text scoreText;

    void Awake()
    {
        scoreText = GetComponent<Text>();
        score = 0;
    }


    void Update()
    {
        scoreText.text = "Score : " + score;
    }

    public void ScorePoints()
    {

    }
}
