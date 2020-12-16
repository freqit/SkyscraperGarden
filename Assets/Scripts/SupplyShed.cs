using UnityEngine;

public class SupplyShed : MonoBehaviour
{
    public int waterPerClick = 1;
    
    private Camera camera;
    
    void Start()
    {
        camera = Camera.main;    
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AddSupplies();
        }
    }
    
    private void AddSupplies()
    {
        RaycastHit2D hit = Physics2D.Raycast(camera.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            if (hit.transform.CompareTag("Supplies") && GameManager.instance.player.ObjectInsideRadius())
            {
                if (GameManager.instance.player.currentWaterInStock < GameManager.instance.player.maxWaterInStock)
                {
                    GameManager.instance.player.currentWaterInStock += waterPerClick;
                    print(GameManager.instance.player.currentWaterInStock);
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
