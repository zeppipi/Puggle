using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWalls : MonoBehaviour
{
    //Set play area
    [SerializeField]
    private float area;

    //Give the particle effects
    [SerializeField]
    private GameObject particles;

    //Play audio
    private AudioSource bounceAudio;

    private Rigidbody2D ballPhysics;
    private bool flipped;

    //Instantiate the rigidbody
    void Start()
    {
        ballPhysics = this.gameObject.GetComponent<Rigidbody2D>();

        //Set the sfx
        bounceAudio = this.GetComponent<AudioSource>();
    }
    
    //Screw box colliders fr
    void Update() 
    {
        if(this.transform.position.x > area || this.transform.position.x < -area)
        {   
            if(flipped == false)
            {
                ballPhysics.velocity = new Vector2(-ballPhysics.velocity.x, ballPhysics.velocity.y);
                Instantiate(particles, this.transform.position, Quaternion.identity);
                bounceAudio.Play();

                if(this.transform.position.x > area)
                {
                    this.transform.position = new Vector2(area, this.transform.position.y);
                }
                else if(this.transform.position.x < -area)
                {
                    this.transform.position = new Vector2(-area, this.transform.position.y);
                }

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
