using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinCount : MonoBehaviour
{
    public Text coinCountText;
    int count = 0;

    public void AddCoin()
    {
        count += 1;
        coinCountText.text = count.ToString();
    }
}
