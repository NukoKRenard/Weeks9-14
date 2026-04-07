using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class Dialog : MonoBehaviour
{
    public GameObject charachter;	
    public Image avaxDialog;
    public SpriteRenderer vriek;
    public TMP_Text englishDialog;
    public TMP_Text englishResponsesButton;
    public GameObject textBubble;
    public GameObject responseButton;

    //Couldn't use Ink so I have to store everything in a number of lists.
    public List<Sprite> avaxDialogBeats;
    public List<Sprite> vriekPoses;
    public List<string> englishDialogBeats;
    public List<string> englishResponseBeats;
    // Start is called once before the first execution 0f update after the MonoBehaviour is created
    public bool userResponded = false;
    
    void Start()
    {
        
    }

    public void Respond() {
           userResponded = true; 
    }
    //Why is this a coroutine? Because I want the marks.
    //(Also it lets me more easily create an ends screen when dialog ends)
    public IEnumerator playDialog() {
	    charachter.SetActive(true);
	    Debug.Log("StartingDialog");
 	    gameObject.SetActive(true);
           int beatNumber = 0;
           foreach (string response in englishResponseBeats) {    
	   englishResponsesButton.text = englishResponseBeats[beatNumber];
	   avaxDialog.sprite = avaxDialogBeats[beatNumber];
	   englishDialog.text = englishDialogBeats[beatNumber];
	   vriek.sprite = vriekPoses[beatNumber];
	   beatNumber+=1; 
	   while (!userResponded)
	   {
		   yield return null;
	   }
	   
	   //Flips the sprite horizontally so that it appears more dynamic (Saves on image space for different sprite rotations as well.)
	   vriek.flipX = !vriek.flipX;
	
	   userResponded = false;
	   }
	   yield return new WaitForSeconds(2);

	   gameObject.SetActive(false);
	   charachter.SetActive(false);	   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
