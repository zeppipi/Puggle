using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour
{
    //Create the details of this gameobject
    private CircleCollider2D powerUpHitbox;
    [SerializeField]
    private float powerUpSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        powerUpHitbox = this.gameObject.AddComponent<CircleCollider2D>();
        powerUpHitbox.isTrigger = true;
        this.transform.localScale = new Vector2(powerUpSize,powerUpSize);
    }

    //Detect of a gameobject has entered this trigger
    private void OnTriggerEnter2D(Collider2D other) 
    {
        playPowerUp();
        Destroy(this.gameObject);
    }

    public void sizeSetter(int size)
    {
        this.powerUpSize = size;
    }

    private void playPowerUp(){}

}
