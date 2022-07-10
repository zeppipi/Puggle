using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBallPowerUp : PowerUpBase
{
    //Get the balls
    private GameObject[] balls;

    //Set the parameters of the powerup
    [SerializeField]
    private float extraSize;
    [SerializeField]
    private float time;
    [SerializeField]
    private Color powerUpColor;
    
    //For the color effect
    [SerializeField]
    private GameObject originalGameObject;
    private Color oriColor;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        balls = GameObject.FindGameObjectsWithTag("Ball");
        oriColor = originalGameObject.GetComponent<SpriteRenderer>().color;
    }

    public override void playPowerUp()
    {
        for(int index = 0; index < balls.Length; index++)
        {
            if(balls[index] != null)
            {
                balls[index].transform.localScale = balls[index].transform.localScale + new Vector3(extraSize, extraSize, 0f);
                balls[index].GetComponent<SpriteRenderer>().color = powerUpColor;
            }
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
        for(int index = 0; index < balls.Length; index++)
        {
            if(balls[index] != null)
            {
                balls[index].transform.localScale = balls[index].transform.localScale - new Vector3(extraSize, extraSize, 0f);
                balls[index].GetComponent<SpriteRenderer>().color = oriColor;
            }
        }
        Destroy(this.gameObject);
    }
    
    public override void OnTriggerEnter2D(Collider2D other)
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        playPowerUp();
    }
}
