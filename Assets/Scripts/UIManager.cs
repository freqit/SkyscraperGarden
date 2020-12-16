using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text waterText;
    public Text timeText;
    
    void Update()
    {
        waterText.text = "Water: " + GameManager.instance.player.currentWaterInStock.ToString();
        timeText.text = "Time: " + GameManager.instance.tick.ToString();
    }
}
