using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip hit;
    
    public void PlayHit()
    {
        audioSource.PlayOneShot(hit, 0.8f);
    }
}
