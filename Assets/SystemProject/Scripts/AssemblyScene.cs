using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Collections;

public class AssemblyScene : MonoBehaviour
{
    public List<GameObject> components;
    public GameObject selectedComponent;
    public GoalTreeBranch goalRoot;
    public bool clickedThisFrame = false; 
    bool completedThisFrame = true;
    public Sprite[] capsuleFlashSprites;
    public SpriteRenderer capsuleRenderer;
    public GameObject ui;
    public GameObject closingMessage;

    public GameObject skipButton;

    public Dialog dialog;

    private Coroutine cutsceneCoroutine;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    //Allows the cursor to move the objects.
    public void AssembleComponents(Vector2 interactionPosition,bool downThisFrame) {
	if (selectedComponent == null && downThisFrame)
	{
		foreach (GameObject item in components)
		{	
		   if (item.GetComponent<SpriteRenderer>().bounds.Contains(interactionPosition) && item.activeInHierarchy)
		   {
			   //Once a selected item is found then set it to active.
			   selectedComponent = item;
			   break;
		   }	   
		}	
	}
	//If there is an active object and the user clicks, drop it.
	else if (downThisFrame)
	{
		selectedComponent = null;
	}

	//If there is a selected object, put it at the same position as the mouse.
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

	    //If the goal is completed, then start the dialog.
	    if (goalRoot.completed && completedThisFrame)
	    {
		    completedThisFrame = false;
		    StartCoroutine(DialogOpeningCutscene(false));
	    }
    }

    //This coroutine manages the dialog of the charachter and the cutscene.
    IEnumerator DialogOpeningCutscene(bool skipCutscene) {
	    
	    if (!skipCutscene)
	    {
		    yield return new WaitForSeconds(2);
		    cutsceneCoroutine = StartCoroutine(Flash());
		    yield return cutsceneCoroutine;
		    Debug.Log("Coroutine over");
	    }
	    //In case the skip cutscene coroutine is stopped.
	    capsuleRenderer.sprite = capsuleFlashSprites[1];
	    yield return StartCoroutine(dialog.playDialog());

	    ui.SetActive(false);
	    closingMessage.SetActive(true);
	    Debug.Log("Dialog complete!");
    }

    //The reason this is a function instead of using a string is a personal preference. I prefer not to use strings to select items as a misspelling could result in undefined behavior.
    public void CancelCutscene() {
	    //If the user skips the cutscene, restart the dialog without the cutscene at the beginning.
	    StopCoroutine(cutsceneCoroutine); 
	    skipButton.SetActive(false);
	    cutsceneCoroutine = StartCoroutine(DialogOpeningCutscene(true));
    }

    //Flashes the sprite light on and off.
    IEnumerator Flash() {
	    skipButton.SetActive(true); 

	    for (int i = 0; i < 5; i+=1) {
		    capsuleRenderer.sprite = capsuleFlashSprites[0];
		    yield return new WaitForSeconds(1);
		    capsuleRenderer.sprite = capsuleFlashSprites[1];
		    yield return new WaitForSeconds(1);
	    }

	    skipButton.SetActive(false);
    }

}
