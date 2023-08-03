using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditEmail : MonoBehaviour {
	
	public GameObject InputEmailObj;
	public GameObject InputAccountObj;
	public GameObject MsgForm;

	// Use this for initialization
	void Start () {
		
	}

	public void Editemail()
	{
		Global.register_email = InputEmailObj.GetComponent<UILabel> ().text;
		if (GameObject.FindWithTag ("InputAcc1")) {
			if (GameObject.FindWithTag ("InputAcc1").transform.Find ("accountTxt").GetComponent<UILabel> ().text == "계정 선택") {
				if (GameObject.FindWithTag ("DirectInput1")) {
					Global.register_account = GameObject.FindWithTag ("DirectInput1").transform.Find ("accountTxt1").GetComponent<UILabel> ().text;
				}
			} else {
				Global.register_account = GameObject.FindWithTag ("InputAcc1").transform.Find ("accountTxt").GetComponent<UILabel> ().text;
			}
		} else {
			if (GameObject.FindWithTag ("DirectInput1")) {
				Global.register_account = GameObject.FindWithTag ("DirectInput1").transform.Find ("accountTxt1").GetComponent<UILabel> ().text;
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
			StartCoroutine(LoadPrevPage (0.01f));
		}
	}

	public void cancel()
	{
		StartCoroutine(LoadPrevPage (0.01f));
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-4-MyPage");
	}

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (LoadPrevPage (0.01f));
		}
		#endif
	}
}
