using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitPowerUp : PowerUpBase
{
    [SerializeField]
    private float delay;

    private GameObject other;
    
    public override void playPowerUp()
    {
        GameObject clone = Instantiate(other, transform.position, Quaternion.identity);
        clone.GetComponent<Rigidbody2D>().velocity = other.GetComponent<Rigidbody2D>().velocity;
        other = null;
    }

    IEnumerator CountDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        playPowerUp();
        Destroy(this.gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D other) 
    {
        this.other = other.gameObject;
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        StartCoroutine(CountDown(delay));
    }
}
