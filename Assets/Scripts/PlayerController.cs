using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 target;
    public bool move = false;

    public int currentWaterInStock = 0;
    public int maxWaterInStock = 4;

    private BoxCollider2D collider;
    
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPos();
        }

        if (move)
        {
            Move();
        }
    }

    public bool ObjectInsideRadius()
    {
        //TODO: hits itself
        RaycastHit2D hit = Physics2D.CircleCast(transform.position + collider.bounds.size, 2f, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.blue, 2f);
        if (hit.collider != null)
        {
            print(hit.collider.gameObject.name);
            return hit;
        }

        return false;
    }
    
    private void SetTargetPos()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.z = transform.position.z;
        move = true;
    }

    private void Move()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, target);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position == target)
        {
            move = false;
        }
    }
}
