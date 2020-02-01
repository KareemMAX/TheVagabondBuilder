using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCoinHandler : MonoBehaviour
{
    [SerializeField] float amount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerScore player = other.GetComponent<PlayerScore>();
            if (player != null)
            {
                player.BlackCoin += amount;
                Destroy(gameObject);
            }
        }
    }
}
