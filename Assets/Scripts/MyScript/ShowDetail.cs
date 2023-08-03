using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class ShowDetail : MonoBehaviour {

	public UILabel EmailField;
	public UILabel BirthField;
	public UILabel SexField;
	public UILabel MarryField;
	public UILabel PlaceField;
	public UILabel Account;
	public UILabel Point;

	#region UNITY_MONOBEHAVIOUR_METHODS

	// Use this for initialization
	void Start () {
		if (Account) {
			Account.text = Global.login_id;
		}

		if(EmailField)
			EmailField.GetComponent<UILabel> ().text = Global.register_email + "@" + Global.register_account;
		if(BirthField)
			BirthField.GetComponent<UILabel> ().text = Global.register_birth_year;
		if(Global.register_sex == 1)
			SexField.GetComponent<UILabel> ().text = "남";
		else
			SexField.GetComponent<UILabel> ().text = "여";

		if(Global.register_married == 1)
			MarryField.GetComponent<UILabel> ().text = "기혼";
		else
			MarryField.GetComponent<UILabel> ().text = "미혼";
		
		PlaceField.GetComponent<UILabel> ().text = Global.register_place;

	}

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (LoadPrevPage (0.01f));
		}
		#endif
	}
		
	public void onPrevButton()
	{
		StartCoroutine(LoadPrevPage (0.01f));
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-4-Scan");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
