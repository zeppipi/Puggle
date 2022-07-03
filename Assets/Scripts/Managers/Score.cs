using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //Score calculations
    private int score = 0;
    private int temp = 0;

    //Score text
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Update is called once per frame
    void Update()
    {
        if(temp != score)
        {
            temp = score;
            Debug.Log(score);
            scoreText.text = score + "";
        }
    }

    public void scoreSetter(int score)
    {
        this.score = score;
    }
    
    public int scoreGetter()
    {
        return score;
    }

    public void scoreAdder(int score)
    {
        this.score += score;
    }
}
