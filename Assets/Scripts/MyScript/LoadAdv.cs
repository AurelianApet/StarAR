using UnityEngine;
using System.Collections;
using System.Xml;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;

public class LoadAdv : MonoBehaviour {

	private bool isDown1;
	private bool isDown2;
	#region PRIVATE_MEMBER_VARIABLES
	private SplashScreenView mSplashView;
	#endregion PRIVATE_MEMBER_VARIABLES

	#region UNITY_MONOBEHAVIOUR_METHODS
	// Use this for initialization
	void Start () {
		isDown1 = false;
		isDown2 = false;

		StartLoadAdvertisement1 ();
		StartLoadAdvertisement2 ();
	}

	void OnGUI()
	{
		//    mSplashView.UpdateUI(true);
	}

	private IEnumerator LoadAboutPageAfter(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-1-LoadingScene");
	}

	// Update is called once per frame
	void Update () {
/*		
		if (isDown1 && isDown2) {
			StartCoroutine (LoadAboutPageAfter (0.01f));
		} else {			
			StartCoroutine (LoadAboutPageAfter (5.0f));
		}
*/
		if (isDown1 && isDown2) {
			StartCoroutine (LoadAboutPageAfter (0.01f));
		}
	}

	void StartLoadAdvertisement1()
	{
		string xmlUrl;

		xmlUrl = string.Format ( "{0}?type=1", Global.Adv_SERVER_URL );
		StartCoroutine(LoadAdvXml1(xmlUrl));
	}

	void StartLoadAdvertisement2()
	{
		string xmlUrl;

		xmlUrl = string.Format ( "{0}?type=2", Global.Adv_SERVER_URL );
		StartCoroutine(LoadAdvXml2(xmlUrl));
	}

	IEnumerator LoadAdvXml1(string url)
	{
		XmlDocument xmlDoc = new XmlDocument();
		yield return new WaitForSeconds(0.1f);
		xmlDoc.Load(url);
		ProcessAdv1(xmlDoc.SelectNodes("contents"));
	}

	IEnumerator LoadAdvXml2(string url)
	{
		XmlDocument xmlDoc = new XmlDocument();
		yield return new WaitForSeconds(0.1f);
		xmlDoc.Load(url);
		ProcessAdv2(xmlDoc.SelectNodes("contents"));
	}

	public void ProcessAdv1(XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
		{
			try{
				string name = node.SelectSingleNode("name").InnerText;
				string master = node.SelectSingleNode("master").InnerText;
				string startTime = node.SelectSingleNode("startTime").InnerText;
				string endTime = node.SelectSingleNode("endTime").InnerText;
				string unlimited = node.SelectSingleNode("unlimited").InnerText;
				string imageurl = node.SelectSingleNode("imageurl").InnerText;
				string url = Global.WEB_SERVER_URL + "uploads/advers/" + imageurl;
				string type = node.SelectSingleNode("type").InnerText;
				Global.CurAdvName1 = imageurl;
				string path = Global.AdvImagePath + imageurl;
				Debug.Log(path);
				if(!File.Exists(path))
				{
					Debug.Log("not exist file...");
					StartCoroutine(DownAdv1(url));
					Global.TotalLoadingAdvCount ++;
				}
				else{
					Global.path1 = path;
					isDown1 = true;
				}
			}
			catch(Exception) {
				isDown1 = true;
			}
		}
	}

	public void ProcessAdv2(XmlNodeList nodes)
	{
		foreach (XmlNode node in nodes)
		{
			try{
				string name = node.SelectSingleNode("name").InnerText;
				string master = node.SelectSingleNode("master").InnerText;
				string startTime = node.SelectSingleNode("startTime").InnerText;
				string endTime = node.SelectSingleNode("endTime").InnerText;
				string unlimited = node.SelectSingleNode("unlimited").InnerText;
				string imageurl = node.SelectSingleNode("imageurl").InnerText;
				string url = Global.WEB_SERVER_URL + "uploads/advers/" + imageurl;
				string type = node.SelectSingleNode("type").InnerText;
				Global.CurAdvName2 = imageurl;
				string path = Global.AdvImagePath + imageurl;
				if(!File.Exists(path))
				{
					StartCoroutine(DownAdv2(url));
					Global.TotalLoadingAdvCount ++;
				}
				else{
					isDown2 = true;
					Global.path2 = path;						
				}
			}
			catch(Exception) {
				isDown2 = true;
			}
		}
	}

	IEnumerator DownAdv1(string url)
	{		
		WWW www =  new WWW(url);
		yield return www;
		Debug.Log ("down middle1");
		Global.CurLoadingAdvCount++;
		if (Global.CurAdvName1 != "" && Global.CurAdvName1 != null) {
			string path = Global.AdvImagePath + Global.CurAdvName1;
			try {
				Directory.CreateDirectory (Path.GetDirectoryName (path));
				File.WriteAllBytes (path, www.bytes);
				Global.path1 = path;
				isDown1 = true;
				Debug.Log (Global.path1);

			} catch (Exception exception) {
				Debug.LogError (exception.ToString ());
			}
			Debug.Log ("down successed");
		} else {
			isDown1 = true;
		}
	}

	IEnumerator DownAdv2(string url)
	{
		WWW www =  new WWW(url);
		yield return www;
		Debug.Log ("down middle2");
		Global.CurLoadingAdvCount++;
		if (Global.CurAdvName2 != "" && Global.CurAdvName2 != null) {
			string path = Global.AdvImagePath + Global.CurAdvName2;
			try	{
				Directory.CreateDirectory(Path.GetDirectoryName(path));
				File.WriteAllBytes(path, www.bytes);
				Global.path2 = path;
				isDown2 = true;
				Debug.Log(Global.path2);
			}catch (Exception exception){
				Debug.LogError(exception.ToString());
			}
		}else {
			isDown2 = true;
		}
	}
	#endregion UNITY_MONOBEHAVIOUR_METHODS
}
