using UnityEngine;
using System.Collections.Generic;
public class GoalTreeBranch : MonoBehaviour
{
    public bool completed = false;
    public List<GoalTreeBranch> childNodes;
    public Sprite completedSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	bool allComplete = true;
	foreach (GoalTreeBranch branch in childNodes) {
	
	}

    }
}
