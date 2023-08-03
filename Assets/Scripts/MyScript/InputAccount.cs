using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAccount : MonoBehaviour {
	
	public GameObject scrollview;
//	public UILabel accountTxt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void input()
	{	
		scrollview.SetActive (true);
//		if (accountTxt!= null)
//			accountTxt.text = pop_list.value;
	}
}
