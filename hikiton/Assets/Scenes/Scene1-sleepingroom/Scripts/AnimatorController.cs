using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using System.Linq;
using UnityEngine.Rendering;

public class AnimatorController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI message;
    private float betweenhalf = 0.01f;
    private float betweenChar = 0.03f;
    private float smoothTime = 0.1f;

    private List<float> leftalphas;
    private List<float> rightalphas;

    bool text_shown = false;

    public static bool Shown_start_message = false;


    private bool isanimating = false;
    private void Start()
    {

        if (!Shown_start_message)
        {
            transform.GetComponent<Animator>().SetTrigger("Pereh");
        }
    }

    private void Update()
    {
        if (isanimating)
            SwitchColor();
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (text_shown) {
                transform.GetComponent<Animator>().SetTrigger("Pereh");
                text_shown = false;
                if (!Shown_start_message)
                {
                    Shown_start_message = true;
                }
            }
            else
            {
                text_shown = true;
                isanimating = false;
                Visble(true);
            }
        }
    }

    private void ShowText()
    {
        leftalphas = new float[message.text.Length].ToList();
        rightalphas = new float[message.text.Length].ToList();
        isanimating = true;
        StartCoroutine(Smooth(0));
        transform.GetComponent<AudioSource>().Play();
    }
    private void Visble(bool visible)
    {
        StopAllCoroutines();
        DOTween.Kill(1);
        for (int i = 0; i < leftalphas.Count; i++)
        {
            leftalphas[i] = visible ? 255 : 0;
            rightalphas[i] =   visible? 255 : 0;
        }
        SwitchColor();
    }
    private void SwitchColor()
    {
        for (int i = 0; i < leftalphas.Count; i++)
        {
            if (message.textInfo.characterInfo[i].character != '\n' &&
                message.textInfo.characterInfo[i].character != ' ')
            {
                int meshIndex = message.textInfo.characterInfo[i].materialReferenceIndex;
                int vertexIndex = message.textInfo.characterInfo[i].vertexIndex;

                Color32[] vertexColors = message.textInfo.meshInfo[meshIndex].colors32;

                vertexColors[vertexIndex + 0].a = (byte)leftalphas[i];
                vertexColors[vertexIndex + 1].a = (byte)leftalphas[i];
                vertexColors[vertexIndex + 2].a = (byte)rightalphas[i];
                vertexColors[vertexIndex + 3].a = (byte)rightalphas[i];
            }
        }
        message.UpdateVertexData();
    }

    private IEnumerator Smooth(int i)
    {
        if (i >= leftalphas.Count)
        {
            text_shown = true;
            yield break;
        }

        DOTween.To(  
            () => leftalphas[i],
            x => leftalphas[i] = x,
            255,
            smoothTime)
            .SetEase(Ease.Linear)
            .SetId(1);
        yield return new WaitForSeconds(betweenhalf);

        DOTween.To(
            () => rightalphas[i],
            x => rightalphas[i] = x,
            255,
            smoothTime)
            .SetEase(Ease.Linear)
            .SetId(1);
        yield return new WaitForSeconds(betweenChar);
        StartCoroutine(Smooth(i+1));

    }
}
