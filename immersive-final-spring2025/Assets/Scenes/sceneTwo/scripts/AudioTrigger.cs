using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource; // Assign the AudioSource in the Inspector
    public bool isPlaying = false; // Start with the sound off

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player is tagged "Player"
        {
            if (!isPlaying)
            {
                audioSource.Play();
                isPlaying = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your player is tagged "Player"
        {
            if (isPlaying)
            {
                audioSource.Stop();
                isPlaying = false;
            }
        }
    }
}
