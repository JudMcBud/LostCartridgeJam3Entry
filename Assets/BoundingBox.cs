using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{
	public GameObject detective;
    // Update is called once per frame
    void Update()
    {
	    if(detective.transform.position.x > 4.5)
	    {
	    	detective.GetComponent<Transform>().position  = new Vector3(4.5f, detective.transform.position.y, detective.transform.position.z);
	    }
	    else if(detective.transform.position.x < -4.5)
	    {
	    	detective.GetComponent<Transform>().position  = new Vector3(-4.5f, detective.transform.position.y, detective.transform.position.z);
	    }
    }
}
