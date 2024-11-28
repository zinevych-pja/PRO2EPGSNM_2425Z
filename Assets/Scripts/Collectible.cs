using UnityEngine;

public class Collectible : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.GetComponent<CollectibleCounter>().IncreaseCounter();
            gameObject.SetActive(false);
        }
    }
}
