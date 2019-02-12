using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject countReborn;
    public Text coinText;
    private Text RebornText;
    public bool StringRebornCount;

    private void Start()
    {
       RebornText = countReborn.GetComponent<Text>();
    }

    public void UpdateCoins(int coin)
    {
        coinText.text = coin.ToString();
    }

    public void UpdateCountReborn(float count)
    {
        if (StringRebornCount)
        {
            countReborn.SetActive(true);
            RebornText.text = count.ToString("0");
        }
        else
        {
            countReborn.SetActive(false);
        }
    }
}
