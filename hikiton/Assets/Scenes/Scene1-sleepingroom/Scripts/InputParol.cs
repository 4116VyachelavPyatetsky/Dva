using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputParol : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI InputText;
    [SerializeField] TMP_InputField inputfield;
    [SerializeField] string MyText;

    private static bool got_parol = false;

    string parol = "murder";

    public GameObject newMonitor;

    private void Update()
    {
        if (got_parol)
        {
            End();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log(InputText.text);
            Debug.Log(parol);
            Debug.Log(InputText.text == parol);
            if (InputText.text == parol)
            {
                got_parol = true;
                End();
            }
        }
    }

    void End()
    {
        Debug.Log("Hah");
        gameObject.SetActive(false);
        newMonitor.SetActive(true);
    }
}
