using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The paddle script
public class PaddleScript : MonoBehaviour
{
    //Set how high the paddle can go
    [SerializeField]
    private float y_constraint;

    //The constraint line
    [SerializeField]
    private GameObject constraintLine;

    //Set how fast should it follow the mouse
    [SerializeField]
    private float speed;

    //Set how big the paddle should be
    [SerializeField]
    private float x_size = 1f;
    [SerializeField]
    private float y_size = 1f;

    //Instance of the object itself
    private GameObject paddleObject;
    private Transform paddleTransform;

    //Status if the paddle should be following the cursor or not
    private bool followMouse;
    
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate self
        paddleObject = this.gameObject;
        paddleTransform = paddleObject.GetComponent<Transform>();

        //Resize
        paddleTransform.localScale = new Vector3(x_size, y_size, 1f);

        //Spawn the constriant line
        Instantiate(constraintLine, new Vector3(0f, y_constraint, 0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //Determines if the mouse is in the valid area
        followMouse = (Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width && Input.mousePosition.y >= 0 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y <= y_constraint);

        //Valid
        if(followMouse)
        {
            paddleTransform.position = Vector2.MoveTowards(paddleTransform.position, new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), speed * Time.deltaTime);
        }
        //Partially valid
        else
        {
            //Mouse is only invalid in y
            if(Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width)
            {
                paddleTransform.position = Vector2.MoveTowards(paddleTransform.position, new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, paddleTransform.position.y), speed * Time.deltaTime);
            }
            //Mouse is only invalid in x
            if(Input.mousePosition.y >= 0 && Camera.main.ScreenToWorldPoint(Input.mousePosition).y <= y_constraint)
            {
                paddleTransform.position = Vector2.MoveTowards(paddleTransform.position, new Vector2(paddleTransform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y), speed * Time.deltaTime);
            }
        }
    }

    //For debugging
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawLine(new Vector2(-Screen.width, y_constraint), new Vector2(Screen.width, y_constraint));
    }
}
