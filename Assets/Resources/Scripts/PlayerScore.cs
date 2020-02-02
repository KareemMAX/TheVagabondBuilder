using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] float blackCoin;
    [SerializeField] float goldHammer;
    [SerializeField] float totalHammers;
    [SerializeField] float bridge;

    public Text hammerText;
    public Text blackCoinsText;
    public Text bridgesText;

    private Goal goal;

    private void Start()
    {
        bridgesText.text = bridge.ToString();
        blackCoinsText.text = blackCoin.ToString();
        hammerText.text = string.Format("{0}/{1}", goldHammer, totalHammers);
        goal = FindObjectOfType<Goal>();
    }
    public float BlackCoin
    {
        get
        {
            return blackCoin;
        }
        set
        {
            blackCoin = value;
            blackCoinsText.text = value.ToString();
        }
    }

    public float GoldHammer
    {
        get
        {
            return goldHammer;
        }
        set
        {
            goldHammer = value;
            hammerText.text = string.Format("{0}/{1}", value, totalHammers);
            if( goldHammer >= totalHammers)
            {
                goal.won = true;
            }
        }
    }

    public float TotalHammer
    {
        get
        {
            return totalHammers;
        }
        set
        {
            totalHammers = value;
        }
    }

    public float Bridge
    {
        get
        {
            return bridge;
        }
        set
        {
            bridge = value;
            bridgesText.text = value.ToString();
        }
    }


}
