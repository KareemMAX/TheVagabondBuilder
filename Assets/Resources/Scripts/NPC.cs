using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private PlayerScore playerScore;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerScore = FindObjectOfType<PlayerScore>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Happy", playerScore.GoldHammer >= playerScore.TotalHammer);
    }
}
