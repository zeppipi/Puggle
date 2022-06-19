using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionConstraints : MonoBehaviour
{
    //An instantiation of the paddle script
    private PaddleFollow paddleInstantiate;
    
    //Variables to just keep track of the paddle size
    private float paddle_x_size;
    private float paddle_y_size;

    //Set the maximum area
    [SerializeField]
    private float xConstraint = 1f;
    [SerializeField]
    private float yConstraint = 1f;

    //Set the location area
    [SerializeField]
    private float xLocation = 0f;
    [SerializeField]
    private float yLocation = 0f;

    private float xConstraint_res = 0f;
    private float yConstraint_res = 0f;

    //Instantiate before anything
    void Awake()
    {
        paddleInstantiate = this.GetComponent<PaddleFollow>();
        paddle_x_size = paddleInstantiate.sizeGetter()[0];
        paddle_y_size = paddleInstantiate.sizeGetter()[1];
    }
    
    //Render Gizmos
    void OnDrawGizmos() 
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(new Vector3(xLocation, yLocation, 1f), new Vector3(xConstraint, yConstraint, 1f));
    }
    
    // Start is called before the first frame update
    void Start()
    {
        xConstraint_res = xConstraint / 2 - paddle_x_size/2;
        yConstraint_res = yConstraint / 2 - paddle_y_size/2;
    }

    /**
    Result from this script's calculation has to be sent back to the main script since two scripts can't control the game gameObject
    */
    public List<float> constraintsGetter()
    {
        List<float> res = new List<float>();

        res.Add(xConstraint_res);
        res.Add(yConstraint_res);

        return res;
    }

    public List<float> constraintsLocationGetter()
    {
        List<float> res = new List<float>();

        res.Add(xLocation);
        res.Add(yLocation);

        return res;
    }
}
