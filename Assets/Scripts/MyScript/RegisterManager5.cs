using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterManager5 : MonoBehaviour {

	#region UNITY_MONOBEHAVIOUR_METHODS
	public GameObject MsgForm;

	// Use this for initialization
	void Start () {
		Global.register_married = 0;
		if(MsgForm)
			MsgForm.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (LoadPrevPage (0.01f));
		}
		#endif
	}

	public void onNextButton()
	{
		if (Global.register_married != 0)
			StartCoroutine (LoadNextPage (0.01f));
		else {
			MsgForm.SetActive (true);
			MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "결혼여부를 선택하세요";
		}
	}

	private IEnumerator LoadNextPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register6");
	}

	public void onPrevButton()
	{
		StartCoroutine(LoadPrevPage (0.01f));
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register4");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
