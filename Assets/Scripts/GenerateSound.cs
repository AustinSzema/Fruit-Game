using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSound : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;

    private AudioClip _clip;
    
    // Start is called before the first frame update
    void Start()
    {
        _clip = GenerateAudioClip();
        _audioSource.clip = _clip;
        _audioSource.loop = true;
        
        float[] _samples = new float[_clip.samples * _clip.channels];
        _clip.GetData(_samples, 0);

        for (int i = 0; i < _samples.Length; ++i)
        {
            _samples[i] = _samples[i] * 0.5f;
        }

        _clip.SetData(_samples, 0);
        
        _audioSource.Play();
    }

    private void Update()
    {
        Debug.Log("Audio source is playing: " +_audioSource.isPlaying);
        
    }


    private AudioClip GenerateAudioClip()
    {
        AudioClip _clip = AudioClip.Create("New Clip", 10, 2, 10000, false);
        
        return _clip;
        
    }
}
