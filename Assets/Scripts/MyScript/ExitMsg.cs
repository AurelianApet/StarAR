using UnityEngine;
using System.Collections;
using System.Xml;

public class ExitMsg : MonoBehaviour {
	public delegate void ExitWindowStart();
	public static event ExitWindowStart EventExitWindowStart;
	public delegate void ExitWindowEnd();
	public static event ExitWindowEnd EventExitWindowEnd;


	private GUIStyle noStyle = new GUIStyle();
	private GUIStyle yesStyle = new GUIStyle();
	private GUIStyle stringStyle = new GUIStyle ();
	private Texture texTop, texCheck, texBack, texBackGround;
	private float 	swidth = 0.0f, startX;

	// Use this for initialization
	void Start () {
		swidth = Screen.height * 9 / 16;
		startX = (Screen.width - swidth) / 2;
//		texBack = Resources.Load < Texture> ("PopUpMsg/Background");	
//		noStyle.normal.background = Resources.Load ("PopUpMsg/bt_no") as Texture2D;
//		noStyle.active.background = Resources.Load ("PopUpMsg/bt_no_r") as Texture2D;
//		yesStyle.normal.background = Resources.Load ("PopUpMsg/bt_yes") as Texture2D;
//		yesStyle.active.background = Resources.Load ("PopUpMsg/bt_yes_r") as Texture2D;

		texBack = Resources.Load < Texture> ("PopUpMsg/bg");	
		noStyle.normal.background = Resources.Load ("PopUpMsg/bt_cancel") as Texture2D;
		noStyle.active.background = Resources.Load ("PopUpMsg/bt_cancel_r") as Texture2D;
		yesStyle.normal.background = Resources.Load ("PopUpMsg/bt_confirm") as Texture2D;
		yesStyle.active.background = Resources.Load ("PopUpMsg/bt_confirm_r") as Texture2D;

		stringStyle.alignment = TextAnchor.MiddleCenter;
		stringStyle.normal.textColor = Color.gray;
		stringStyle.font = (Font)Resources.Load("HCRDotum");
		stringStyle.fontSize = 11* Screen.height/448;
		texBackGround = Resources.Load < Texture> ("comNameBack");
		EventExitWindowStart ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator GoToMainPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-4-Scan");
	}

	void OnGUI()
	{
		GUI.depth = -10;
//		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), texBackGround, ScaleMode.StretchToFill);
//		GUI.DrawTexture (new Rect(0, 0, Screen.width, Screen.height), texBackGround, ScaleMode.StretchToFill);
		
//		GUI.DrawTexture (new Rect(startX + swidth*39/640, Screen.height*394/1136, swidth*564/640, Screen.height*343/1136), texBack, ScaleMode.StretchToFill);
//		GUI.Label(new Rect(startX + swidth*49/640, Screen.height*490/1136, swidth*544/640, Screen.height*90/1136), "앱을 종료하시겠습니까?", stringStyle);
//		if(GUI.Button(new Rect(startX + swidth*95/640, Screen.height*635/1136, swidth*211/640, Screen.height*56/1136), "", yesStyle))
//		{
//			StartCoroutine(GoToMainPage(0.01f));
//			Application.Quit();
//		}
//		if(GUI.Button(new Rect(startX + swidth*335/640, Screen.height*635/1136, swidth*211/640, Screen.height*56/1136), "", noStyle))
		{
//			EventExitWindowEnd();
//			Destroy(this);
//			string xmlUrl;
//			xmlUrl = string.Format ( "{0}?userid={1}", Global.LOGOUT_SERVER_URL, Global.login_id);
//			StartCoroutine(SendLogoutRequest(xmlUrl));
		}		
	}

	IEnumerator SendLogoutRequest(string url)
	{
		XmlDocument xmlDoc = new XmlDocument ();
		yield return new WaitForSeconds (0.01f);
		xmlDoc.Load (url);
	}
}
