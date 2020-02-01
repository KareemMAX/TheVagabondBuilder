using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] float blackCoin;
    [SerializeField] float goldHammer;
    [SerializeField] float bridge;


    public float BlackCoin { get { return blackCoin; } set { blackCoin = value; }  }
    public float GoldHammer { get { return goldHammer; } set { goldHammer = value; } }
    public float Bridge { get { return bridge; } set { bridge = value; } }


}
