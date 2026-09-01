using UnityEngine;

public class TriggerMissile : MonoBehaviour
{
    [SerializeField] GameObject missilePrefab;
    [SerializeField] GameObject missilePrefab2;
    [SerializeField] GameObject missilePrefab3;
    [SerializeField] GameObject missilePrefab4;
    [SerializeField] GameObject missilePrefab5;

    void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.tag == "Player")
        {
            missilePrefab.SetActive(true);
            missilePrefab2.SetActive(true);
            missilePrefab3.SetActive(true);
            missilePrefab4.SetActive(true);
            missilePrefab5.SetActive(true);
        }
    }
}
