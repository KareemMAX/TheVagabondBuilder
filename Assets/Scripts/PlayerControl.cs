using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector2 position = Vector2.zero;
    public int height = 1;
    public float speed = 3;
    public float rotationSpeed = 2.5f;

    private Vector3 newPosition;
    private Vector3 newRotation;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(position.x, height - 0.5f, position.y);
        newPosition = transform.position;
        newRotation = transform.eulerAngles;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, newRotation, speed * Time.deltaTime * rotationSpeed);
        var nextPosition = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
        var currentSpeed = (nextPosition - transform.position).magnitude / Time.deltaTime;
        animator.SetFloat("Speed", currentSpeed);

        transform.position = nextPosition;
    }

    public void GoTo(Vector2 newPos)
    {
        float deg = 0;
        var dir = newPos - position;
        if (dir == Vector2.up)
            deg = 0;
        else if (dir == Vector2.down)
            deg = 180;
        else if (dir == Vector2.left)
            deg = -90;
        else if (dir == Vector2.right)
            deg = 90;
        else if (dir == Vector2.left + Vector2.up)
            deg = -45;
        else if (dir == Vector2.right + Vector2.up)
            deg = 45;
        else if (dir == Vector2.left + Vector2.down)
            deg = -135;
        else if (dir == Vector2.right + Vector2.down)
            deg = 135;

        deg += 360;
        deg %= 360;
        Debug.Log(deg);
        newRotation = transform.eulerAngles;
        newRotation.y = deg;


        newPosition = new Vector3(newPos.x, height - 0.5f, newPos.y);
        position = newPos;
    }

}
