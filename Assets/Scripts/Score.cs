using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int score = 0;
    private int temp = 0;

    // Update is called once per frame
    void Update()
    {
        if(temp != score)
        {
            temp = score;
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
