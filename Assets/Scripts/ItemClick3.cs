using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemClick3 : MonoBehaviour {
	public GameObject scrollview;
	public UILabel lab;

	void Awake() {
		scrollview = GameObject.FindGameObjectWithTag ("scroll2").gameObject;
		lab = GameObject.FindGameObjectWithTag ("label2").GetComponent<UILabel> ();
	}

	void Start()
	{
		
	}

	public void OnClick() {
//		lab.text = strtxt;
		lab.text = this.transform.Find("Label").transform.GetComponent<UILabel>().text;
		scrollview.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
