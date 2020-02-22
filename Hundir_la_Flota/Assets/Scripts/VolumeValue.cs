using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    Text percentageText;
    public AudioSource audioSrc;

    public float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        percentageText = GetComponent<Text>();
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.volume = musicVolume;
    }

    public void textUpdate(float value)
    {
        percentageText.text = Mathf.RoundToInt(value * 100) + "";
    }

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
