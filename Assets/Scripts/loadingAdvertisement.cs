using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadingAdvertisement : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float angle = -1 * Time.deltaTime * 500.0f;
		transform.Rotate (new Vector3(0, 0, angle));
	}
}
