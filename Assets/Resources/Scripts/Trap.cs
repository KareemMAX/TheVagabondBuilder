using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Bridgeable bridgable;

    private void Start()
    {
        bridgable = GetComponent<Bridgeable>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player" && !bridgable.bridged)
        {
            collider.GetComponent<PlayerControl>().Dead = true;
            collider.GetComponent<Animator>().SetBool("Dead", true);
        }
    }
}
