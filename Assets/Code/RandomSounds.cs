using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>(); 
        PlayRandomSound();   
    }

    void PlayRandomSound(){
        AudioClip clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        myAudioSource.PlayOneShot(clip);
        Invoke("PlayRandomSound", clip.length);
    }
}
