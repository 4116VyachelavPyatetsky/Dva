using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_for_key_nashel : MonoBehaviour
{
    public GameObject shkaf;
    void Start()
    {
        if (PlayerPrefs.GetInt("key", 0) == 1)
        {
            shkaf.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
