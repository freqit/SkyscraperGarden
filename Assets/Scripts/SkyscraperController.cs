using TMPro;
using UnityEngine;

public class SkyscraperController : MonoBehaviour
{
    public int currentWater = 1;
    public int neededWater;
    public int maxWater = 4;

    public TMP_Text needText;

    void Start()
    {
    }

    void Update()
    {
        if (neededWater <= 0)
        {
            neededWater = 0;
        }
        
        neededWater = maxWater - currentWater;
        needText.text = neededWater.ToString();
    }
}
