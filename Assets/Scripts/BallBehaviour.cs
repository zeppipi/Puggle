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

    //To make a more stable paddle bounce
    private bool hit;
    
    //Instiate before anything starts
    void Awake()
    {
        //Instantiate itself
        ball = this.gameObject;

        //Resize to the variable's liking
        ball.transform.localScale = new Vector3(ballSize, ballSize, 1f);

        //Instantiate the needed variables
        ballHitbox = ball.AddComponent<CircleCollider2D>();
        ballPhysics = ball.GetComponent<Rigidbody2D>();
    }

    //Screw rigid colliders
    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject otherGameobject = other.gameObject;
        
        if(hit == false)
        {
            ballPhysics.velocity = -ballPhysics.velocity + otherGameobject.GetComponent<PaddleSpeed>().getSpeed();
            hit = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        hit = false;
    }

    //Obey Speed laws
    void Update()
    {
        if(ballPhysics.velocity.magnitude > maxSpeed)
        {
            ballPhysics.velocity = ballPhysics.velocity.normalized * maxSpeed;
        }
    }

    //For other scripts to play around with
    private GameObject gameObjectGetter()
    {
        return ball;
    }
}
