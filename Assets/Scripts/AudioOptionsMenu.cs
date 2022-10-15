using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioOptionsMenu : MonoBehaviour
{
   public Text volumeAmount;

   public Slider slider;
    public void SetAudio(float value)
    {
        AudioListener.volume = value;
        volumeAmount.text = ((int)(value*100)).ToString();
        SaveAudio();
    }

    public void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume", AudioListener.volume);
    }
    public void LoadAudio()
    {
        if(PlayerPrefs.HasKey("audioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("audioVolume", 0.5f);
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }
    }
    void Start()
    {
        LoadAudio();
    }
}
