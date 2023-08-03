using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advertisement2Manager : MonoBehaviour {
	#region UNITY_MONOBEHAVIOUR_METHODS

	public GameObject MsgForm;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			MsgForm.SetActive (true);
			MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "Star AR 앱을 종료하시겠습니까?";
//			StartCoroutine (LoadHomePage (0.01f));
		}
		#endif
	}

	public void onLogin()
	{
		StartCoroutine(LoadLoginPage (0.01f));
	}

	public void onRegister()
	{
		StartCoroutine(LoadRegisterPage (0.01f));
	}

	public void onLogo()
	{
		StartCoroutine(LoadHomePage (0.01f));
	}

	private IEnumerator LoadRegisterPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register1");
	}

	private IEnumerator LoadLoginPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-3-LoginScene");
	}

	private IEnumerator LoadHomePage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-0-Splash");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
