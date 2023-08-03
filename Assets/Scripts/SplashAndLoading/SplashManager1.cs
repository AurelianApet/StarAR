/*============================================================================== 
 * Copyright (c) 2012-2014 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * Confidential and Proprietary – Qualcomm Connected Experiences, Inc. 
 * ==============================================================================*/
using UnityEngine;
using System.Collections;

public class SplashManager1 : MonoBehaviour {

    #region PRIVATE_MEMBER_VARIABLES
    private SplashScreenView mSplashView;
    #endregion PRIVATE_MEMBER_VARIABLES
    
    #region UNITY_MONOBEHAVIOUR_METHODS
    void Start () {
        
//        mSplashView = new SplashScreenView();
//        mSplashView.LoadView();
        StartCoroutine(LoadAboutPageAfter(0.01f));
    }
    
    void OnGUI()
    {
//        mSplashView.UpdateUI(true);
    }
    
    private IEnumerator LoadAboutPageAfter(float secs)
    {
        yield return new WaitForSeconds(secs);
        Application.LoadLevel("Vuforia-1-Advertisement1");
    }
    #endregion UNITY_MONOBEHAVIOUR_METHODS
}
