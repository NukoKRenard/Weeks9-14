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

    public void switchScenes() {
	    switchFunctions[uiSwitcher].Invoke();
	    cursor.sceneInteraction = interactionFunction[uiSwitcher];

	    uiSwitcher = (int)(uiSwitcher+1)%switchFunctions.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
