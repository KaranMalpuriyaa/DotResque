using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public void Awake () {
        if(Instance == null) {
            Instance = this;
            DontDestroyOnLoad (gameObject);
        }
        else {
            Destroy (gameObject);
        }
    }
    private AudioSource audioSource;
    public void Start () {
        audioSource = GetComponent<AudioSource> ();
    }
    public void PlaySound(AudioClip clip) {
        audioSource.PlayOneShot (clip);
    }
}
