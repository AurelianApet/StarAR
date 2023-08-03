using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictManager : MonoBehaviour {
	public GameObject item;
	public Texture2D images;
	public GameObject goGrid;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnEnable(){
		DeleteItems ();
		InitItem ();
	}

	void DeleteItems(){
		GameObject[] goDistItems = GameObject.FindGameObjectsWithTag ("Item1");
		for (int i = 0; i < goDistItems.Length; i++) {
			DestroyImmediate (goDistItems[i]);
		}
	}

	void InitItem() {
		Debug.Log ("Start Grid3....");
		goGrid.GetComponent<UIGrid> ().Reposition ();
		for (int i = 0; i < Global.place_lists.Length; i++) {
			GameObject obj = Instantiate(item, new Vector3(0f, 0f, 0f), Quaternion.identity) as GameObject;
			obj.transform.parent = goGrid.transform;
			obj.transform.localPosition = new Vector3 (0f, -100.0f * (i + 1), 0f);
			obj.transform.localScale = new Vector3(1f, 1f, 1f);
			UITexture texture = GetChildObj (obj, "Texture").GetComponent<UITexture>(); 
			UILabel label = GetChildObj (obj, "Label").GetComponent<UILabel>(); 
			texture.mainTexture = images;
			label.text = Global.place_lists[i];
		}
		goGrid.GetComponent<UIGrid>().Reposition();
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

}
