using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditSex : MonoBehaviour {
	public GameObject MsgForm;

	// Use this for initialization
	void Start () {
		if(MsgForm)
			MsgForm.SetActive (false);		
	}

	public void confirm()
	{
		if (Global.register_sex != 0)
			StartCoroutine (LoadPrevPage (0.01f));
		else {
			MsgForm.SetActive (true);
			MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "성별을 선택하세요";
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
		
	}
}
