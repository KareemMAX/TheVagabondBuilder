using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Collide");
        Debug.Log(collider.gameObject.tag);
        if(collider.gameObject.tag == "Player")
        {
            animator.SetBool("Dead", true);
        }
    }
}
