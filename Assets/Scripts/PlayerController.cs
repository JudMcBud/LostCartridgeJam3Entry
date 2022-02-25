using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[HideInInspector]
	public string whereTo;
	
	public float speed;
	
	public Rigidbody2D rigidbody;
	
	public Vector3 move;
	
	public Animator animator;
	
	public SpriteRenderer spr;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    	move.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
	    	
	    	rigidbody.transform.position += move;
	    
	    if(move != Vector3.zero)
	    {
	    	animator.SetBool("isWalking", true);
	    }
	    else
	    {
	    	animator.SetBool("isWalking", false);
	    }
	    
	    if(move.x <  0)
	    {
		    spr.flipX = true;
	    }
	    else if(move.x > 0)
	    {
	    	spr.flipX = false;
	    }
    }
    
	public void OnTriggerEnter2D(Collider2D other)
	{
		whereTo = other.GetComponent<Transform>().name;
		Debug.Log(whereTo);
	}
}
