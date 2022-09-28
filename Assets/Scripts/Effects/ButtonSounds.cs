using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
{
    //Sounds of button
    [SerializeField]
    private AudioSource buttonSound;

    //Sound when hovered
    [SerializeField]
    private AudioClip hoverSoundClip;
    
    //Do this when the cursor enters the rect area of this selectable UI object.
    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonSound.PlayOneShot(hoverSoundClip);
    }
}
