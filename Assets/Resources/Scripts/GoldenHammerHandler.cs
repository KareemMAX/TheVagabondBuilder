using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenHammerHandler : MonoBehaviour
{
    public AudioClip audioClip;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    [SerializeField] float amount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerScore player = other.GetComponent<PlayerScore>();
            if (player != null)
            {
                player.GoldHammer += amount;
                audioSource.Play();
                GetComponent<MeshRenderer>().enabled = false;
            }
        }
        else if (other.tag == "Bridge")
        {
            Destroy(gameObject);
        }
    }
}
