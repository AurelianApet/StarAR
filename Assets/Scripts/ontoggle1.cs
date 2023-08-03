using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ontoggle1 : MonoBehaviour {
	public GameObject toggle1;
	public GameObject toggle2;
	public GameObject point;
	public GameObject scan;
	public GameObject mypage;

	public GameObject MsgForm;
	public UITexture back;
	// Use this for initialization
	void Start () {
		if(MsgForm)
			MsgForm.SetActive (false);

		if (Global.path2 != "" && Global.path2 != null ) {
			string url = "file:///" + Global.path2;
			StartCoroutine (setImage (back, url));
		}
	}


	IEnumerator setImage(UITexture tex, string url)
	{
		WWW www = new WWW (url);
		yield return www;
		back.mainTexture = www.texture;
	}

	public void onToggle()
	{
		toggle1.SetActive (false);
		toggle2.SetActive (true);
		point.SetActive (true);
		scan.SetActive (true);
		mypage.SetActive (true);
	}

	public void outToggle()
	{
		MsgForm.SetActive (true);
		MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "Star AR 앱을 종료하시겠습니까?";
	}

	#region UNITY_MONOBEHAVIOUR_METHODS

	public void onScanPage()
	{
//		StartCoroutine(LoadScanPage (0.01f));
	}

	public void GotoMyPage()
	{
		StartCoroutine(LoadMyPage (0.01f));
	}

	private IEnumerator LoadScanPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-4-CloudRecognition");
	}

	private IEnumerator LoadMyPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-4-MyPage");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS

	// Update is called once per frame
	void Update () {
		
	}
}
