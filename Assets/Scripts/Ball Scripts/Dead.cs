using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    /**
    This script will be attached to the balls and it will determine if they're out of bounds already
    */

    //Set the bound
    [SerializeField]
    private float yBound;   //Despite the name, the bound is only determined by the y axis

    //Delete the pointer as well
    private Pointer pointer;

    //Start is called right before the first frame
    void Start()
    {
        pointer = this.GetComponent<Pointer>();
    }
    
    //Update is called once per frame
    void Update()
    {   
        if(this.transform.position.y < yBound)
        {
            Destroy(pointer.pointerGetter());
            Destroy(this.gameObject);
        }
    }

    //Gizmos for debugging
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(-100f, yBound), new Vector2(100f, yBound));
    }
}
