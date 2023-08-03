using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterManager : MonoBehaviour {
	
	#region UNITY_MONOBEHAVIOUR_METHODS

	public GameObject agree1on;
	public GameObject agree1out;
	public GameObject disagree1on;
	public GameObject disagree1out;

	public GameObject agree2on;
	public GameObject agree2out;
	public GameObject disagree2on;
	public GameObject disagree2out;

	// Use this for initialization
	void Start () {
	}

	void InitialButtons()
	{
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-1-Advertisement2");
	}

	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (LoadPrevPage (0.01f));
		}
		#endif
	}

	public void onAgree1on()
	{
		Global.isagree1 = true;
		if(agree1on)
			agree1on.SetActive (true);
		if(agree1out)
			agree1out.SetActive (false);
		if(disagree1on)
			disagree1on.SetActive (false);
		if(disagree1out)
			disagree1out.SetActive (true);
	}

	public void onDisagree1on()
	{
		Global.isagree1 = false;
		if(agree1on)
			agree1on.SetActive (false);
		if(agree1out)
			agree1out.SetActive (true);
		if(disagree1on)
			disagree1on.SetActive (true);
		if(disagree1out)
			disagree1out.SetActive (false);
	}

	public void onAgree2on()
	{
		Global.isagree2 = true;
		if(agree2on)
			agree2on.SetActive (true);
		if(agree2out)
			agree2out.SetActive (false);
		if(disagree2on)
			disagree2on.SetActive (false);
		if(disagree2out)
			disagree2out.SetActive (true);
	}

	public void onDisagree2on()
	{
		Global.isagree2 = false;
		if(agree2on)
			agree2on.SetActive (false);
		if(agree2out)
			agree2out.SetActive (true);
		if(disagree2on)
			disagree2on.SetActive (true);
		if(disagree2out)
			disagree2out.SetActive (false);
	}

	public void onNextButton()
	{
		if (Global.isagree1 && Global.isagree2) {
			StartCoroutine (LoadHomePage (0.01f));
		}
	}

	private IEnumerator LoadHomePage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register2");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
