using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector2> OnMove = new UnityEvent<Vector2>();
    public UnityEvent OnJump = new UnityEvent();
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnJump?.Invoke();
        }

        Vector2 input = Vector2.zero;
        if(InputManager.GetKey(KeyCode.W))
        {
            input += Vector2.up;
        }

        if(InputManager.GetKey(KeyCode.S))
        {
            input += Vector2.down;
        }

        if(InputManager.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }

        if(InputManager.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }

        
    }
}
