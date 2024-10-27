using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Symbol_code : MonoBehaviour
{
    private string right_str = "142314";
    private string real_str = "";

    public void AddSymbol(string str)
    {
        real_str = AddCharacter(real_str, str, 6);
        if (real_str == right_str) End();
    }
    void End()
    {
        Debug.Log("Win");
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
