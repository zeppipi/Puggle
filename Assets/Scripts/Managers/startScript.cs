using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//A script that will start the game
public class startScript : MonoBehaviour
{
    //Where will the ball spawn
    [SerializeField]
    private Vector3 ballPos;
    
    //Ball gameobject here
    [SerializeField]
    private GameObject ballGameobject;

    //Start screen UI here
    [SerializeField]
    private TextMeshProUGUI startText;

    private bool clickStart;

    //Get gamesmanager
    private GameObject gamesManagerObject;
    private GamesManager gamesManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        clickStart = false;

        gamesManagerObject = GameObject.Find("GamesManager");
        gamesManagerScript = gamesManagerObject.GetComponent<GamesManager>();

        //overwrite the gameover status
        gamesManagerScript.overwriteGameoverSetter(true);
    }

    // Update is called once per frame
    void Update()
    {
        startText.enabled = !clickStart;
        
        if (Input.GetMouseButton(0) && !clickStart)
        {
            Instantiate(ballGameobject, ballPos, Quaternion.identity);
            gamesManagerScript.overwriteGameoverSetter(false);
            clickStart = true;
        }
    }
}
