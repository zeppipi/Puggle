using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigPaddlePowerUp : PowerUpBase
{
    //Get the current paddle
    private GameObject paddle;

    //Set how big the paddle should be
    [SerializeField]
    private float extraSize;

    //Set how long the powerup should last
    [SerializeField]
    private float time;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        paddle = GameObject.FindGameObjectWithTag("Player");
    }

    public override void playPowerUp()
    {
        paddle.transform.localScale = paddle.transform.localScale + new Vector3(extraSize, 0f, 0f);
        StartCoroutine(CountDown(time));
    }

    IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        powerUpReturn();
    }

    private void powerUpReturn()
    {
        paddle.transform.localScale = paddle.transform.localScale - new Vector3(extraSize, 0f, 0f);
        Destroy(this.gameObject);
    }

    public override void OnTriggerEnter2D(Collider2D other) 
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        playPowerUp();
    }

}
