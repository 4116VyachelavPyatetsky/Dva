using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brut : MonoBehaviour
{
    public bool once = true;
    public static bool made = false;
    // Start is called before the first frame update
    void Start()
    {
        if (once && !made)
        {
            transform.GetComponent<Animator>().SetTrigger("Pereh");
            made = true;
        }
        else { 
            transform.GetComponent<Animator>().SetTrigger("Pereh"); }
    }
}
