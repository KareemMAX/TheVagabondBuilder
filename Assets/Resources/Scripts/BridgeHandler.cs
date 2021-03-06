﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeHandler : MonoBehaviour
{
    [SerializeField] float amount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerScore player = other.GetComponent<PlayerScore>();
            if (player != null)
            {
                player.Bridge += amount;
                Destroy(gameObject);
            }
        }
        else if (other.tag == "Bridge")
        {
            Destroy(gameObject);
        }
    }


}
