using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Vector2 position = Vector2.zero;
    public int height = 1;
    public float speed=3;
    private float deg=0;
    private Vector3 newPosition;
    public Vector3 newRotation;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(position.x, height - 0.5f, position.y);
        newPosition = transform.position;
        newRotation = transform.eulerAngles;
        
    }
    void Update()
    {
        //transform.rotation = Vector3.Lerp(transform.rotation,newRotation,speed*Time.deltaTime);
        transform.eulerAngles = newRotation;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, speed * Time.deltaTime);
    }
    public void GoTo(Vector2 newPos)
    {
       // newRotation.y += Vector2.Angle(position-newPos,Vector2.right);
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


        Debug.Log(deg);
        newRotation = transform.eulerAngles;
        newRotation.y = deg;


        newPosition = new Vector3(newPos.x, height - 0.5f, newPos.y);
        position = newPos;
    }
    
}
