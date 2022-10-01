using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinsTracker : MonoBehaviour
{
    public TMP_Text text;

    public void UpdateText(int amount)
    {
        text.text = "x " + amount;
    }

}
