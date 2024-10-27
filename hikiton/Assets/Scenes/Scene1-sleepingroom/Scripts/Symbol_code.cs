using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Symbol_code : MonoBehaviour
{
    private string right_str = "2413";
    private string real_str = "";
    public GameObject temn;

    public void AddSymbol(string str)
    {
        real_str = AddCharacter(real_str, str, 4);
        if (real_str == right_str) End();
    }
    void End()
    {
        temn.GetComponent<Scene_transition_scr>().FadeToLevel();
    }

    public static string AddCharacter(string input, string newChar, int maxLength)
    {
        input += newChar;
        if (input.Length > maxLength)
        {
            input = input.Substring(1);
        }
        return input;
    }

}
