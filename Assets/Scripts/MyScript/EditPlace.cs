using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPlace : MonoBehaviour {
	public GameObject place1Obj;
	public GameObject place2Obj;

	// Use this for initialization
	void Start () {
		
	}

	public void confirm()
	{
		Global.register_place1 = place1Obj.GetComponent<UILabel> ().text;
		Global.register_place2 = place2Obj.GetComponent<UILabel> ().text;
		if (Global.register_place1 != "" && Global.register_place1 != null && Global.register_place2 != "" && Global.register_place2 != null) {
			Global.register_place = Global.register_place1 + " " + Global.register_place2;
			StartCoroutine (LoadPrevPage (0.01f));		
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
		#if UNITY_ANDROID
		if (Input.GetKey (KeyCode.Escape)) {
			StartCoroutine (LoadPrevPage (0.01f));
		}
		#endif
	}
}
