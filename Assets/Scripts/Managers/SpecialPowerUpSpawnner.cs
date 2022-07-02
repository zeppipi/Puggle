using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialPowerUpSpawnner : MonoBehaviour
{
    /*
    This script and gameobject is specifically made for the split power up, which is the power up that creates the increasing diff curve of the game
    **/
    
    //Put the power up here
    [SerializeField]
    private GameObject specialPowerUp;

    //Set how much score is needed to spawn
    [SerializeField]
    private int scoreNeeded;

    //Get information about the score
    private GameObject scoreManagerGameObject;
    private Score scoreManagerScript;

    //Temporary variable
    private int lastScore;
    private GameObject currentSpecialPowerUp;
    private GameObject[] ballsScene;

    //Start is called before the first frame update
    void Start()
    {
        lastScore = 0;
        scoreManagerGameObject = GameObject.Find("ScoreManager");
        scoreManagerScript = scoreManagerGameObject.GetComponent<Score>();
    }

    //Update is called once per frame
    void Update()
    {   
        ballsScene = GameObject.FindGameObjectsWithTag("Ball");
        
        if((scoreManagerScript.scoreGetter() - lastScore) >= scoreNeeded && scoreManagerScript.scoreGetter() > 0)
        {
            spawnSpecialPowerUp();
            lastScore = scoreManagerScript.scoreGetter();
        }
    }

    //Function to spawn the special powerup
    private void spawnSpecialPowerUp()
    {
        if(currentSpecialPowerUp == null)
        {
            Debug.Log("new spawn");
            currentSpecialPowerUp = Instantiate(specialPowerUp, this.transform.position, Quaternion.identity);
            //scoreNeeded = scoreNeeded * ballsScene.Length;    //line was made to make the chaos less quick, but its not really fun
        }
    }
}
