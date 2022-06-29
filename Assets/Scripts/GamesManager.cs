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

    //Start is called before the first frame update
    void Start()
    {
        scoreManagerGameObject = GameObject.Find("ScoreManager");
        scoreManagerScript = scoreManagerGameObject.GetComponent<Score>();
    }
    
    //Update is called once per frame
    void Update()
    {
        ballsScene = GameObject.FindGameObjectsWithTag("Ball");
        
        if(ballsScene.Length == 0)  //may want to change this into a life system instead
        {
            Debug.Log("Game Over! Your final score is " + scoreManagerScript.scoreGetter());
        }
    }

    //Script to reset the scene
    void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
