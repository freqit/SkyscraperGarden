using UnityEngine;

public class SkyscraperController : MonoBehaviour
{
    public int currentWater = 1;
    public int neededWater;
    public int maxWater = 4;

    void Start()
    {
    }

    void Update()
    {
        // TODO: Display need water above building
        neededWater = maxWater - currentWater;
    }
}
