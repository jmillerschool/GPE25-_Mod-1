using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScrenUi : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public Slider mainVolumeSlider;
    
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        OnMainVolumeChange();

    }

    public void OnMainVolumeChange()
    {
        //Start with the slider value (assuming our slider runs from 0 to 1)
        float newVolume = mainVolumeSlider.value;
        if (newVolume < 0)
        {
            // if we are at zero set our volume to the lowest value
            newVolume = -80;
        }
        else
        {
            // ew are >0 so start by finding the log 10 value
            newVolume = Mathf.Log10(newVolume);

            // make it in the 0-20db range (instead of 0-1 db)
            newVolume = newVolume * 20;
        }

        //set the volume to the new volume setting
        mainAudioMixer.SetFloat("MainVolume", newVolume);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
