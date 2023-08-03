using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterManager7 : MonoBehaviour {

	public GameObject place1Obj;
	public GameObject place2Obj;

	#region UNITY_MONOBEHAVIOUR_METHODS

	// Use this for initialization
	void Start () {
		Global.register_place1 = "";
		Global.register_place2 = "";
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
		Global.register_place1 = place1Obj.GetComponent<UILabel> ().text;
		Global.register_place2 = place2Obj.GetComponent<UILabel> ().text;
		if (Global.register_place1 != "" && Global.register_place1 != null && Global.register_place2 != "" && Global.register_place2 != null) {
			Global.register_place = Global.register_place1 + " " + Global.register_place2;
			StartCoroutine (LoadNextPage (0.01f));
		}
	}

	private IEnumerator LoadNextPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register8");
	}

	public void onPrevButton()
	{
		StartCoroutine(LoadPrevPage (0.01f));
	}

	private IEnumerator LoadPrevPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Register6");
	}

	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
