using UnityEngine;

public class AudioZoneTrigger : MonoBehaviour
{
    public AudioSource audioSource;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Play();

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }

    void Update()
    {
        if (audioSource.isPlaying)
        {
            float distance = Vector3.Distance(audioSource.transform.position, Camera.main.transform.position);
            audioSource.volume = 1.0f - Mathf.Clamp01(distance / audioSource.maxDistance);
        }
    }
}
