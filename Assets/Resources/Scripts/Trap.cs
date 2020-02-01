using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Path path;

    private void Start()
    {
        path = GetComponent<Path>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player" && !path.bridged)
        {
            collider.GetComponent<PlayerControl>().dead = true;
            collider.GetComponent<Animator>().SetBool("Dead", true);
        }
    }
}
