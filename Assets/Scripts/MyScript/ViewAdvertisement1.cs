using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAdvertisement1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Global.path2 != "" && Global.path2 != null ) {
			string url = "file:///" + Global.path2;
			StartCoroutine (setImage (this.GetComponent<UITexture> (), url));
		}
	}

	IEnumerator setImage(UITexture tex, string url)
	{
		WWW www = new WWW (url);
		yield return www;

		this.GetComponent<UITexture>().mainTexture = www.texture;
	}


	// Update is called once per frame
	void Update () {
	}
}
