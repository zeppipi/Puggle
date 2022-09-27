using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script will be attached to the particles to make sure they get deleted after playing their effect
public class Destroy : MonoBehaviour
{
    [SerializeField]
    private float time;

    // Play when gameobject is spawned
    void Awake()
    {
        StartCoroutine(CountDown(time));
    }

    IEnumerator CountDown(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(this.gameObject);
    }
}
