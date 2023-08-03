using UnityEngine;
using System.Collections;

public class PopupIntro : MonoBehaviour {

	private Texture texBack;
	private GUIStyle btnStyle = new GUIStyle();
	private float 	swidth = 0.0f, startX;
	// Use this for initialization
	void Start () {
		texBack = Resources.Load<Texture> ("image/guide/guide");
		btnStyle.normal.background = Resources.Load<Texture2D> ("image/guide/start_on");
		btnStyle.active.background = Resources.Load<Texture2D> ("image/guide/start_off");
		swidth = Screen.height * 9 / 16;
		startX = (Screen.width - swidth) / 2;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnGUI(){
		/*float width = Screen.width * 732 / 1080;
		float height = Screen.height * 955 / 1920;
		float startx = Screen.width / 2 - width / 2;
		float starty = Screen.height / 2- height / 2;*/

		GUI.DrawTexture (new Rect (startX + swidth*174/1080, Screen.height*483/1920, swidth*732/1080, Screen.height*955/1920), texBack, ScaleMode.ScaleToFit);
		if (GUI.Button (new Rect (startX + swidth*342/1080, Screen.height*1269/1920, swidth*396/1080, Screen.height*94/1920), "", btnStyle)) {
			Destroy(this);
		}
	}
}
