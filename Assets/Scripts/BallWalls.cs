using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallWalls : MonoBehaviour
{
    //Instantiate the entity manager script and object
    private GameObject informationObject;
    private Information informationScript;

    //The box colliders for the edges of the screen
    [SerializeField]
    private BoxCollider2D leftWall;
    [SerializeField]
    private BoxCollider2D rightWall;

    private PositionConstraints playArea;
    
    // Start is called before the first frame update
    void Start()
    {
        informationObject = GameObject.Find("EntitiesManager");
        informationScript = informationObject.GetComponent<Information>();

        playArea = informationScript.prefabListGetter(0).GetComponent<PositionConstraints>();
    }

    // Update is called once per frame
    void Update()
    {
        leftWall.offset = new Vector2(this.transform.position.x - playArea.constraintsGetter()[0], this.transform.position.y);
    }
}
