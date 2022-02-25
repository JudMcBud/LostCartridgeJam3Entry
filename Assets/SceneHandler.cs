using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class SceneHandler : MonoBehaviour
{
	public static bool hasRun = false;
	
	private GameObject convoTracker;
	
	public GameObject detective;
	
	private static Vector3 defaultPos = new Vector3(-4.26000023f,-1.01999998f,0.603052139f);
	
	void Awake()
	{
		if(hasRun == false)
		{
			for(int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
			{
				PlayerPrefs.SetFloat("pos" + i.ToString(), -4.26000023f);
			}
			
			hasRun = true;
		}
		
	}
	
	void Start()
	{
		PlayerPrefs.SetInt("currentSceneIndex", SceneManager.GetActiveScene().buildIndex);
		
		if(PlayerPrefs.GetFloat("pos" + PlayerPrefs.GetInt("currentSceneIndex")) != null)
		{
			detective.GetComponent<Transform>().position = new Vector3(PlayerPrefs.GetFloat("pos" + PlayerPrefs.GetInt("currentSceneIndex")), detective.transform.position.y, detective.transform.position.z);
		}
		else
		{
			detective.GetComponent<Transform>().position = defaultPos;
		}
		
		convoTracker = GameObject.Find("ConvoTracker");
	}
	
	void CheckFinalScene()
	{
		if(DialogueLua.GetVariable("detSaysYes").AsBool)
		{
			LoadFinalSequence();
		}
	}
	
	public void LoadScene()
	{
		PlayerPrefs.SetFloat("pos" + PlayerPrefs.GetInt("currentSceneIndex"), detective.transform.position.x);
		SceneManager.LoadScene(detective.GetComponent<PlayerController>().whereTo);
	}
	
	public void LoadFinalSequence()
	{
		SceneManager.LoadScene("FinalScene");
	}
	
	public static void Quit()
	{
		Application.Quit();
	}

}
