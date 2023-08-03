using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grid1 : MonoBehaviour {

	public GameObject item;
	public Texture[] images;

	void Start () { 
		
	}


	void Awake()
	{
		InitItem(); 
	}

	void InitItem() {

		Debug.Log ("image length " + images.Length);
		string[] accounts = { "hanmail.net",
			"naver.com",
			"hotmail.com",
			"yahoo.co.kr",
			"hanmir.com",
			"paran.com",
			"lycos.co.kr",
			"nate.com",
			"dreamwiz.com",
			"korea.com",
			"empal.com",
			"natian.com",
			"freechal.com",
			"msn.com",
			"gmail.com",
			"직접입력"			};
		for (int i = 0; i < images.Length; i++) {
			if (i == 1)
				continue;
			GameObject obj = Instantiate(item, new Vector3(0f, -100.0f * i, 0f), Quaternion.identity) as GameObject;
			obj.transform.parent = this.transform;
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			UITexture texture = GetChildObj (obj, "Texture").GetComponent<UITexture>(); 
			UILabel label = GetChildObj (obj, "Label").GetComponent<UILabel>(); 
			texture.mainTexture = images[i];
			label.text = accounts[i];
		}
		GetComponent<UIGrid>().Reposition();
	}

	GameObject GetChildObj( GameObject source, string strName  ) { 
		Transform[] AllData = source.GetComponentsInChildren< Transform >(); 
		GameObject target = null;
		foreach( Transform Obj in AllData ) { 
			if( Obj.name == strName ) { 
				target = Obj.gameObject;
				break;
			} 
		}
		return target;
	}

	void Update () {
		
	}
}
