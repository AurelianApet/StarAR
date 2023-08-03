using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick1 : MonoBehaviour {
	public GameObject scrollview;
	int index;
	public UILabel lab;
	void Awake() {
	}

	void Start()
	{
		
	}

	public void OnClick() {
//		lab.text = strtxt;
		if (this.transform.Find ("Label").transform.GetComponent<UILabel> ().text == "직접입력") {
			if(GameObject.FindWithTag ("DirectInput"))
				GameObject.FindWithTag ("DirectInput").SetActive (true);
			if(GameObject.FindWithTag ("InputAcc"))
				GameObject.FindWithTag ("InputAcc").SetActive (false);			

		} else {
//			if(GameObject.FindWithTag ("DirectInput"))
//				GameObject.FindWithTag ("DirectInput").SetActive (false);
			if(GameObject.FindWithTag ("InputAcc"))
				GameObject.FindWithTag ("InputAcc").SetActive (true);			
			lab.text = this.transform.Find ("Label").transform.GetComponent<UILabel> ().text;
		}
		scrollview.SetActive (false);
//		Debug.Log (index);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
