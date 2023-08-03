using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterManager4 : MonoBehaviour {

	public GameObject InputBirthYearObj;
	public GameObject MsgForm;
	#region UNITY_MONOBEHAVIOUR_METHODS

	// Use this for initialization
	void Start () {
		if(MsgForm)
			MsgForm.SetActive (false);
		Global.register_birth_year = "";
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
		Global.register_birth_year = InputBirthYearObj.GetComponent<UILabel> ().text;
		if (Global.register_birth_year != "" && Global.register_birth_year != null)
			StartCoroutine (LoadNextPage (0.01f));
		else {
			MsgForm.SetActive (true);
			MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "출생년도를 입력하세요";
		}
	}

	private IEnumerator LoadNextPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register5");
	}

	public void onPrevButton()
	{
		StartCoroutine(LoadPrevPage (0.01f));
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register3");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
