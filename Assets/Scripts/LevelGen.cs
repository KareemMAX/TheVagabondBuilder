using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour
{
    public GameObject ground;
    public int width;
    public int length;
    public Transform parent;

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < width; x++)
        {
            for (int y = 0; y < length; y++)
            {
                Instantiate(ground, new Vector3(x, 0, y), Quaternion.identity, parent);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
