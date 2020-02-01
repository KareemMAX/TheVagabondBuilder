using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenHammerHandler : MonoBehaviour
{
    [SerializeField] float amount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerScore player = other.GetComponent<PlayerScore>();
            if (player != null)
            {
                player.GoldHammer += amount;
                Destroy(gameObject);
            }
        }
    }
}
