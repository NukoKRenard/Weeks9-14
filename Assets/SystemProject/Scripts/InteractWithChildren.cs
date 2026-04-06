using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

public class InteractWithChildren : MonoBehaviour
{
    public List<GameObject> interactables;
    public AssemblyScene assemblyScene;
    public Cursor cursor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void checkComponents(Vector2 interactionPosition, bool downThisFrame) {
	   CollectibleObject cod;
	   foreach (GameObject collectible in interactables)
	   {
		   cod = collectible.GetComponent<CollectibleObject>();
		   if (cod.renderer.bounds.Contains(interactionPosition) && downThisFrame)
		   {
			   assemblyScene.components.Add(cod.addedItem);
			   cod.addedItem.SetActive(true);
			   interactables.Remove(collectible);
			   Destroy(collectible);
			   break;
		   }
	   }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
