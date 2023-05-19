using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaitCount : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    public void UpdateWaitText(int value)
    {
        text.text = "wait: " + value +"s";
    }
}
