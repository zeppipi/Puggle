using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleFollow : MonoBehaviour
{
    //A instatiation of the constraints script
    private PositionConstraints constraintInstatiate;
    
    //An instiation of the object itself
    private GameObject playerPaddle;
    private Transform paddleForm;

    //Vectors for movement
    [SerializeField]
    private Vector2 mousePos;
    public float lerpSpeed = 1f;

    //For sizing the object
    [SerializeField]
    private float x_size = 1f;
    [SerializeField]
    private float y_size = 1f;
    
    // Initialize befor anything starts
    void Awake()
    {
        playerPaddle = this.gameObject;
        paddleForm = playerPaddle.GetComponent<Transform>();

        constraintInstatiate = this.GetComponent<PositionConstraints>();
    }

    // Initialize the first frame
    void Start() 
    {
        playerPaddle.transform.localScale = new Vector3(x_size, y_size, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        playerPaddle.transform.position = Vector2.Lerp(playerPaddle.transform.position, mousePos, lerpSpeed);

        if(playerPaddle.transform.position.x > constraintInstatiate.constraintsGetter()[0] + constraintInstatiate.constraintsLocationGetter()[0] || playerPaddle.transform.position.x < -constraintInstatiate.constraintsGetter()[0] + constraintInstatiate.constraintsLocationGetter()[0])
        {
            playerPaddle.transform.position = new Vector2(constraintInstatiate.constraintsGetter()[0] * ((playerPaddle.transform.position.x-constraintInstatiate.constraintsLocationGetter()[0])/(Mathf.Abs(playerPaddle.transform.position.x-constraintInstatiate.constraintsLocationGetter()[0]))) + constraintInstatiate.constraintsLocationGetter()[0], playerPaddle.transform.position.y);
        }
        
        if(playerPaddle.transform.position.y > constraintInstatiate.constraintsGetter()[1] + constraintInstatiate.constraintsLocationGetter()[1] || playerPaddle.transform.position.y < -constraintInstatiate.constraintsGetter()[1] + constraintInstatiate.constraintsLocationGetter()[1])
        {
            playerPaddle.transform.position = new Vector2(playerPaddle.transform.position.x, (constraintInstatiate.constraintsGetter()[1] * ((playerPaddle.transform.position.y-constraintInstatiate.constraintsLocationGetter()[1])/(Mathf.Abs(playerPaddle.transform.position.y-constraintInstatiate.constraintsLocationGetter()[1])))) + constraintInstatiate.constraintsLocationGetter()[1]);
        }

        if(((playerPaddle.transform.position.x > constraintInstatiate.constraintsGetter()[0] + constraintInstatiate.constraintsLocationGetter()[0] || playerPaddle.transform.position.x < -constraintInstatiate.constraintsGetter()[0] + constraintInstatiate.constraintsLocationGetter()[0])) && ((playerPaddle.transform.position.y > constraintInstatiate.constraintsGetter()[1] + constraintInstatiate.constraintsLocationGetter()[1] || playerPaddle.transform.position.y < -constraintInstatiate.constraintsGetter()[1] + constraintInstatiate.constraintsLocationGetter()[1])))
        {
            playerPaddle.transform.position = new Vector2(constraintInstatiate.constraintsGetter()[0] * ((playerPaddle.transform.position.x-constraintInstatiate.constraintsLocationGetter()[0])/(Mathf.Abs(playerPaddle.transform.position.x-constraintInstatiate.constraintsLocationGetter()[0]))) + constraintInstatiate.constraintsLocationGetter()[0], (constraintInstatiate.constraintsGetter()[1] * ((playerPaddle.transform.position.y-constraintInstatiate.constraintsLocationGetter()[1])/(Mathf.Abs(playerPaddle.transform.position.y-constraintInstatiate.constraintsLocationGetter()[1])))) + constraintInstatiate.constraintsLocationGetter()[1]);
        }
    }

    //For encapusilation and also easy debugging
    /**
    To get the size set for the gameobject, 0 index for the x and 1 index for the y
    */
    public List<float> sizeGetter()
    {
        List<float> res = new List<float>();
        
        res.Add(x_size);
        res.Add(y_size);

        return res;
    }

    /**
    Made so the mousePos calculation doesn't need to be done twice
    */
    public Vector2 getMousePos()
    {
        return mousePos;
    }

    /**
    Made so the different scripts are referencing the same gameObject
    */
    public GameObject gameObjectGetter()
    {
        return playerPaddle;
    }
}
