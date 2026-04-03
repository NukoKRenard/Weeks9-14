using Unity.Cinemachine; 
using UnityEngine;
using System.Collections.Generic;

public class Building : MonoBehaviour
{
    private List<GameObject> components;
    [SerializeField] private GameObject buildingComponent;

    [SerializeField] private uint maxBuildingHeight = 5;
    private float fallDirection = 1;
    private bool falling = false;
    private float fallTime = 0.0f;
    private bool shakeTriggered = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	    components = new List<GameObject>();
	    uint wantedHeight = (uint)(Random.Range(1,maxBuildingHeight));

	    Debug.Log(wantedHeight);

	    for (uint i = 0; i < wantedHeight; i++)
	    {
		   GameObject part = Instantiate(buildingComponent,gameObject.transform);
		   SpriteRenderer renderer = part.GetComponent<SpriteRenderer>();

		   part.transform.localPosition = new Vector2(0,(renderer.size.y/2)+components.Count*(renderer.size.y-0.5f));

		   components.Add(part);
	    }

	    if (Random.value > 0.5)
	    {
		    fallDirection *= -1;
	    }
    }

    // Update is called once per frame
    void Update()
    {
	   if (falling) {
		   transform.rotation = Quaternion.Lerp(
				   Quaternion.identity,
				   Quaternion.EulerAngles(0,0,(Mathf.PI/2)*fallDirection),
				   fallTime
				   );
		   fallTime += fallTime*Time.deltaTime;
		   if (fallTime > 1)
		   {
			   fallTime = 1;

			   if (!shakeTriggered)
			   {
				   CinemachineImpulseSource impulse = GetComponent<CinemachineImpulseSource>();
				   impulse.GenerateImpulse(Random.insideUnitCircle*components.Count/2);
				   shakeTriggered = true;
			   }
		   }

		   if (fallTime <= 0.0001f)
		   {
			   fallTime = 0.01f/components.Count*Random.Range(0.5f,1.5f);
		   }
	   } 
    }

    public void fall()
    {
	   falling = true; 
    }
}
