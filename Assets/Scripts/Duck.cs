using UnityEngine;

public class Duck : MonoBehaviour
{
    private float timePassed = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.rotation =  Quaternion.EulerAngles(0,0,timePassed);
       timePassed += Time.deltaTime;
    }
}
