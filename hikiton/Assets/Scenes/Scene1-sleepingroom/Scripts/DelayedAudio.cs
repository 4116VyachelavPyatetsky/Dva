using UnityEngine;
using System.Collections;

public class DelayedAudio : MonoBehaviour
{
    [Header("Первый аудиоклип")]
    public AudioClip firstClip;
    public float firstVolume = 1.0f;             // Целевая громкость первого звука
    public float firstPitch = 1.0f;              // Высота первого звука
    public bool firstLoop = false;               // Зацикливание первого звука
    public float fadeInDuration1 = 2.0f;         // Длительность плавного появления первого звука

    [Header("Второй аудиоклип")]
    public AudioClip secondClip;
    public float secondVolume = 1.0f;            // Целевая громкость второго звука
    public float secondPitch = 1.0f;             // Высота второго звука
    public bool secondLoop = false;              // Зацикливание второго звука
    public float delay = 2.0f;                   // Задержка перед проигрыванием второго звука
    public float fadeInDuration2 = 2.0f;         // Длительность плавного появления второго звука

    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private bool isStopped = false;              // Флаг для остановки всех звуков

    void Start()
    {
        // Создаем два источника звука
        audioSource1 = gameObject.AddComponent<AudioSource>();
        audioSource2 = gameObject.AddComponent<AudioSource>();

        // Привязываем клипы к источникам
        audioSource1.clip = firstClip;
        audioSource2.clip = secondClip;

        // Настраиваем начальные параметры (громкость 0 для плавного появления)
        audioSource1.volume = 0.0f;
        audioSource1.pitch = firstPitch;
        audioSource1.loop = firstLoop;

        audioSource2.volume = 0.0f;
        audioSource2.pitch = secondPitch;
        audioSource2.loop = secondLoop;

        // Запускаем первый звук с эффектом плавного появления
        audioSource1.Play();
        StartCoroutine(FadeInAudio(audioSource1, firstVolume, fadeInDuration1));

        // Запускаем корутину для второго звука с задержкой и плавным появлением
        StartCoroutine(PlaySecondAudioWithDelay());
    }

    IEnumerator PlaySecondAudioWithDelay()
    {
        // Ожидаем заданную задержку
        yield return new WaitForSeconds(delay);

        if (!isStopped) // Проверяем, остановлен ли звук
        {
            // Проигрываем второй звук и запускаем эффект плавного появления
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
            if (isStopped) yield break; // Останавливаем, если звук был отключен

            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            yield return null;
        }

        audioSource.volume = targetVolume; // Устанавливаем целевую громкость точно
    }

    public void StopAllAudio()
    {
        // Останавливаем все текущие звуки
        audioSource1.Stop();
        audioSource2.Stop();

        // Отключаем все корутины плавного увеличения громкости
        isStopped = true;
    }
}
