using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePowerUp : PowerUpBase
{
    //Set how much extra life does this powerup give
    [SerializeField]
    private int extraLives;

    //Some delay needed to play audio
    [SerializeField]
    private float time;

    //Get info of the amount of lives the player has
    private GameObject GamesManagerGameObject;
    private GamesManager GamesManagerScript;

    //Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        GamesManagerGameObject = GameObject.Find("GamesManager");
        GamesManagerScript = GamesManagerGameObject.GetComponent<GamesManager>();
    }

    //Plays the powerup
    public override void playPowerUp()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        int res = GamesManagerScript.liveGetter() + 1;
        GamesManagerScript.liveSetter(res);
        StartCoroutine(CountDown(time));
    }

    //Need delay to audio play
    IEnumerator CountDown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
