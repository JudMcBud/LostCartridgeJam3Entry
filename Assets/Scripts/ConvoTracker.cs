using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ConvoTracker : MonoBehaviour
{
	private int charCount;
	public Transform characters;
	public Transform[] chars;
	public DialogueDatabase db;
	
    // Start is called before the first frame update
    void Start()
    {
	    foreach(Transform child in characters)
	    {
	    	charCount ++;
	    }
	    
	    chars = new Transform[charCount];
	    
	    for(int i = 0; i < chars.Length; i++)
	    {
	    	chars[i] = characters.transform.GetChild(i);
	    }
    }

    // Update is called once per frame
    void Update()
	{
		if(chars != null)
		{
			foreach(Transform character in chars)
		    {
		    	if(CheckIfReady(character))
		    	{
		    		character.GetComponentInChildren<Transform>().GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
		    	}
		    	else
		    	{
			    	character.GetComponentInChildren<Transform>().GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
		    	}
		    }
		}
	    
    }
    
	public bool CheckIfReady(Transform character)
	{
		string whoIsReady = character.GetComponent<DialogueSystemTrigger>().condition.luaConditions[0].ToString();
		foreach(Variable var in db.variables)
		{
			if(whoIsReady.Contains(var.Name))
			{
				return DialogueLua.GetVariable(var.Name).AsBool;
			}
		}
		return false;
	}
}
