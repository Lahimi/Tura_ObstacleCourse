using UnityEngine;

public class Dropper : MonoBehaviour
{
    float timeToDrop = 3f; //[cite: 1]
    Rigidbody rb; //[cite: 1]
    MeshRenderer mesh; //[cite: 1]

    void Start()
    {
        mesh = GetComponent<MeshRenderer>(); //[cite: 1]
        rb = GetComponent<Rigidbody>(); //[cite: 1]

        mesh.enabled = false; //[cite: 1]
        rb.useGravity = false; //[cite: 1]
    }

    void Update()
    {
        if (Time.time > timeToDrop) //[cite: 1]
        {
            DropObject(); //[cite: 1]
        }
    }

    public void DropObject()
    {
        mesh.enabled = true; //[cite: 1]
        rb.useGravity = true; //[cite: 1]
        rb.isKinematic = false; // Disables Kinematic so collisions register properly
    }
}