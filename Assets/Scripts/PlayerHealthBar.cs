using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour {
    public Image bar;

    public void SetAmount(float amount)
    {
        bar.fillAmount = amount;
    }
}
