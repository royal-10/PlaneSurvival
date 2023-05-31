using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public  int score = 0;
    public TMP_Text scoreText;



    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }

}
