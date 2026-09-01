using UnityEngine;

public class FlyAtPlayer : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float speed = 5f;
    [SerializeField] AudioSource launchAudioSource; // Audio reference for launch sound

    Vector3 targetPosition;

    void Start()
    {
        if (playerTransform != null)
        {
            targetPosition = playerTransform.position;
        }

        // Play launch sound when spawned/activated
        if (launchAudioSource != null)
        {
            launchAudioSource.PlayOneShot(launchAudioSource.clip);
        }
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}