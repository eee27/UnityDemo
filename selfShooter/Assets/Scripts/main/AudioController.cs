using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private Slider slider;

    [SerializeField]
    private GameObject dieSound;

    private static AudioSource diesource;

    private float sliderVoice;

    private void Start()
    {
        Slider _slider = slider.GetComponent<Slider>();
        diesource = dieSound.GetComponent<AudioSource>();

        _slider.value = GlobalData.voice;
        audioSource.volume = _slider.value;
    }

    /*----------------------------------------------*/

    public void ChangeVolume()
    {
        GlobalData.voice = slider.value;
        audioSource.volume = GlobalData.voice;
    }

    public static void PlaySound()
    {
        diesource.Play();
    }
}