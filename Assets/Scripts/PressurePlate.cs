using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] GameObject plateWall;
    [SerializeField] AudioSource plateAudioSource; // Reference to the sound effect

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            if (plateWall != null)
            {
                plateWall.SetActive(false); // Disables the wall[cite: 8]
            }

            // Play the pressure plate trigger sound
            if (plateAudioSource != null)
            {
                plateAudioSource.PlayOneShot(plateAudioSource.clip);
            }
        }
    }
}