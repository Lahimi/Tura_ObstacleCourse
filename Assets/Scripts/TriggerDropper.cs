using UnityEngine;

public class TriggerDropper : MonoBehaviour
{
    [SerializeField] GameObject targetDropper; // Drag your Triggered Dropper object here

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetDropper != null)
            {
                // Enable visibility
                MeshRenderer mesh = targetDropper.GetComponent<MeshRenderer>();
                if (mesh != null)
                {
                    mesh.enabled = true;
                }

                // Enable full physical collision
                Rigidbody rb = targetDropper.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }
            }
        }
    }
}