using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingAdvertisement2 : MonoBehaviour {

	public GameObject toggle1;
	public GameObject toggle2;
	public GameObject point;
	public GameObject scan;
	public GameObject mypage;

	// Use this for initialization
	void Start () {
		toggle1.SetActive (true);
		toggle2.SetActive (false);
		point.SetActive (false);
		scan.SetActive (false);
		mypage.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
