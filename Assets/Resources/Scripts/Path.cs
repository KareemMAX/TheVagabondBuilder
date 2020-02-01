﻿using UnityEngine;

public class Path : MonoBehaviour
{
    public Material highlightedMaterial;
    public bool bridged = false;
    public float bridgeHeight = 0.5f;

    private Material originalMat;
    private MeshRenderer meshRenderer;
    private PlayerControl player;
    private PlayerScore playerScore;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMat = meshRenderer.material;
        player = FindObjectOfType<PlayerControl>();
        playerScore = FindObjectOfType<PlayerScore>();
    }

    bool isNeighbour()
    {
        return (new Vector2(transform.position.x, transform.position.z) - player.position).magnitude <= Mathf.Sqrt(2);
    }

    void OnMouseEnter()
    {
        if (!player.dead)
            if (isNeighbour())
                meshRenderer.material = highlightedMaterial;
    }

    void OnMouseExit()
    {
        meshRenderer.material = originalMat;
    }

    private bool clicked = false;

    private void OnMouseOver()
    {
        if (Input.GetButton("Move") && !clicked)
        {
            if (isNeighbour())
                player.GoTo(new Vector2(transform.position.x, transform.position.z));
            clicked = true;
        }
        else if (Input.GetButton("Place") && !clicked)
        {
            if (player.position != new Vector2(transform.position.x, transform.position.z) && isNeighbour() && !bridged)
            {
                // Bridge :
                if(playerScore.Bridge > 0)
                {
                    playerScore.Bridge--;

                    bridged = true;
                    Instantiate(Resources.Load<GameObject>("Prefab/Bridge"), Vector3.up * bridgeHeight + transform.position, Quaternion.identity, transform);
                }
            }
            clicked = true;
        }
        else
        {
            clicked = false;
        }
    }

}