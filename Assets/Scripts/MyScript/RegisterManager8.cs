using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class RegisterManager8 : MonoBehaviour {

	public GameObject EmailField;
	public GameObject BirthField;
	public GameObject SexField;
	public GameObject MarryField;
	public GameObject PlaceField;
	public GameObject Account;
	public GameObject MsgForm;

	#region UNITY_MONOBEHAVIOUR_METHODS

	// Use this for initialization
	void Start () {
		if (Account)
			Account.GetComponent<UILabel> ().text = Global.register_id;
		if(EmailField)
			EmailField.GetComponent<UILabel> ().text = Global.register_email;
		if(BirthField)
			BirthField.GetComponent<UILabel> ().text = Global.register_birth_year;
		if (Global.register_sex == 1) {
			if (SexField)
				SexField.GetComponent<UILabel> ().text = "남";
		} else {
			if(SexField)
				SexField.GetComponent<UILabel> ().text = "여";
		}
		if (MsgForm)
			MsgForm.SetActive (false);
		
		if (Global.register_married == 1) {
			if(MarryField)
				MarryField.GetComponent<UILabel> ().text = "기혼";
		} else {
			if(MarryField)
				MarryField.GetComponent<UILabel> ().text = "미혼";
		}
		
		PlaceField.GetComponent<UILabel> ().text = Global.register_place1 + "   " +  Global.register_place2;

	}

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (LoadPrevPage (0.01f));
		}
		#endif
	}

	public void onConfirmButton()
	{
		if (Global.register_id != "" && Global.register_pwd != "") {
			string xmlUrl;
			xmlUrl = string.Format ( "{0}?userid={1}&pwd={2}&email={3}&birth_year={4}&married={5}&sex={6}&place={7}", Global.REGISTER_SERVER_URL, Global.register_id, Global.register_pwd,
				Global.register_email + "@" + Global.register_account,	Global.register_birth_year, Global.register_married, Global.register_sex, Global.register_place1 + " " + Global.register_place2);
			StartCoroutine(LoadNextPage (xmlUrl));
		} 
	}

	private IEnumerator LoadNextPage(string url)
	{
		XmlDocument xmlDoc = new XmlDocument();
		yield return new WaitForSeconds(0.01f);
		try{
			xmlDoc.Load(url);
			if(xmlDoc.SelectSingleNode ("contents") != null)
			{
				string res = xmlDoc.SelectSingleNode ("contents").InnerText;
				if (res == "1") {
					MsgForm.SetActive (true);
					MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "성공적으로 등록되었습니다";
					//			Application.LoadLevel ("Vuforia-3-LoginScene");
				} else {
					MsgForm.SetActive (true);
					MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "등록시 오류가 발생했습니다";
					//			Application.LoadLevel ("Vuforia-3-LoginScene");
				}
			}
			else {
				MsgForm.SetActive (true);
				MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "등록시 오류가 발생했습니다";
			}
		}catch(XmlException) {
			MsgForm.SetActive (true);
			MsgForm.transform.Find ("MegTxt").transform.GetComponent<UILabel> ().text = "등록시 오류가 발생했습니다";
//			Application.LoadLevel ("Vuforia-3-LoginScene");
		}
	}

	public void onPrevButton()
	{
		StartCoroutine(LoadPrevPage (0.01f));
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register7");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
