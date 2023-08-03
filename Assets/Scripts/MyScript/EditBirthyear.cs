using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditBirthyear : MonoBehaviour {
	public GameObject InputBirthYearObj;
	public GameObject MsgForm;

	// Use this for initialization
	void Start () {
		if(MsgForm)
			MsgForm.SetActive (false);
	}

	public void confirm()
	{
		Global.register_birth_year = InputBirthYearObj.GetComponent<UILabel> ().text;
		if (Global.register_birth_year != "" && Global.register_birth_year != null)
			StartCoroutine (LoadPrevPage (0.01f));
		else {
			MsgForm.SetActive (true);
			MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "출생년도를 입력하세요";
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
