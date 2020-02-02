using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public bool won;
    public float speed;
    public Image wonWindow;

    private PlayerControl player;
    private Vector3 positionAfterWinning;

    private void Start()
    {
        positionAfterWinning = transform.position + Vector3.up;
        player = FindObjectOfType<PlayerControl>();
    }

    void Update()
    {
        if (won)
        {
            transform.position = Vector3.MoveTowards(transform.position, positionAfterWinning, speed * Time.deltaTime);
        }
    }

    private void OnMouseDown()
    {
        if (isNeighbour() && won)
        {
            wonWindow.gameObject.SetActive(true);
        }
    }

    bool isNeighbour()
    {
        return (new Vector2(transform.position.x, transform.position.z) - player.position).magnitude <= Mathf.Sqrt(2);
    }
}
