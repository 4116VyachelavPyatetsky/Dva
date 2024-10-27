using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Animator>().SetTrigger("Pereh");
    }
}
