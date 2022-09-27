using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLifePowerUp : PowerUpBase
{
    //Set how much extra life does this powerup give
    [SerializeField]
    private int extraLives;

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
        int res = GamesManagerScript.liveGetter() + 1;
        GamesManagerScript.liveSetter(res);
        Destroy(this.gameObject);
    }
}
