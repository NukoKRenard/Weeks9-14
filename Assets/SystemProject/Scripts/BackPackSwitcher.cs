using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class BackPackSwitcher : MonoBehaviour
{
    public Cursor cursor;
    public List<UnityEvent> switchFunctions;
    public List<UnityEvent<Vector2,bool>> interactionFunction;
    int uiSwitcher = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //When the backpack buttin is switched, load the new game object and switch the cursor interaction function.
    public void switchScenes() {
	    switchFunctions[uiSwitcher].Invoke();
	    cursor.sceneInteraction = interactionFunction[uiSwitcher];

	    //I use modulus here to get the index to loop back depending on the amount of scenes. Although its not required for this project, it is more scalable.
	    uiSwitcher = (int)(uiSwitcher+1)%switchFunctions.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
