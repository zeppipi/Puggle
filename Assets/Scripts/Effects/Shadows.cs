using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that adds a little shadow to any gameobject this script is attached to
public class Shadows : MonoBehaviour
{
    //Choose color
    [SerializeField]
    private Color shadowColor;

    //Choose location offset
    [SerializeField]
    private float xPosition;
    [SerializeField]
    private float yPosition;

    //Get the current gameobject to shadow
    private GameObject currentGameobject;
    private GameObject ShadowGameobject;

    //Start is called before the first frame update
    void Awake()
    {   
        //Instantiate
        currentGameobject = new GameObject();
        
        //Set what gameobject it should be tracking
        ShadowGameobject = this.gameObject;
        
        //Give the appropiate components
        SpriteRenderer currentSprite = currentGameobject.AddComponent<SpriteRenderer>();
        currentSprite.color = shadowColor;
        currentSprite.sprite = ShadowGameobject.GetComponent<SpriteRenderer>().sprite;
        currentSprite.sortingOrder = -2;

        //Give shadowdelete component
        ShadowsDelete currentShadowDelete = currentGameobject.AddComponent<ShadowsDelete>();
        currentShadowDelete.setOriGameobject(ShadowGameobject);

    }

    //Called every frame
    void Update()
    {
        currentGameobject.transform.localScale = ShadowGameobject.transform.localScale;
        currentGameobject.transform.position = ShadowGameobject.transform.position + new Vector3(xPosition, yPosition, 0f);

    }

}
