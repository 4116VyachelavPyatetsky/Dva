using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Parol_enter : MonoBehaviour
{
    private string right_str = "2358";
    private string real_str = "";
    //public GameObject text;
    [SerializeField] private TextMeshProUGUI message;
    public GameObject Seif_Open;
    public GameObject Main_Open;

    public void Start()
    {
        ChangeText();
    }
    public void AddSumbol(string str)
    {
        if(real_str.Length < right_str.Length)
        {
            real_str += str;
            ChangeText();
        }
    }

    void ChangeText()
    {
        //text.GetComponent<Text>().text = star_text;
        message.text = real_str;
    }

    public void Delete_code()
    {
        real_str = "";
        ChangeText();
    }

    public void Try_code()
    {
        if (real_str == right_str) { End(); }
        else Delete_code();
    }
    void End()
    {
        Seif_Open.SetActive(true);
        Main_Open.SetActive(false);
    }
}
