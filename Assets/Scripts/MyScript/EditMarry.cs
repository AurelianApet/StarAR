using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditMarry : MonoBehaviour {
	public GameObject MsgForm;

	// Use this for initialization
	void Start () {
		if(MsgForm)
			MsgForm.SetActive (false);
		
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

	public void confirm()
	{
		if (Global.register_married != 0)
			StartCoroutine (LoadPrevPage (0.01f));
		else {
			MsgForm.SetActive (true);
			MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "결혼여부를 선택하세요";
		}
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
