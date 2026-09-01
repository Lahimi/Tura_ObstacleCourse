using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] AudioSource moveAudioSource; // Drag AudioSource here

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = 0f;
        float z = Input.GetAxis("Vertical");

        Vector3 inputVector = new Vector3(x, y, z).normalized * Time.deltaTime;

        GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        transform.Translate(inputVector * speed);

        // Play sound if player is moving, stop if stationary
        if (moveAudioSource != null)
        {
            if (inputVector != Vector3.zero)
            {
                if (!moveAudioSource.isPlaying)
                {
                    moveAudioSource.Play();
                }
            }
            else
            {
                moveAudioSource.Stop();
            }
        }
    }
}