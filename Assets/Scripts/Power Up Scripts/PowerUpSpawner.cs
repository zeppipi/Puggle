using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    //Set the size and location of the spawn area
    [SerializeField]
    private float xAxisSpawnArea;
    [SerializeField]
    private float yAxisSpawnArea;
    [SerializeField]
    private float xLocationSpawnArea;
    [SerializeField]
    private float yLocationSpawnArea;

    //Put the powerups here
    [SerializeField]
    private GameObject[] powerUps;

    //Set how much score is needed to start the dice roll
    [SerializeField]
    private int scoreNeeded;

    //Set the chance of any powerup to spawn
    [SerializeField]
    private float chance;

    //Get information about the score
    private GameObject scoreManagerGameObject;
    private Score scoreManagerScript;

    //Temporary variable
    private int lastScore;

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
        if((scoreManagerScript.scoreGetter() - lastScore) >= scoreNeeded && scoreManagerScript.scoreGetter() > 0)
        {
            rollDice();
            lastScore = scoreManagerScript.scoreGetter();
        }
    }

    //Function that determines if a powerup should spawn
    private void rollDice()
    {
        if(Random.value <= chance)
        {
            Debug.Log("Dice hit!");
            
            int randomIndex = Random.Range(0, powerUps.Length);
            Instantiate(powerUps[randomIndex], new Vector3(Random.Range(xLocationSpawnArea - xAxisSpawnArea/2, xLocationSpawnArea + xAxisSpawnArea/2), Random.Range(yLocationSpawnArea - yAxisSpawnArea/2, yLocationSpawnArea + yAxisSpawnArea/2), 0f), Quaternion.identity);
        }
    }

    //Gizmos for debugging
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0,0,1,0.5f);
        Gizmos.DrawCube(new Vector3(xLocationSpawnArea, yLocationSpawnArea, 1f), new Vector3(xAxisSpawnArea, yAxisSpawnArea, 1f));
    }
}
