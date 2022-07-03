using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlomoPowerUp : PowerUpBase
{
    //Choose how much it will slow down
    [SerializeField]
    private float timeSpeed;

    //Choose how long the powerup will last
    [SerializeField]
    private float time;

    //Play the powerup
    public override void playPowerUp()
    {
        if(Time.timeScale == 1.0f)
        {
            Time.timeScale = timeSpeed;
        }
        StartCoroutine(CountDown(time));
    }

    IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        powerUpReturn();
    }

    private void powerUpReturn()
    {
        Time.timeScale = 1f;
        Destroy(this.gameObject);
    }

    //Override the ontrigger method
    public override void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        playPowerUp();
    }
}
