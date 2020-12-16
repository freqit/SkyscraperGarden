using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerManager controller;
    
    private void Awake()
    {
        controller = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        // Player movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            controller.Move(new Vector2(0f, 1f));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            controller.Move(new Vector2(0f, -1f));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            controller.Move(new Vector2(-1f, 0f));
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            controller.Move(new Vector2(1f, 0f));
        }
        
        // Game quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}