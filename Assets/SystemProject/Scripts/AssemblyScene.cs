using UnityEngine;
using System.Collections.Generic;

public class AssemblyScene : MonoBehaviour
{
    public List<GameObject> components;
    public GameObject selectedComponent;
    public GoalTreeBranch goalRoot;
    public bool clickedThisFrame = false; 
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    public void AssembleComponents(Vector2 interactionPosition,bool downThisFrame) {
	if (selectedComponent == null && downThisFrame)
	{
		foreach (GameObject item in components)
		{	
		   if (item.GetComponent<SpriteRenderer>().bounds.Contains(interactionPosition))
		   {
			   selectedComponent = item;
			   break;
		   }	   
		}	
	}
	else if (downThisFrame)
	{
		selectedComponent = null;
	}

	if (selectedComponent != null)
	{
		selectedComponent.transform.position = interactionPosition;
	}
	clickedThisFrame = true;
    }

    // Update is called once per frame
    void Update()
    {
	    clickedThisFrame = false;

	    if (goalRoot.completed)
	    {
		    Debug.Log("Horay!");
	    }
    }
}
