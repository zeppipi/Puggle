using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleFollow : MonoBehaviour
{
    private PositionConstraints constraintInstatiate;
    
    private GameObject playerPaddle;
    private Transform paddleForm;

    [SerializeField]
    private Vector2 mousePos;
    public float lerpSpeed = 1f;

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
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        playerPaddle.transform.position = Vector2.Lerp(playerPaddle.transform.position, mousePos, lerpSpeed);

        if(mousePos.x > constraintInstatiate.constraintsGetter()[0] + constraintInstatiate.constraintsLocationGetter()[0] || mousePos.x < -constraintInstatiate.constraintsGetter()[0] + constraintInstatiate.constraintsLocationGetter()[0])
        {
            playerPaddle.transform.position = new Vector2(constraintInstatiate.constraintsGetter()[0] * ((mousePos.x-constraintInstatiate.constraintsLocationGetter()[0])/(Mathf.Abs(mousePos.x-constraintInstatiate.constraintsLocationGetter()[0]))) + constraintInstatiate.constraintsLocationGetter()[0], mousePos.y);
        }
        
        if(mousePos.y > constraintInstatiate.constraintsGetter()[1] + constraintInstatiate.constraintsLocationGetter()[1] || mousePos.y < -constraintInstatiate.constraintsGetter()[1] + constraintInstatiate.constraintsLocationGetter()[1])
        {
            playerPaddle.transform.position = new Vector2(mousePos.x, (constraintInstatiate.constraintsGetter()[1] * ((mousePos.y-constraintInstatiate.constraintsLocationGetter()[1])/(Mathf.Abs(mousePos.y-constraintInstatiate.constraintsLocationGetter()[1])))) + constraintInstatiate.constraintsLocationGetter()[1]);
        }

        if(((mousePos.x > constraintInstatiate.constraintsGetter()[0] + constraintInstatiate.constraintsLocationGetter()[0] || mousePos.x < -constraintInstatiate.constraintsGetter()[0] + constraintInstatiate.constraintsLocationGetter()[0])) && ((mousePos.y > constraintInstatiate.constraintsGetter()[1] + constraintInstatiate.constraintsLocationGetter()[1] || mousePos.y < -constraintInstatiate.constraintsGetter()[1] + constraintInstatiate.constraintsLocationGetter()[1])))
        {
            playerPaddle.transform.position = new Vector2(constraintInstatiate.constraintsGetter()[0] * ((mousePos.x-constraintInstatiate.constraintsLocationGetter()[0])/(Mathf.Abs(mousePos.x-constraintInstatiate.constraintsLocationGetter()[0]))) + constraintInstatiate.constraintsLocationGetter()[0], (constraintInstatiate.constraintsGetter()[1] * ((mousePos.y-constraintInstatiate.constraintsLocationGetter()[1])/(Mathf.Abs(mousePos.y-constraintInstatiate.constraintsLocationGetter()[1])))) + constraintInstatiate.constraintsLocationGetter()[1]);
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
