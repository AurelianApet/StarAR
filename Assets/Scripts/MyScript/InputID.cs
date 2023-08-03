using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputID : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void GoHome()
	{
		StartCoroutine (LoadHomeScene (0.01f));
	}

	private IEnumerator LoadHomeScene(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-1-Advertisement2");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
