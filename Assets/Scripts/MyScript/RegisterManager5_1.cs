using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterManager5_1 : MonoBehaviour {

	public GameObject notmarriedObj;
	public GameObject notmarriedObj1;
	public GameObject marriedObj;
	public GameObject marriedObj1;

	// Use this for initialization
	void Start () {
	}

	public void onNotMarriedButton()
	{
		Global.register_married = 2;
		if(notmarriedObj)
			notmarriedObj.SetActive (false);
		if(notmarriedObj1)
			notmarriedObj1.SetActive (true);
		if (marriedObj)
			marriedObj.SetActive (true);
		if (marriedObj1)
			marriedObj1.SetActive (false);
	}

	public void onNotMarriedButton1()
	{
		Global.register_married = 0;
		if(notmarriedObj)
			notmarriedObj.SetActive (true);
		if(notmarriedObj1)
			notmarriedObj1.SetActive (false);
	}

	public void onMarriedButton()
	{
		Global.register_married = 1;
		if(marriedObj)
			marriedObj.SetActive (false);
		if(marriedObj1)
			marriedObj1.SetActive (true);
		if (notmarriedObj)
			notmarriedObj.SetActive (true);
		if (notmarriedObj1)
			notmarriedObj1.SetActive (false);
	}

	public void onMarriedButton1()
	{
		Global.register_married = 0;
		if(marriedObj)
			marriedObj.SetActive (true);
		if(marriedObj1)
			marriedObj1.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
