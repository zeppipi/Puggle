using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    //Check how many balls there are in the scene
    private GameObject[] ballsScene;

    //Get information about the score
    private GameObject scoreManagerGameObject;
    private Score scoreManagerScript;

    //Choose how many lives the player can have
    [SerializeField]
    private int lives;

    //Variables for lives calculations
    private int currentBalls;
    private int lastUpdateBalls;

    //Start is called before the first frame update
    void Start()
    {
        //Start the last update
        lastUpdateBalls = 0;
        
        //Get info on the amount of balls currently
        ballsScene = GameObject.FindGameObjectsWithTag("Ball");
        currentBalls = ballsScene.Length;
        
        //Get info of the score
        scoreManagerGameObject = GameObject.Find("ScoreManager");
        scoreManagerScript = scoreManagerGameObject.GetComponent<Score>();
    }
    
    //Update is called once per frame
    void Update()
    {
        //Get info on the amount of balls currently
        ballsScene = GameObject.FindGameObjectsWithTag("Ball");
        currentBalls = ballsScene.Length;

        //A change in the amount of balls has been detected
        if(lastUpdateBalls != currentBalls)
        {
            //A ball was lost
            if(currentBalls < lastUpdateBalls)
            {
                if(lives >= 0)  //Just so the lives doesn't continously get reduced
                {
                    lives -= 1;
                    Debug.Log("Lives: " + lives);
                    lastUpdateBalls = currentBalls;
                }
            }
            //A ball was added
            else
            {
                lastUpdateBalls = currentBalls;
            }
        }
        
        //Game Over
        if(lives == 0 || currentBalls == 0)
        {
            Debug.Log("Game Over! Your final score is " + scoreManagerScript.scoreGetter());
            endPlay();
        }
    }

    //Script deletes all balls in the scene
    void endPlay()
    {
        for(int index = 0; index < currentBalls; index++)
        {
            if(ballsScene[index] != null)
            {
                Destroy(ballsScene[index]);
            }
        }
    }
    
    //Script to reset the scene
    void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}