using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Turn : MonoBehaviour
{
    public Button button;
    public string name;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    } 
 
    private bool turnFinished = false;
    public void completeTurn() {
	    turnFinished = true;
    }


    public IEnumerator doTurn() {
            button.enabled = true;
	    Debug.Log("Started Turn!");

	     while (!turnFinished) {yield return null;}
	     
	     Debug.Log("Turn Complete!");
	     turnFinished = false;
             button.enabled = false;
      }
    // Update is called once per frame
    void Update()
    {
        
    }
}
