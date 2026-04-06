using UnityEngine;
using System.Collections.Generic;
public class GoalTreeBranch : MonoBehaviour
{
    public bool completed = false;
    public List<GoalTreeBranch> childNodes;
    public SpriteRenderer myGoal;
    public Sprite completedSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void acknowledgeCompletion() {
	   gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
	bool allComplete = true;
	if (childNodes.Count > 0)
	{
		foreach (GoalTreeBranch branch in childNodes) {
			if (!branch.completed)
			{
				allComplete = false;
			}
		}
	}

	if (allComplete && myGoal.bounds.Contains(transform.position))
	{
                Debug.Log("Completed part");		
		completed = true;
	}
	if (allComplete) 
	{
		
		foreach (GoalTreeBranch branch in childNodes)
		{
			branch.acknowledgeCompletion(); 
		}
	}
	if (completedSprite != null && allComplete)
		{
			GetComponent<SpriteRenderer>().sprite = completedSprite;
			Debug.Log("changingSprite!");
		}

    }
}
