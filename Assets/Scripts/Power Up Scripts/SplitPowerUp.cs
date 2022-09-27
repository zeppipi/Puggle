using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitPowerUp : PowerUpBase
{
    [SerializeField]
    private float delay;

    //Wish I didn't need to do this since it makes the code less dynamic, but I'm not sure how to fix this
    [SerializeField]
    private GameObject original;

    private GameObject other;
    
    public override void playPowerUp()
    {
        StartCoroutine(CountDown(delay));
    }

    private void playPowerUpAux()
    {
        GameObject clone = Instantiate(original, transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity;
        other = null;
    }

    IEnumerator CountDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        playPowerUpAux();
        Destroy(this.gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D other) 
    {
        this.other = other.gameObject;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        base.OnTriggerEnter2D(other);
    }
}
