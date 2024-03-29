using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    //Instatiatiate the object itself
    private GameObject ball;
    
    //Collider and Rigidbody for the prefab itself
    private CircleCollider2D ballHitbox;
    private Rigidbody2D ballPhysics;

    //Setable variables
    [SerializeField]
    private float ballSize = 1f;
    [SerializeField]
    private float maxSpeed = 30f;
    [SerializeField]
    private float minSpeed = 1f;
    [SerializeField]
    private GameObject Particles;

    //To make a more stable paddle bounce
    private bool hit;
    private bool down;

    //SFX
    private AudioSource bounceAudio;
    
    //Instiate before anything starts
    void Awake()
    {
        //Instantiate itself
        ball = this.gameObject;

        //Resize to the variable's liking
        ball.transform.localScale = new Vector3(ballSize, ballSize, 1f);

        //Instantiate the needed variables
        ballHitbox = ball.GetComponent<CircleCollider2D>();
        ballPhysics = ball.GetComponent<Rigidbody2D>();

        //Set the sfx
        bounceAudio = ball.GetComponent<AudioSource>();
    }

    //Play particles on rigidbodies too
    void OnCollisionEnter2D(Collision2D other) 
    {
        playParticles();
        bounceAudio.Play();
    }
    
    //Screw rigid colliders
    void OnTriggerEnter2D(Collider2D other) 
    {
        //Particles play when ball hits anything
        playParticles();

        //Ball sounds plays on everything but powerups
        if(other.tag != "PowerUp")
        {
            bounceAudio.Play();
        }
        
        //Calculations for when the ball hits the player
        if(other.tag == "Player")
        {   
            GameObject otherGameobject = other.gameObject;
        
            if(down == true)
            {
                Vector2 calcResult = -ballPhysics.velocity + otherGameobject.GetComponent<PaddleSpeed>().getSpeed();
                
                if(calcResult.y > 0)
                {
                    ballPhysics.velocity = calcResult;
                }

                hit = true;
            }

            if(ballPhysics.velocity.magnitude < minSpeed)
            {
                ballPhysics.velocity += ballPhysics.velocity.normalized * minSpeed;
            }

        }

    }

    void OnTriggerExit2D(Collider2D other) 
    {
        hit = false;
    }

    //Obey Speed laws
    void Update()
    {   
        if(ballPhysics.velocity.y <= 0)
        {
            down = true;
        }
        else
        {
            down = false;
        }

        if(ballPhysics.velocity.magnitude > maxSpeed)
        {
            ballPhysics.velocity = ballPhysics.velocity.normalized * maxSpeed;
        }
    }

    //Get the 'hit' status
    public bool hitGetter()
    {
        return hit;
    }

    //Play particles
    void playParticles()
    {
        Instantiate(Particles, ball.transform.position, Quaternion.identity);
    }
}
