using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    //Create the details of this gameobject
    private CircleCollider2D powerUpHitbox;
    [SerializeField]
    private float powerUpSize = 1f;
    [SerializeField]
    //Dampens the speed of the ball when it hits the powerup
    private float velocityDampen = 1f;

    // Start is called before the first frame update
    public virtual void Start()
    {
        powerUpHitbox = this.gameObject.AddComponent<CircleCollider2D>();
        powerUpHitbox.isTrigger = true;
        this.transform.localScale = new Vector2(powerUpSize,powerUpSize);
    }

    //Detect of a gameobject has entered this trigger
    public virtual void OnTriggerEnter2D(Collider2D other) 
    {
        other.GetComponent<Rigidbody2D>().velocity =  other.GetComponent<Rigidbody2D>().velocity * velocityDampen;
        playPowerUp();
    }

    public void sizeSetter(int size)
    {
        this.powerUpSize = size;
    }

    public virtual void playPowerUp(){}

}
