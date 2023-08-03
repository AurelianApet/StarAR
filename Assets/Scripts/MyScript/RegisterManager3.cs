using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterManager3 : MonoBehaviour {

	public GameObject InputEmailObj;
	public GameObject InputAccountObj;
	public GameObject MsgForm;

	#region UNITY_MONOBEHAVIOUR_METHODS

	// Use this for initialization
	void Start () {
		if(MsgForm)
			MsgForm.SetActive (false);
		
		Global.register_email = "";
		Global.register_account = "";
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
		Global.register_email = InputEmailObj.GetComponent<UILabel> ().text;
		if (GameObject.FindWithTag ("InputAcc")) {
			if (GameObject.FindWithTag ("InputAcc").transform.Find ("accountTxt").GetComponent<UILabel> ().text == "계정 선택") {
				if (GameObject.FindWithTag ("DirectInput")) {
					Global.register_account = GameObject.FindWithTag ("DirectInput").transform.Find ("accountTxt1").GetComponent<UILabel> ().text;
				}
			} else {
				Global.register_account = GameObject.FindWithTag ("InputAcc").transform.Find ("accountTxt").GetComponent<UILabel> ().text;
			}
		} else {
			if (GameObject.FindWithTag ("DirectInput")) {
				Global.register_account = GameObject.FindWithTag ("DirectInput").transform.Find ("accountTxt1").GetComponent<UILabel> ().text;
			}
		}
		if (Global.register_email == "" || Global.register_email == "이메일") {
			MsgForm.SetActive (true);
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = "이메일주소를 정확히 입력하세요";

		} else if (Global.register_account == "" || Global.register_account == "계정 선택") {
			MsgForm.SetActive (true);
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = "계정을 선택하세요";

		}
		else
		{
			StartCoroutine(LoadNextPage (0.01f));
		}
	}

	private IEnumerator LoadNextPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register4");
	}

	public void onPrevButton()
	{
		StartCoroutine(LoadPrevPage (0.01f));
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register2");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
