using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Global {
	public readonly static string AppVer = "1.0.0";

	public static string UPDATE_URL = "http://1.234.83.53:19780/AppVersion.xml";
//	public static string UPDATE_URL = "http://localhost:19780/AppVersion.xml";

	public static string SERVER_URL =  "http://1.234.83.53:19780/Account/getXML.aspx?content_id=";
//	public static string SERVER_URL =  "http://localhost:19780/Account/getXML.aspx?content_id=";

	public static string WEB_SERVER_URL = "http://1.234.83.53:19780/";
//	public static string WEB_SERVER_URL = "http://localhost:19780/";

	public static string Adv_SERVER_URL = "http://1.234.83.53:19780/Account/adv_getXML.aspx";
//	public static string Adv_SERVER_URL = "http://localhost:19780/Account/adv_getXML.aspx";

	public static string LOGIN_SERVER_URL = "http://1.234.83.53:19780/Account/m_login.aspx";
//	public static string LOGIN_SERVER_URL = "http://localhost:19780/Account/m_login.aspx";

	public static string LOGOUT_SERVER_URL = "http://1.234.83.53:19780/Account/m_logout.aspx";
//	public static string LOGOUT_SERVER_URL = "http://localhost:19780/Account/m_logout.aspx";

	public static string REGISTER_SERVER_URL = "http://1.234.83.53:19780/Account/m_register.aspx";
//	public static string REGISTER_SERVER_URL = "http://localhost:19780/Account/m_register.aspx";

	public static string ID_CONFIRM_SERVER_URL = "http://1.234.83.53:19780/Account/m_id_confirm.aspx";
//	public static string ID_CONFIRM_SERVER_URL = "http://localhost:19780/Account/m_id_confirm.aspx";

	public static string[] place_lists = new string[] { 
		"종로구", 
		"중구",
		"용산구",
		"성동구",
		"광진구",
		"동대문구",
		"중랑구",
		"성북구",
		"강북구",
		"도봉구",
		"노원구",
		"은평구",
		"서대문구",
		"마포구",
		"양천구",
		"강서구",
		"구로구",
		"금천구",
		"영등포구",
		"동작구",
		"관악구",
		"서초구",
		"강남구",
		"송파구",
		"강동구"
	};

	public static string login_id;
	public static string CurMarkerName;
	public static string ThreeUnityName;
	public static string CurCustomButtonName;
	public static string CurAdvName1;
	public static string CurAdvName2;
	public static string path1;
	public static string path2;

	public static bool reg1;

	public static bool isDowned1 = false;
	public static bool isDowned2 = false;

	public static bool bLoadedPackage = false;


	public static bool isagree1 = false;
	public static bool isagree2 = false;
	public static string register_id;
	public static string register_pwd;
	public static string register_email;
	public static string register_account;
	public static string register_birth_year;
	public static string register_place1;
	public static string register_place2;
	public static string register_place;
	public static int register_married = 0;
	public static int register_sex = 0;

	public static GameObject goCharacter;

	/*		loading relative		*/
	public static bool bLoading;		//loading xml contents
	public static int TotalLoadingCount;
	public static int TotalLoadingAdvCount;
	public static int CurLoadingCount;
	public static int CurLoadingAdvCount;

	/*		LikeView Relative		*/
	public static bool bIsLikeView;
	public static string MarkerSavePath = Application.persistentDataPath + "/markers/";
	public static string CustomButtonPath = Application.persistentDataPath + "/uploads/custombutton/";
	public static string AdvImagePath = Application.persistentDataPath + "/uploads/advers/";
	public static string strLikeInfoPath = Application.persistentDataPath + "/like.dat";
	public static string ThreeUnitySavePath = Application.persistentDataPath + "/uploads/three/";

	public static List<string> likeNames = new List<string>();

	public static List<string> advNames = new List<string> ();

	public static int 	nCurMarkerIndex;

	public static int nAdvIndex;

	/*		Relative video 			*/
	public static bool	bVideoFull;
	public static bool 	bExistVideo;
	public static bool 	bJyroSenser;
	public static bool 	bLandscapeVideo;
	public static string videoName;
	public static Vector3		orgVideoPos;
	public static Vector3	orgVideoQuat;
	public static Vector3		orgVideoScale;

	/*		Relative Webview 		*/
	public static bool ShowingCustomWebview;

	/*		Relative RotateCamera	*/
	public static Vector3	ARCampos;

	/*		Relative Rotate3DObject		*/
//	public static bool 	bEnableRotate3D;
	public static bool bFirstPlay = true;
}
