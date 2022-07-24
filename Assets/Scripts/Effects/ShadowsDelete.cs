using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shadows are made by making an entirely new gameobject, this class is responsible in making sure they get deleted properly
public class ShadowsDelete : MonoBehaviour
{
    //Which gameobject is this shadow object tracking
    [SerializeField]
    private GameObject oriGameobject;

    // Update is called once per frame
    void Update()
    {
        //Check if the gameobject has been destroyed
        if(oriGameobject == null)
        {
            Debug.Log("Reached");
            Destroy(this.gameObject);
        }

        //Check if the gameobject has been hidden
        this.GetComponent<SpriteRenderer>().enabled = oriGameobject.GetComponent<SpriteRenderer>().enabled;
    }

    //Set what the gameobject should be from another script
    public void setOriGameobject(GameObject gameObjectHere)
    {
        this.oriGameobject = gameObjectHere;
    }
}
