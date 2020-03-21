using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeValueController : MonoBehaviour
{
    private AudioSource myAudio;

    private float musicVolume = 1f;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        myAudio.volume = musicVolume;
    }

    public void setVolume(float vol)
    {
        musicVolume = vol;
    }
}
