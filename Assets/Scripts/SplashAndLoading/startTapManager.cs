using UnityEngine;
using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using UnityEngine.SceneManagement;


public class startTapManager : MonoBehaviour {

	private Texture texBack, texMsgBack, texBlank;
	private GUIStyle strVerStyle = new GUIStyle();
	private GUIStyle strTxtStyle = new GUIStyle();
	private GUIStyle stringStyle = new GUIStyle();
	private GUIStyle yesStyle = new GUIStyle();
	private GUIStyle noStyle = new GUIStyle();
	private GUIStyle btnStyle = new GUIStyle();

	private string[] strTxt = new string[4];
	private int curState = 0;
	private float 	swidth = 0.0f, startX;
	public GameObject goUISlide;
	public GameObject goBackUI;

	public GameObject[] sldObj;
	private int sldCount =3;
	private int curFullIndex =0;

	private bool isMousePressed, bPrev, bNext;
	private Vector2 startpos, endpos;
	private float slidedeltaLenth = 0.03f;
	private float sumTime =0.0f, actionTime = 0.3f;

	private Vector3 posCenter = Vector3.zero;
	private Vector3 posHLeft = new Vector3(-512.0f, 0.0f, 0.0f);
	private Vector3 posHRight = new Vector3(512.0f, 0.0f, 0.0f);
	void Awake()
	{
		StartCoroutine (init ());
	
	}
	// Use this for initialization
	void Start () {
		strTxt [0] = "";
		strTxt [1] = " 현재 최신 버전입니다.";
		strTxt [2] = " 업데이트 버전이 있습니다.";
		strTxt [3] = " 갱신중인 버전입니다.";
		swidth = Screen.height * 9 / 16;
		startX = (Screen.width - swidth) / 2;
		texBack = Resources.Load<Texture> ("intro_1");
		texBlank = Resources.Load<Texture> ("blank");
		strTxtStyle.normal.textColor = Color.white;
		strTxtStyle.fontSize = 23* Screen.height/910;
		strTxtStyle.font = Resources.Load<Font> ("NanumGothic");
		strTxtStyle.alignment = TextAnchor.MiddleCenter;

		strVerStyle.normal.textColor = Color.yellow;
		strVerStyle.fontSize = 20* Screen.height/910;
		strVerStyle.font = Resources.Load<Font> ("NanumGothic");
		strVerStyle.alignment = TextAnchor.MiddleCenter;

		stringStyle.alignment = TextAnchor.MiddleCenter;
		stringStyle.normal.textColor = Color.gray;
		stringStyle.font = (Font)Resources.Load("NanumGothic");
		stringStyle.fontSize = 11* Screen.height/448;

		texMsgBack = Resources.Load < Texture> ("PopUpMsg/Background");	
		noStyle.normal.background = Resources.Load ("PopUpMsg/bt_no") as Texture2D;
		noStyle.active.background = Resources.Load ("PopUpMsg/bt_no_r") as Texture2D;
		yesStyle.normal.background = Resources.Load ("PopUpMsg/bt_yes") as Texture2D;
		yesStyle.active.background = Resources.Load ("PopUpMsg/bt_yes_r") as Texture2D;

		if(File.Exists(Global.strLikeInfoPath))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fdata = File.Open(Global.strLikeInfoPath, FileMode.Open);
			try
			{
				Global.likeNames = (List<string>)bf.Deserialize(fdata);
			}
			catch(SerializationException e)
			{
				Debug.LogError("likelist Datafile load Error:" + e.Message);
			}
			finally{
				fdata.Close();
			}
		}
		Global.bFirstPlay = (PlayerPrefs.GetInt ("bFirstPlay", 1) == 1)? true:false;

		bool internetPossiblyAvailable;
		switch (Application.internetReachability)
		{
		case NetworkReachability.ReachableViaLocalAreaNetwork:
			internetPossiblyAvailable = true;
			break;
		case NetworkReachability.ReachableViaCarrierDataNetwork:
			internetPossiblyAvailable = true;
			break;
		default:
			internetPossiblyAvailable = false;
			break;
		}
		if (Application.isMobilePlatform && !internetPossiblyAvailable) {
			Debug.Log("AAAAAAAAAAAAA");
			this.transform.gameObject.AddComponent<MsgInternetErr>();
		} else {
			Debug.Log("BBBBBBBBBBBBB");
			StartCoroutine (CheckVer ());
		}

	}

	IEnumerator init(){
		yield return new WaitForSeconds (0.5f);
		float rate = sldObj [0].transform.localScale.x;
		posHLeft = new Vector3 (-512.0f * rate, 0.0f, 0.0f);
		posHRight = new Vector3 (512.0f * rate, 0.0f, 0.0f);
		sldObj [0].transform.localPosition = posCenter;
		for (int i = 1; i < sldCount; i++) {
			sldObj[i].transform.localPosition = posHRight;
		}
	}

	IEnumerator CheckVer(){

		XmlDocument xmlDoc = new XmlDocument();
		yield return new WaitForSeconds(0.5f);
		try{
			xmlDoc.Load(Global.UPDATE_URL);
			string lastVer = (xmlDoc.SelectSingleNode("ver").InnerText);
			Debug.Log ("lastVer" + lastVer);
			switch (string.Compare (Global.AppVer, lastVer) )
			{
			case 0:
				Debug.Log ("last version" );
				curState = 1;
				StartCoroutine ( startDelay());
				break;
			case -1:
				Debug.Log ("old version" );
				curState = 2;
				break;
			case 1:
				Debug.Log ("new version" );
				curState = 3;
				StartCoroutine ( startDelay());
				break;
			}
		}catch (Exception exception){
		//	StartCoroutine ( startDelay());
			Debug.LogError(exception.ToString());
			this.transform.gameObject.AddComponent<MsgInternetErr>();
		}
	}

	IEnumerator startDelay(){
		yield return new WaitForSeconds (3.0f);
	//	Application.LoadLevel("Vuforia-2-LoadingScene");
		if (Global.bFirstPlay) {
			PlayerPrefs.SetInt ("bFirstPlay", 0);
			Global.bFirstPlay = false;
			goBackUI.SetActive (false);
		}else {
			Application.LoadLevel ("Vuforia-2-LoadingScene");

		}
	}

	// Update is called once per frame
	void Update () {
		if(bNext)
		{
			Vector3 leftPos, rightPos;
			leftPos = posHLeft;	rightPos = posHRight;
			sumTime += Time.deltaTime;
			float fracJourney = sumTime / actionTime;
			sldObj[curFullIndex].transform.localPosition = Vector3.Lerp(posCenter, leftPos, fracJourney);
			sldObj[curFullIndex].GetComponent<UITexture> ().depth = -1;
			sldObj[(curFullIndex + 1)%sldCount].transform.localPosition = Vector3.Lerp(rightPos, posCenter, fracJourney);
			sldObj[(curFullIndex + 1)%sldCount].GetComponent<UITexture> ().depth = 0;
			if(fracJourney >= 1.0f)
			{
				curFullIndex = (curFullIndex + 1)%sldCount;
			//	sldImage.transform.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> (string.Format ("Design/howtouse/useway_sld_{0}", curFullIndex));
				bNext = false;
			}
		}
		if(bPrev)
		{
			Vector3 leftPos, rightPos;
			leftPos = posHLeft;		rightPos = posHRight;
			sumTime += Time.deltaTime;
			float fracJourney = sumTime / actionTime;
			sldObj[(curFullIndex + sldCount-1)%sldCount].transform.localPosition = Vector3.Lerp(leftPos, posCenter, fracJourney);
			sldObj [(curFullIndex + sldCount - 1) % sldCount].GetComponent<UITexture> ().depth = -1;
			sldObj[curFullIndex].transform.localPosition = Vector3.Lerp(posCenter, rightPos, fracJourney);
			sldObj[curFullIndex].GetComponent<UITexture> ().depth = 0;
			if(fracJourney >= 1.0f)
			{
				curFullIndex = (curFullIndex + sldCount-1)%sldCount;
			//	sldImage.transform.GetComponent<UITexture> ().mainTexture = Resources.Load<Texture2D> (string.Format ("Design/howtouse/useway_sld_{0}", curFullIndex));
				bPrev = false;
			}
		}

		if(!bPrev && !bNext)
		{
			if(Input.GetMouseButtonDown(0))
				isMousePressed = true;
			else if(Input.GetMouseButtonUp(0))
				isMousePressed = false;

			if(isMousePressed && Input.touchCount==1 && Input.GetTouch(0).phase == TouchPhase.Moved)
			{
				Touch touch = Input.GetTouch(0);    
				Vector3 diff = touch.deltaPosition/Screen.dpi; 
				if(Mathf.Abs(diff.x) > slidedeltaLenth && diff.x < 0)
				{
					SlideNext();	isMousePressed = false;
				}
				else if(Mathf.Abs(diff.x) > slidedeltaLenth && diff.x > 0)
				{
					SlidePrev();	isMousePressed = false;
				}
			}
		}
	}

	public void SlideNext()
	{
		if (curFullIndex == sldCount - 1) {
			SceneManager.LoadScene ("Vuforia-2-LoadingScene");
			return;
		}else {
			sumTime = 0.0f;
			bNext = true;
		}

	}
	void SlidePrev()
	{
		if (curFullIndex == 0)
			return;
		sumTime = 0.0f;	bPrev = true;
	
	}

	void OnGUI(){
	//	GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), texBack);
		if (goBackUI.activeInHierarchy) {
			GUI.Label (new Rect (0, Screen.height * 1520 / 1920, Screen.width, Screen.height * 70 / 1920), strTxt [curState], strTxtStyle);
			GUI.Label (new Rect (0, Screen.height * 1600 / 1920, Screen.width, Screen.height * 70 / 1920), string.Format ("Ver {0}", Global.AppVer), strVerStyle);
		} 
		if (curState == 2) {
			GUI.DrawTexture (new Rect(startX + swidth*39/640, Screen.height*394/1136, swidth*564/640, Screen.height*343/1136), texMsgBack, ScaleMode.StretchToFill);
			GUI.Label(new Rect(startX + swidth*49/640, Screen.height*490/1136, swidth*544/640, Screen.height*90/1136), "업데이트 하시겠습니까?", stringStyle);
			if(GUI.Button(new Rect(startX + swidth*95/640, Screen.height*635/1136, swidth*211/640, Screen.height*56/1136), "", yesStyle))
			{
				#if UNITY_ANDROID
				string url = "https://play.google.com/store/apps/details?id=com.coar.starpangAR";
				Application.OpenURL(url);
				#elif UNITY_IPHONE
				string url = "http://itunes.apple.com/app/apple-store/id967155330";		// id664428419
				Application.OpenURL(url);
				#endif
				Application.LoadLevel("Vuforia-2-LoadingScene");
			}
			if(GUI.Button(new Rect(startX + swidth*335/640, Screen.height*635/1136, swidth*211/640, Screen.height*56/1136), "", noStyle))
			{
				Application.LoadLevel("Vuforia-2-LoadingScene");
			}
		}
	}

}
