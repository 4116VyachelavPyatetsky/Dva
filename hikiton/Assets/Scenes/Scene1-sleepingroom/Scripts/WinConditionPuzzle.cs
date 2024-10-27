using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionPuzzle : MonoBehaviour
{
    int need_to_win = 4;
    int real_count = 0;


    public void PlusCount()
    {
        real_count++;
        if (need_to_win == real_count) { Debug.Log("Wiiiin"); }
    }

}
