using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Is_key : MonoBehaviour
{
    public GameObject shkafchik;
    public void Proof_key()
    {
        if (PlayerPrefs.GetInt("key", 0) == 1) {
            Debug.Log(PlayerPrefs.GetInt("key", 0));
            shkafchik.SetActive(true);
            PlayerPrefs.SetInt("key", 0);
            PlayerPrefs.Save();
        }
    }
}
