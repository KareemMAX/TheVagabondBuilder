using UnityEngine;

public class Bridgeable : MonoBehaviour
{
    public Material highlightedMaterial;
    public bool bridged = false;
    public float bridgeHeight = 0.5f;

    private Material originalMat;
    private MeshRenderer meshRenderer;
    private PlayerControl player;
    private PlayerScore playerScore;
    private Path path;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMat = meshRenderer.material;
        player = FindObjectOfType<PlayerControl>();
        playerScore = FindObjectOfType<PlayerScore>();
        path = GetComponent<Path>();
    }

    bool isNeighbour()
    {
        return (new Vector2(transform.position.x, transform.position.z) - player.position).magnitude <= Mathf.Sqrt(2);
    }

    private bool clicked = false;

    void OnMouseEnter()
    {
        if (!player.Dead && path == null)
            if (isNeighbour())
                meshRenderer.material = highlightedMaterial;
    }

    void OnMouseExit()
    {
        meshRenderer.material = originalMat;
    }

    private void OnMouseOver()
    {
        if (Input.GetButton("Place") && !clicked)
        {
            if (player.position != new Vector2(transform.position.x, transform.position.z) && isNeighbour() && !bridged)
            {
                // Bridge :
                if (playerScore.Bridge > 0)
                {
                    playerScore.Bridge--;

                    bridged = true;
                    var bridge = Instantiate(Resources.Load<GameObject>("Prefab/Bridge"), Vector3.up * bridgeHeight + transform.position, Quaternion.identity, transform);
                    bridge.transform.eulerAngles = Vector3.up * player.getDegree(new Vector2(transform.position.x, transform.position.z));
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
