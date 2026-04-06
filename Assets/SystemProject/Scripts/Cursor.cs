using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Cursor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public bool interacting = false;
    public UnityEvent<Vector2,bool> sceneInteraction;
    

    void Start()
    {
        
    }

    public void MoveCursor(InputAction.CallbackContext movement) {
	    transform.position = (Vector2)Camera.main.ScreenToWorldPoint(movement.ReadValue<Vector2>());
	    Vector2 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0,0));
	    Vector2 topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

	    if (transform.position.x < bottomLeft.x)
	    {
		    transform.position = new Vector2(bottomLeft.x,transform.position.y);
	    }
	    else if (transform.position.x > topRight.x)
	    {
		    transform.position = new Vector2(topRight.x,transform.position.y);
	    }
	    
	    if (transform.position.y < bottomLeft.y)
	    {
		    transform.position = new Vector2(transform.position.x,bottomLeft.y);
	    }
	    else if (transform.position.y > topRight.y)
	    {
		    transform.position = new Vector2(transform.position.x,topRight.y);
	    }
    }

    public void interactWithItem(InputAction.CallbackContext click)
    {
	    if (click.performed)
	    {
		   sceneInteraction.Invoke(transform.position,true);
		   interacting = true; 
	    }
	    else if (click.canceled)
	    {
		    interacting = false;
	    }
    }

    // Update is called once per frame
    void Update()
    {
	   if (interacting)
	   {
		   sceneInteraction.Invoke(transform.position,false);
	   } 
    }
}
