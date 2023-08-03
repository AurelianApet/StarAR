using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterManager6_1 : MonoBehaviour {

	public GameObject man;
	public GameObject man1;
	public GameObject woman;
	public GameObject woman1;

	// Use this for initialization
	void Start () {
	}

	public void onManButton()
	{
		Global.register_sex = 1;
		if(man)
			man.SetActive (false);
		if(man1)
			man1.SetActive (true);
		if (woman)
			woman.SetActive (true);
		if (woman1)
			woman1.SetActive (false);
	}

	public void onManButton1()
	{
		Global.register_sex = 0;
		if(man)
			man.SetActive (true);
		if(man1)
			man1.SetActive (false);
	}

	public void onWomanButton()
	{
		Global.register_sex = 2;
		if(woman)
			woman.SetActive (false);
		if(woman1)
			woman1.SetActive (true);
		if (man)
			man.SetActive (true);
		if (man1)
			man1.SetActive (false);
	}

	public void onWomanButton1()
	{
		Global.register_sex = 0;
		if(woman)
			woman.SetActive (true);
		if(woman1)
			woman1.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}
}
