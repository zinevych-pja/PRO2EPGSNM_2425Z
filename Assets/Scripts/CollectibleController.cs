using UnityEngine;

public class CollectibleController : MonoBehaviour
{

    public int count = 0;

    public void Increase()
    {
        count++;
    }

    public void Save()
    {
        SaveData.instance.collectiblesCount = count;
    }

    public void Load()
    {
        count = SaveData.instance.collectiblesCount;
    }
}