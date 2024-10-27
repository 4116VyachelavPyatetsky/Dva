using UnityEngine;
using System.Collections;

public class DelayedAudio : MonoBehaviour
{
    [Header("������ ���������")]
    public AudioClip firstClip;
    public float firstVolume = 1.0f;             // ������� ��������� ������� �����
    public float firstPitch = 1.0f;              // ������ ������� �����
    public bool firstLoop = false;               // ������������ ������� �����
    public float fadeInDuration1 = 2.0f;         // ������������ �������� ��������� ������� �����

    [Header("������ ���������")]
    public AudioClip secondClip;
    public float secondVolume = 1.0f;            // ������� ��������� ������� �����
    public float secondPitch = 1.0f;             // ������ ������� �����
    public bool secondLoop = false;              // ������������ ������� �����
    public float delay = 2.0f;                   // �������� ����� ������������� ������� �����
    public float fadeInDuration2 = 2.0f;         // ������������ �������� ��������� ������� �����

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private bool isStopped = false;              // ���� ��� ��������� ���� ������

    void Start()
    {
        // ������� ��� ��������� �����
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();

        // ����������� ����� � ����������
        audioSource1.clip = firstClip;
        audioSource2.clip = secondClip;

        // ����������� ��������� ��������� (��������� 0 ��� �������� ���������)
        audioSource1.volume = 0.0f;
        audioSource1.pitch = firstPitch;
        audioSource1.loop = firstLoop;

        audioSource2.volume = 0.0f;
        audioSource2.pitch = secondPitch;
        audioSource2.loop = secondLoop;

        // ��������� ������ ���� � �������� �������� ���������
        audioSource1.Play();
        StartCoroutine(FadeInAudio(audioSource1, firstVolume, fadeInDuration1));

        // ��������� �������� ��� ������� ����� � ��������� � ������� ����������
        StartCoroutine(PlaySecondAudioWithDelay());
    }

    IEnumerator PlaySecondAudioWithDelay()
    {
        // ������� �������� ��������
        yield return new WaitForSeconds(delay);

        if (!isStopped) // ���������, ���������� �� ����
        {
            // ����������� ������ ���� � ��������� ������ �������� ���������
            audioSource2.Play();
            StartCoroutine(FadeInAudio(audioSource2, secondVolume, fadeInDuration2));
        }
    }

    IEnumerator FadeInAudio(AudioSource audioSource, float targetVolume, float duration)
    {
        float startVolume = audioSource.volume;
        float time = 0;

        while (time < duration)
        {
            if (isStopped) yield break; // �������������, ���� ���� ��� ��������

            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        audioSource.volume = targetVolume; // ������������� ������� ��������� �����
    }

    public void StopAllAudio()
    {
        // ������������� ��� ������� �����
        audioSource1.Stop();
        audioSource2.Stop();

        // ��������� ��� �������� �������� ���������� ���������
        isStopped = true;
    }
}
