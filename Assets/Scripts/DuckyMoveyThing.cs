using UnityEngine;
using UnityEngine.InputSystem;
public class DuckyMoveyThing : MonoBehaviour
{
    [SerializeField] private GameObject Duck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnDuck(InputAction.CallbackContext input) {

	   if (input.performed)
	   {
		   Instantiate(Duck,input.ReadValue<Vector2>(),Quaternion.identity); 

	   }
    }
}
