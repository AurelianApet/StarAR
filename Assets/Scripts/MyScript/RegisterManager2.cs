using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class RegisterManager2 : MonoBehaviour {

	public GameObject inputIdBox;
	public GameObject inputPwdBox;
	public GameObject inputPwdBox1;
	public GameObject MsgForm;

	#region UNITY_MONOBEHAVIOUR_METHODS

	// Use this for initialization
	void Start () {
		if(MsgForm)
			MsgForm.SetActive (false);
		Global.register_id = "";
		Global.register_pwd = "";
	}

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (LoadPrevPage (0.01f));
		}
		#endif
	}

	private void Reset_field(){
		inputIdBox.GetComponent<UIInput> ().value = "";
		inputPwdBox.GetComponent<UIInput> ().value = "";
		inputPwdBox1.GetComponent<UIInput> ().value = "";
	}

	private bool IsCorrectPassword()
	{
		Global.register_pwd = inputPwdBox.GetComponent<UIInput>().value;
		string login_confirm_pwd = inputPwdBox1.GetComponent<UIInput>().value;
		if(login_confirm_pwd == "" || Global.register_id == "아이디" || Global.register_id == null || Global.register_id == "" ) 
		{
			MsgForm.SetActive (true);
			string alert_msg = "필수입력항목을 입력하세요";
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = alert_msg;
			return false;
		}
		else if ((login_confirm_pwd != Global.register_pwd)){
			MsgForm.SetActive (true);
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = "비밀번호가 옳바르지 않습니다";
			return false;
		}
		else if (login_confirm_pwd.Length < 6) {
			MsgForm.SetActive (true);
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = "비밀번호는 6자이상\n입력하여야 합니다";
			return false;
		}
		return true;
	}

	public void onNextButton()
	{
		Global.register_id = inputIdBox.GetComponent<UIInput> ().value;

		if (IsCorrectPassword ()) {
			string xmlUrl;
			xmlUrl = string.Format ("{0}?userid={1}", Global.ID_CONFIRM_SERVER_URL, Global.register_id);			
			StartCoroutine (LoadNextPage (xmlUrl));
		} else {
			Reset_field ();
		}
	}

	private IEnumerator LoadNextPage(string url)
	{
		XmlDocument xmlDoc = new XmlDocument();
		yield return new WaitForSeconds(0.01f);
		xmlDoc.Load(url);
		string res = xmlDoc.SelectSingleNode ("contents").InnerText;
		yield return new WaitForSeconds(0.01f);
		if (res == "0")
			Application.LoadLevel ("Vuforia-2-Register3");
		else {			
			MsgForm.SetActive (true);
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = "동일한 아이디가 존재합니다";
			Reset_field ();
		}
	}

	public void onPrevButton()
	{
		StartCoroutine(LoadPrevPage (0.01f));
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register1");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
