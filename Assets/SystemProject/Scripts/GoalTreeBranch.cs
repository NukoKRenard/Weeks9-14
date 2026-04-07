using UnityEngine;
using System.Collections.Generic;
public class GoalTreeBranch : MonoBehaviour
{
    public bool completed = false;
    public List<GoalTreeBranch> childNodes;
    public SpriteRenderer myGoal;
    public Sprite completedSprite;
    private bool firstComplete = true;
    public bool hideWhenGoalReached = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //If the object is complete hide the object.
    public void acknowledgeCompletion() {
	    if (hideWhenGoalReached)
	    {
		    gameObject.SetActive(false); 
	    }
    }

    public void stateFullyAssembled() {
	    gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
	//Checks if all of the child goals are completed.
	bool allComplete = true;
	if (childNodes.Count > 0)
	{
		foreach (GoalTreeBranch branch in childNodes) {
			if (!branch.completed)
			{
				allComplete = false;
			}
			else
			{
				branch.acknowledgeCompletion();
			}
		}
	}

	//If all of the goals are complete and this sprite is at its goal, set this sprite to complete.
	if (allComplete && myGoal.bounds.Contains(transform.position))
	{
		completed = true;

		foreach (GoalTreeBranch branch in childNodes)
		{
			branch.stateFullyAssembled();
		}
	}
	if (completedSprite != null && allComplete && firstComplete)
		{
			GetComponent<SpriteRenderer>().sprite = completedSprite;
			firstComplete = false;
		}

    }
}
