using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5f;
    private Vector3 target;
    public bool move = false;
    
    void Start()
    {
        
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
