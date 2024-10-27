using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Custom_Button_Shape : MonoBehaviour
{
    public float alpha = 0.2f;
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = alpha;
    }
}
