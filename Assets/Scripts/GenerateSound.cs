using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateSound : MonoBehaviour
{

    [SerializeField] private AudioSource _audioSource;

    private AudioClip _clip;

    [SerializeField] private Honse _honse;
    
    // Start is called before the first frame update
    void Start()
    {
        int sampleRate = 44100; // The number of samples per second
        float frequency = 440f; // Frequency of the sine wave in Hertz
        float duration = 2f;    // Duration of the audio clip in seconds

        _clip = CreateSineWave(sampleRate, frequency, duration);
        _audioSource.clip = _clip;
        _audioSource.loop = true;
    }

    AudioClip CreateSineWave(int sampleRate, float frequency, float duration)
    {
        int numSamples = (int)(sampleRate * duration);
        float[] samples = new float[numSamples];

        for (int i = 0; i < numSamples; i++)
        {
            float t = i / (float)sampleRate;
            samples[i] = Mathf.Sin(2 * Mathf.PI * frequency * t);
        }

        AudioClip generatedAudioClip = AudioClip.Create("GeneratedClip", numSamples, 1, sampleRate, false);
        generatedAudioClip.SetData(samples, 0);

        return generatedAudioClip;
    }


    private void Update()
    {
        if (_honse._moveHonse)
        {
            _audioSource.Play();
            _audioSource.pitch = Random.Range(-3, 3);
        }
        else
        {
            _audioSource.Stop();
        }
    }
}
