using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private IEnumerator LoadEditEmailPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Edit3");
	}

	public void GotoEdit_email()
	{
		StartCoroutine(LoadEditEmailPage (0.01f));
	}

	private IEnumerator LoadEditSexPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Edit6");
	}

	public void GotoEdit_sex()
	{
		StartCoroutine(LoadEditSexPage (0.01f));
	}

	private IEnumerator LoadEditPlacePage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Edit7");
	}

	public void GotoEdit_place()
	{
		StartCoroutine(LoadEditPlacePage (0.01f));
	}

	private IEnumerator LoadEditMarryPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Edit5");
	}

	public void GotoEdit_marry()
	{
		StartCoroutine(LoadEditMarryPage (0.01f));
	}

	public void GotoEdit_birthyear()
	{
		StartCoroutine(LoadEditBirthyearPage (0.01f));
	}

	private IEnumerator LoadEditBirthyearPage(float secs)
	{
		yield return new WaitForSeconds(secs);
		Application.LoadLevel("Vuforia-2-Edit4");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
