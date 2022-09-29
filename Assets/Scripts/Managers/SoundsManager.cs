using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Script for the volume slider
public class SoundsManager : MonoBehaviour
{
    //Audio mixer here
    [SerializeField]
    private AudioMixer mixer;

    //Slider here
    [SerializeField]
    private Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        //Get playerprefs or default to 1
        slider.value = PlayerPrefs.GetFloat("SFX vol", 1f);
    }

    public void setlevel (float slidervalue)
    {
        //Change volume on a logarithmic scale
        mixer.SetFloat("SFX volume", Mathf.Log10(slidervalue) * 20);
        PlayerPrefs.SetFloat("SFX vol", slidervalue);
    }
}
