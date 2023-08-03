using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClick : MonoBehaviour {
	public GameObject scrollview;
	int index;
	public UILabel lab;
	void Awake(){
/*
		index = 0;

		foreach (Transform child in this.transform.parent) {
			if (child == transform) {				
				break;
			}
			index++;
		}
*/
	}
	void Start() {

	}

	public void OnClick() {
//		lab.text = strtxt;
		lab.text = this.transform.Find("Label").transform.GetComponent<UILabel>().text;
		scrollview.SetActive (false);
//		Debug.Log (index);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
