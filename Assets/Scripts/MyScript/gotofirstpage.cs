using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gotofirstpage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void Gohomepage()
	{
		StartCoroutine(LoadHomePage (0.01f));

	}

	IEnumerator LoadHomePage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-1-Advertisement2");
	}

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (LoadHomePage (0.01f));
		}
		#endif
	}
}
