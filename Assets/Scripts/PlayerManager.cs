using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int currentWaterInStock = 0;
    public int maxWaterInStock = 4;
    
    public LayerMask obstacleLayerMask;

    private BoxCollider2D collider;
    
    public enum PlayerState
    {
        IDLE,
        MOVE,
        ACTION,
    }

    public PlayerState playerState;
    
    public void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        GameManager.instance.tick--;
        Vector2 isWalkable = direction.normalized;

        RaycastHit2D hit = Physics2D.Raycast(collider.bounds.center, isWalkable, 1f, obstacleLayerMask);

        if (hit.collider != null)
        {
            // Now we can access the gameobject and check if its a gatherable resource.
            if (InteractWithObstacle(hit.collider.gameObject))
            {
                playerState = PlayerState.ACTION;
            }

        }
        else
        {
            // if no obstacle then we can move.
            transform.Translate(direction);
            playerState = PlayerState.MOVE;
        }
    }

    private bool InteractWithObstacle(GameObject obj)
    {

        if (obj.CompareTag("Gatherable"))
        {
            ItemStack itemStack = obj.GetComponent<GatherableObject>().GatherObject();
            if (currentWaterInStock < maxWaterInStock)
            {
                // Debug prints
                print("You get " + itemStack.Value + " " + itemStack.Item.Name);
                currentWaterInStock += itemStack.Value;
            }
            return true;
        }

        if (obj.CompareTag("Plant"))
        {
            if (currentWaterInStock > 0)
            {

                if (obj.gameObject.GetComponent<SkyscraperController>().currentWater ==
                    obj.gameObject.GetComponent<SkyscraperController>().maxWater)
                {
                    // TODO: stuff
                    return false;
                }
                else
                {
                    currentWaterInStock--;
                    obj.gameObject.GetComponent<SkyscraperController>().currentWater++;
                    var sky = obj.gameObject.GetComponent<SkyscraperController>();
                    obj.gameObject.GetComponent<SpriteRenderer>().sprite = sky.planted;
                    GameManager.instance.tick += 4;
                }

                return true;
            }
        }
        return false;
    }
}
