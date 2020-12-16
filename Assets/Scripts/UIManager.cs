using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text waterText;
    
    void Update()
    {
        waterText.text = "Water: " + GameManager.instance.player.currentWaterInStock.ToString();
    }
}
