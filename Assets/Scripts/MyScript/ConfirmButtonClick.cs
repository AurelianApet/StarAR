using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using System.IO.Compression;
using System;

public class ConfirmButtonClick : MonoBehaviour {

	public GameObject MsgForm;
	private bool isDeleted = false;
	// Use this for initialization
	void Start () {
		
	}

	public void OnConfirm()
	{
		MsgForm.SetActive (false);
	}


	public void lastcon()
	{
//		MsgForm.SetActive (false);
		StartCoroutine(LoadNextPage (0.01f));
	}

	IEnumerator LoadNextPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-3-LoginScene");
	}

	IEnumerator Del_cache()
	{
		try{
			string path = Global.ThreeUnitySavePath;
			DirectoryInfo dir = new DirectoryInfo(path);
			System.IO.FileInfo[] files = dir.GetFiles("*.*",
				SearchOption.AllDirectories);
			foreach (System.IO.FileInfo file in files)
				file.Attributes = FileAttributes.Normal;
			Directory.Delete(path, true);
			isDeleted = true;
		}
		catch(Exception) {
			isDeleted = true;
		}
		yield return null;		
	}

	IEnumerator Exit()
	{
		while(!isDeleted)
			yield return new WaitForSeconds(0.01f);		
		string xmlUrl;
		xmlUrl = string.Format ( "{0}?userid={1}", Global.LOGOUT_SERVER_URL, Global.login_id);
		StartCoroutine(SendLogoutRequest(xmlUrl));
		Application.Quit ();
		yield return null;
	}

	public void Cancel()
	{
		StartCoroutine (Del_cache());
		StartCoroutine(Exit());
	}

	IEnumerator SendLogoutRequest(string url)
	{
		XmlDocument xmlDoc = new XmlDocument ();
		yield return new WaitForSeconds (0.01f);
		xmlDoc.Load (url);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
