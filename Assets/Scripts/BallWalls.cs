using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWalls : MonoBehaviour
{
    //Set play area
    [SerializeField]
    private float area;

    private Rigidbody2D ballPhysics;
    private bool flipped;

    //Instantiate the rigidbody
    void Start()
    {
        ballPhysics = this.gameObject.GetComponent<Rigidbody2D>();
    }
    
    //Screw box colliders fr
    void Update() 
    {
        if(this.transform.position.x > area || this.transform.position.x < -area)
        {   
            if(flipped == false)
            {
                ballPhysics.velocity = new Vector2(-ballPhysics.velocity.x, ballPhysics.velocity.y);
                flipped = true;
            }
        }
        else
        {
            flipped = false;
        }

    }

    //Show the playarea
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(new Vector2(-area, 0f), new Vector2(area, 0f));
    }
}
