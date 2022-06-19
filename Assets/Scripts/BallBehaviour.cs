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

    //Variables to keep track of thigs
    [SerializeField]
    private float ballSize = 1f;
    
    //Instiate before anything starts
    void Awake()
    {
        ball = this.gameObject;

        ball.transform.localScale = new Vector3(ballSize, ballSize, 1f);

        ballHitbox = ball.AddComponent<CircleCollider2D>();
        ballPhysics = ball.GetComponent<Rigidbody2D>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        GameObject otherGameobject = other.gameObject;
        
        ballPhysics.velocity = -ballPhysics.velocity + otherGameobject.GetComponent<PaddleSpeed>().getSpeed();
    }

    private GameObject gameObjectGetter()
    {
        return ball;
    }
}
