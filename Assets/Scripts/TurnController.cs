using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TurnController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is create

    [SerializeField] private List<Turn> turnList;


    IEnumerator Start()
    {
	    foreach (Turn turn in turnList)
	    {
		    turn.button.enabled = false;
	    }

	    for (int i = 0; i < 3; i++) {
		    Debug.Log("Starting round: "+i);
		    yield return StartCoroutine(doRound());
	    }
    }

    private int turnNum = 0;
    IEnumerator doRound() {
	   foreach (Turn turn in turnList)
	    {
		   Coroutine currentTurn = StartCoroutine(turn.doTurn());
		   Debug.Log("Starting turn: "+turn.name);
		   yield return currentTurn;
	    } 
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
