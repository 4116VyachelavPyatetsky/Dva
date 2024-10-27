using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colour_rebus : MonoBehaviour
{

    string parol = "124134";
    string now_parol = "";
    public GameObject[] colour_tablo;



    public void AddSymbol(string str)
    {
        now_parol = AddCharacter(now_parol, str, 6);
        Debug.Log(now_parol);
        Change_colour();
        if (now_parol == parol) End();
    }

    void End()
    {
        Debug.Log("Win");
    }

    void Change_colour()
    {
        for (int i = 0; i < now_parol.Length; i++)
        {
            switch (now_parol[i])
            {
                case '1':
                    colour_tablo[i].GetComponent<Image>().color = Color.red;
                    break;
                case '2':
                    colour_tablo[i].GetComponent<Image>().color = Color.green;
                    break;
                case '3':
                    colour_tablo[i].GetComponent<Image>().color = Color.blue;
                    break;
                case '4':
                    colour_tablo[i].GetComponent<Image>().color = Color.yellow;
                    break;
            }
        }

    }

    static string AddCharacter(string input, string newChar, int maxLength)
    {
        input = newChar + input;
        if (input.Length > maxLength)
        {
            input = input.Substring(0, maxLength);
        }

        return input;
    }

}
