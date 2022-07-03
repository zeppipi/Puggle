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
    [SerializeField]
    private Color scoreTextColor;
    [SerializeField]
    private Color scoreTextColorGameOver;

    //Get the GamesManager info
    private GameObject GamesManagerGameObject;
    private GamesManager GamesManagerScript;

    // Initialize the first frame
    void Start()
    {
        //Attach the GamesManager info
        GamesManagerGameObject = GameObject.Find("GamesManager");
        GamesManagerScript = GamesManagerGameObject.GetComponent<GamesManager>();

    }
    
    // Update is called once per frame
    void Update()
    {
        if(temp != score)
        {
            temp = score;
            Debug.Log(score);
            scoreText.text = score + "";
        }

        //Game has ended, change score text color
        if(GamesManagerScript.gamePlayingGetter() == false)
        {
            scoreText.color = scoreTextColorGameOver;
        }
        //Game hasn't ended, keep the score text color
        else
        {
            scoreText.color = scoreTextColor;
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
