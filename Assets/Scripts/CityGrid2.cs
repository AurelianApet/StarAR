using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CityGrid2 : MonoBehaviour {

	public GameObject item;
	public Texture[] images;

	void Awake () { 
		InitItem(); 
	}

	void Start()
	{
		
	}

	void InitItem() {
		string[] str = { "서울특별시", "부산광역시", "대구광역시", "인천광역시", "광주광역시", "대전광역시", "울산광역시", "세종특별자치시", 
			"경기도", "강원도", "충청북도", "충청남도", "전라북도", "전라남도", "경상북도", "경상남도", "제주특별자치도"};
		for (int i = 0; i < images.Length; i++) {
			GameObject obj = Instantiate(item, new Vector3(0f, -100.0f * i, 0f), Quaternion.identity) as GameObject;
			obj.transform.parent = this.transform;
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			UITexture texture = GetChildObj (obj, "Texture").GetComponent<UITexture>(); 
			UILabel label = GetChildObj (obj, "Label").GetComponent<UILabel>(); 
			texture.mainTexture = images[i];
			label.text = Convert.ToString (str[i]);
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
