using UnityEngine;

public class SkyscraperController : MonoBehaviour
{
    public int currentWater = 1;
    public int neededWater;
    public int maxWater = 4;

    private Camera camera;
    
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        // TODO: Display need water above building
        neededWater = maxWater - currentWater;
        
        if (Input.GetMouseButtonDown(0))
        {
            ClickableObject();
        }

    }

    private void ClickableObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Plant"))
            {
                if (GameManager.instance.player.currentWaterInStock > 0)
                {
                    //TODO: Change sprite for greenishness
                    currentWater++;
                    GameManager.instance.player.currentWaterInStock--;
                    neededWater--;
                    print("You have " + GameManager.instance.player.currentWaterInStock + " water");
                }
                else
                {
                    //TODO: UI feedback for failed watering attempt.
                    print("You don't have any water!");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //TODO: fix movement bug.
            GameManager.instance.player.move = false;
        }
    }
}
