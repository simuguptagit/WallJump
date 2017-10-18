using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainPageScript : MonoBehaviour {
	public GameObject Levelselectpannel;
	public GameObject Hardlock;
	public GameObject levelnor;
	public GameObject leveleasy;
	public GameObject levelhigh;
	//public static int Level_Hard;
	public GameObject soundon;
	public GameObject soundoff;
	// Use this for initialization
	void Start () {
		
		if (PlayerPrefs.GetInt ("Levels") <= 0)
			PlayerPrefs.SetInt ("Levels", 2);
		
		if (PlayerPrefs.GetInt ("sound")==0)
			soundon.SetActive (true);
		else
			soundoff.SetActive (true);

		Ball_Rotation_color.Fail = false;
	//	Level_Hard = 1;

		levelnor.SetActive (false);
		levelhigh.SetActive (false);
		leveleasy.SetActive (false);
		Debug.Log ("mainjkfhk..."+PlayerPrefs.GetInt ("Levels"));
		if (PlayerPrefs.GetInt ("Levels") == 2)
			levelnor.SetActive (true);
		else if (PlayerPrefs.GetInt ("Levels") == 1)
			leveleasy.SetActive (true);
		else if (PlayerPrefs.GetInt ("Levels") == 3)
			levelhigh.SetActive (true);
	}

	public void Play(){

		if (Test.MainAdStartday==0 ||( Test.MainAdStartday >= Test.installationDays)) Test.adsDestroy(Test.MainAdType);
		if (Test.GameAdStartday==0 ||(Test.GameAdStartday >= Test.installationDays)) Test.adsCalling (Test.GameAdType, Test.GameAdId);
		MyConstant.Variable_defenation (PlayerPrefs.GetInt ("Levels"));
		SceneManager.LoadScene(1);
	}

	public void SelectLevel(){
		Levelselectpannel.SetActive (true);
	}
	public void SelectLevelClose(){
		Levelselectpannel.SetActive (false);
	}
	public void selectNormal(){//Debug.Log ("mainjkfhk..."+PlayerPrefs.GetInt ("Levels"));
		levelnor.SetActive (true);
		levelhigh.SetActive (false);
		leveleasy.SetActive (false);
		PlayerPrefs.SetInt ("Levels", 2);
		Levelselectpannel.SetActive (false);
	}
	public void selectEasy(){//Debug.Log ("mainjkfhk..."+PlayerPrefs.GetInt ("Levels"));
		levelnor.SetActive (false);
		levelhigh.SetActive (false);
		leveleasy.SetActive (true);
		PlayerPrefs.SetInt ("Levels", 1);
		//Level_Hard = 0;
		Levelselectpannel.SetActive (false);
	}
	public void selecthard(){//Debug.Log ("mainjkfhkhardd..."+PlayerPrefs.GetInt ("Levels"));
		if (PlayerPrefs.GetFloat ("BestScoreNormal") >= 2000) {
			levelnor.SetActive (false);
			levelhigh.SetActive (true);
			leveleasy.SetActive (false);
			PlayerPrefs.SetInt ("Levels", 3);
			//Level_Hard = 2;
			Levelselectpannel.SetActive (false);
		} else {
			Hardlock.SetActive (true);
			StartCoroutine("hardLock");
		}
	}

	IEnumerator hardLock(){
		yield return new WaitForSeconds(.8f);
		Hardlock.SetActive (false);
	}

	public void Morebtn(){
		Application.OpenURL (Test.More);
	}

	public void fbbtn(){
		Application.OpenURL (Test.FbLink);
	}
	public void Rateit(){
		Application.OpenURL (Test.RateIt);
	}
	public void Exit(){
		Application.Quit();
	}
	public void Soundon(){
		soundoff.SetActive (true);
		soundon.SetActive (false);
		PlayerPrefs.SetInt ("sound", 1);
	}
	public void Soundoff(){
		soundoff.SetActive (false);
		soundon.SetActive (true);
		PlayerPrefs.SetInt ("sound", 0);
	}
	// Update is called once per frame
	void Update () {
		//if (Input.GetMouseButtonDown (0) && Levelselectpannel.activeSelf == true) {
		//	Levelselectpannel.SetActive (false);
		//}
	}
}
