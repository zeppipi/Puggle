using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScore : MonoBehaviour
{
    //Get the score script
    private GameObject scoreManager;
    private Score scoreScript;

    //Scoring
    [SerializeField]
    private float scoreWeight = 1f;  //for balancing debugging
    private int score;

    //Get the 'BallBehaviour' script
    private BallBehaviour ballBehaviourInstantiate;

    //Start is called before the first frame update
    void Start()
    {
        //Initialize the score script
        scoreManager = GameObject.Find("ScoreManager");
        scoreScript = scoreManager.GetComponent<Score>();
        ballBehaviourInstantiate = this.gameObject.GetComponent<BallBehaviour>();
    }

    //Update is called once per frame
    void Update()
    {
        int temp_scoring = (int)(this.gameObject.transform.position.y * scoreWeight);

        if(temp_scoring > 0 && score < temp_scoring)
        {
            score = temp_scoring;
        }

        if(ballBehaviourInstantiate.hitGetter() == true)
        {
            scoreScript.scoreAdder(score);
            score = 0;
        }
    }

    //Get score
    public int getScore()
    {
        return score;
    }

    //Set score
    public void setScore(int score)
    {
        this.score = score;
    }
}
