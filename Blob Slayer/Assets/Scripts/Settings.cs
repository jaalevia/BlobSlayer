using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    /*public AudioMixer AudioMix;
    public void SetVolume(float volume)
    { 
        AudioMix.SetFloat("volume")
    }*/
    public AudioMixer mixer;
    [SerializeField] TextMeshProUGUI masterVolumeSliderText;

    public void MasterVolume(float volume)
    {

        mixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);

        masterVolumeSliderText.text = ((int)(volume * 100)).ToString();
    }

}
