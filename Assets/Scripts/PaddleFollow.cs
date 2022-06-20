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
    private Vector2 mousePos;
    [SerializeField]
    private float Speed = 1f;

    //For sizing the object
    [SerializeField]
    private float x_size = 1f;
    [SerializeField]
    private float y_size = 1f;

    //Varibles to keep track of things
    private float Top;
    private float Below;
    private float Right;
    private float Left;
    
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

        Top = constraintInstatiate.constraintsLocationGetter()[1] + constraintInstatiate.constraintsGetter()[1];
        Below = constraintInstatiate.constraintsLocationGetter()[1] - constraintInstatiate.constraintsGetter()[1];
        Right = constraintInstatiate.constraintsLocationGetter()[0] + constraintInstatiate.constraintsGetter()[0];
        Left = constraintInstatiate.constraintsLocationGetter()[0] - constraintInstatiate.constraintsGetter()[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 leftRightPos = new Vector2(constraintInstatiate.constraintsGetter()[0] * ((mousePos.x-constraintInstatiate.constraintsLocationGetter()[0])/(Mathf.Abs(mousePos.x-constraintInstatiate.constraintsLocationGetter()[0]))) + constraintInstatiate.constraintsLocationGetter()[0], mousePos.y);
        Vector2 upDownPos = new Vector2(mousePos.x, (constraintInstatiate.constraintsGetter()[1] * ((mousePos.y-constraintInstatiate.constraintsLocationGetter()[1])/(Mathf.Abs(mousePos.y-constraintInstatiate.constraintsLocationGetter()[1])))) + constraintInstatiate.constraintsLocationGetter()[1]);

        if(mousePos.x >= Right || mousePos.x <= Left)
        {
            if(mousePos.y >= Top || mousePos.y <= Below)
            {
                playerPaddle.transform.position = Vector2.MoveTowards(playerPaddle.transform.position, new Vector2(leftRightPos.x, upDownPos.y), Speed * Time.deltaTime);   
            }
            else
            {
                playerPaddle.transform.position = Vector2.MoveTowards(playerPaddle.transform.position, leftRightPos, Speed * Time.deltaTime);
            }

        }
        
        else if(mousePos.y >= Top || mousePos.y <= Below)
        {
            if(mousePos.x >= Right || mousePos.x <= Left)
            {
                playerPaddle.transform.position = Vector2.MoveTowards(playerPaddle.transform.position, new Vector2(leftRightPos.x, upDownPos.y), Speed * Time.deltaTime); 
            }
            else
            {
                playerPaddle.transform.position = Vector2.MoveTowards(playerPaddle.transform.position, upDownPos, Speed * Time.deltaTime);
            }
            
        }

        else if((mousePos.x >= Right || mousePos.x <= Left) && (mousePos.y >= Top || mousePos.y <= Below))
        {
            Debug.Log("both");
            playerPaddle.transform.position = Vector2.MoveTowards(playerPaddle.transform.position, new Vector2(leftRightPos.x, upDownPos.y), Speed * Time.deltaTime);
        }

        else
        {
            playerPaddle.transform.position = Vector2.MoveTowards(playerPaddle.transform.position, mousePos, Speed * Time.deltaTime);
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

    // /**
    // Made so the different scripts are referencing the same gameObject
    // */
    // public GameObject gameObjectGetter()
    // {
    //     return playerPaddle;
    // }
}
