using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    static int score;
    Text scoreText;
    Slider HPSlider;
    [SerializeField] Health playerHP;
    void Awake()
    {
        scoreText = GetComponentInChildren<Text>();
        HPSlider = GetComponentInChildren<Slider>();
        score = 0;
    }


    void Update()
    {
        scoreText.text = "Score : " + score;
        HPSlider.value = playerHP.getCurrentHP();
    }

    public static  void ScorePoints(int amount)
    {
        score += amount;
    }
}
