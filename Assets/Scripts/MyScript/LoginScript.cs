using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System;

public class LoginScript : MonoBehaviour {

	public GameObject MsgForm;
	public GameObject inputIdBox;
	public GameObject inputPwdBox;
	private string login_pwd;
	#region UNITY_MONOBEHAVIOUR_METHODS

	// Use this for initialization
	void Start () {
		if(MsgForm)
			MsgForm.SetActive (false);
		Global.login_id = "";
		login_pwd = "";
	}

	IEnumerator GotoNextPage(string url)
	{
		XmlDocument xmlDoc = new XmlDocument();
		yield return new WaitForSeconds(0.01f);
		xmlDoc.Load(url);

		string res = "";
		try{			
			res = xmlDoc.SelectSingleNode ("contents/data").InnerText;
		}
		catch(Exception) {
			res = "";
		}
		yield return new WaitForSeconds(0.01f);
		if (res == "1") {
			Global.register_email = xmlDoc.SelectSingleNode ("contents/email").InnerText;
			Global.register_birth_year = xmlDoc.SelectSingleNode ("contents/birthyear").InnerText;

			Global.register_married = Convert.ToInt32 (xmlDoc.SelectSingleNode ("contents/married").InnerText);
			Global.register_sex = Convert.ToInt32 (xmlDoc.SelectSingleNode ("contents/sex").InnerText);
			Global.register_place = xmlDoc.SelectSingleNode ("contents/place").InnerText;
			StartCoroutine (LoadLoginScene (0.01f));
		} else {
			MsgForm.SetActive (true);
			string alert_msg = "아이디나 비밀번호가\n" + "옳바르지 않습니다";
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = alert_msg;
			Reset_field ();
		}
	}

	private void Reset_field(){
		
		inputIdBox.GetComponent<UIInput> ().value = "";
		inputPwdBox.GetComponent<UIInput> ().value = "";	
	}

	public void Login()
	{
		if (inputIdBox)
			Global.login_id = inputIdBox.GetComponent<UIInput>().value;

		if (inputPwdBox)
			login_pwd = inputPwdBox.GetComponent<UIInput>().value;
		
		if (Global.login_id == "ID" || Global.login_id == "") {
			MsgForm.SetActive (true);
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = "정확한 아이디를 입력하세요";
			Reset_field ();
		}
		else if(login_pwd == "PW" || login_pwd == "")
		{
			MsgForm.SetActive (true);
			string alert_msg = "비밀번호를 정확히 입력하십시오";
			MsgForm.transform.Find("MegTxt").transform.GetComponent<UILabel> ().text = alert_msg;
			Reset_field ();
		} 
		else {			
			string xmlUrl;
			xmlUrl = string.Format ( "{0}?userid={1}&pwd={2}", Global.LOGIN_SERVER_URL, Global.login_id, login_pwd );
			StartCoroutine(GotoNextPage(xmlUrl));
		}		
	}

	private IEnumerator LoadLoginScene(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-4-Scan");
	}

	public void Register()
	{
		StartCoroutine (LoadRegisterScene (0.01f));
	}

	private IEnumerator LoadRegisterScene(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register1");
	}

	// Update is called once per frame
	void Update () {
		
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
