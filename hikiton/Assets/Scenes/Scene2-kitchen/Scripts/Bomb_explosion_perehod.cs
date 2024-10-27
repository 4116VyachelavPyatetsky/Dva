using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_explosion_perehod : MonoBehaviour
{
    public GameObject fon;

    public void PLayAnm()
    {
        transform.GetComponent<Animation>().Play("bomb_vzriv");
    }
    public void Perehod()
    {
        fon.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.SetActive(false);
        fon.GetComponent<Scene_transition_scr>().FadeToLevel();
    }
}
