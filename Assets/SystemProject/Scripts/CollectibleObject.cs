//This class does nothing except store data.
using UnityEngine;

public class CollectibleObject : MonoBehaviour
{
    public GameObject addedItem;
    public SpriteRenderer renderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
