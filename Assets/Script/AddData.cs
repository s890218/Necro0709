using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AddData : MonoBehaviour {

	AsyncOperation ao = null;

	private void Start()
	{
		ao = SceneManager.LoadSceneAsync (1);		
	}

	private void Update()
	{
		if (ao != null) 
		{
			Debug.Log (ao.progress);
		}
	}
	
}
