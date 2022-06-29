using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    //Set height threshold
    [SerializeField]
    private float maxHeight;

    //Insert the pointer gameobject here
    [SerializeField]
    private GameObject pointer;

    //Make the pointer game object exist
    void Start()
    {
        pointer = Instantiate(pointer, new Vector3(transform.position.x, maxHeight, 0f), Quaternion.identity);
    }
    
    // Update is called once per frame
    void Update()
    {
        //Make it follow the ball in the x axis continously
        pointer.transform.position = new Vector2(transform.position.x, maxHeight);

        //Gets smaller as the ball gets higher and forces it to become 0 if the ball ends up under the pointer
        if(this.transform.position.y < maxHeight)
        {
            pointer.transform.localScale = new Vector2(0f, 0f);
        }
        else
        {
            pointer.transform.localScale = new Vector2(maxHeight/this.transform.position.y, maxHeight/this.transform.position.y);
        }
    }

    //Getter for the pointer gameobject
    public GameObject pointerGetter()
    {
        return pointer;
    }

    //Gizmos for debugging purposes
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector2(0f, maxHeight), 0.3f);
    }
}
