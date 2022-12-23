using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    public static AudioManagerScript Instance;

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource effectsSource;

    [SerializeField] private float lowPitchRange = .75f;
	[SerializeField] private float highPitchRange = 1.25f;

    [Range(0f, 1f)]
    [SerializeField] private float musicVolume = 0.35f;

    [Range(0f, 1f)]
    [SerializeField] private float effectsVolume = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip soundClip)
    {
        effectsSource.volume = effectsVolume;
        effectsSource.PlayOneShot(soundClip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        musicSource.clip = musicClip;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void PlayRandomSound(params AudioClip[] randomSoundClips)
    {
        int randomIndex = Random.Range(0, randomSoundClips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        effectsSource.pitch = randomPitch;
        effectsSource.clip = randomSoundClips[randomIndex];
        effectsSource.volume = effectsVolume;
        effectsSource.Play();
    }
}
