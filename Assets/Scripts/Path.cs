using UnityEngine;

public class Path : MonoBehaviour
{
    public Material highlightedMaterial;
    private Material originalMat;
    private MeshRenderer meshRenderer;
    private PlayerControl player;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMat = meshRenderer.material;
        player = FindObjectOfType<PlayerControl>();
    }

    bool isNeighbour()
    {
        return (new Vector2(transform.position.x, transform.position.z) - player.position).magnitude <= Mathf.Sqrt(2);
    }

    void OnMouseEnter()
    {
        if (isNeighbour())
            meshRenderer.material = highlightedMaterial;
    }

    void OnMouseExit()
    {
        meshRenderer.material = originalMat;
    }

    private void OnMouseDown()
    {
        if (isNeighbour())
            player.GoTo(new Vector2(transform.position.x, transform.position.z));
    }

}
