using UnityEngine;

public class SkyscraperController : MonoBehaviour
{
    public int currentWater = 1;
    public int neededWater;
    private int maxWater = 4;

    void Start()
    {

    }

    void Update()
    {
        neededWater = maxWater - currentWater;

        if (Input.GetMouseButtonDown(0))
        {
            CheckTarget();
        }

    }

    private void CheckTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Plant"))
            {
                if (GameManager.instance.player.currentWaterInStock > 0)
                {
                    currentWater++;
                    GameManager.instance.player.currentWaterInStock--;
                    neededWater--;
                    print("You have " + GameManager.instance.player.currentWaterInStock + " water");
                }
                else
                {
                    print("You don't have any water!");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.player.move = false;
        }
    }
}
