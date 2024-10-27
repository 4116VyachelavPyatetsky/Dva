using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brut : MonoBehaviour
{
    public bool once = true;
    // Start is called before the first frame update
    void Start()
    {
        if (once && !Scripte_for_min_znach.made)
        {
            Debug.Log(Scripte_for_min_znach.made);
            transform.GetComponent<Animator>().SetTrigger("Pereh");
            Scripte_for_min_znach.made = true;
        }
        else { 
            transform.GetComponent<Animator>().SetTrigger("Pereh"); }
    }
}
