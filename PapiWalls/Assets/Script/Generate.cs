using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Generate : MonoBehaviour {

	public GameObject rocks;
	public GameObject Obs;
	public static bool obs_genrate;
	public static int obstacleLevel;
	public GameObject FailPannel;

	// Use this for initialization
	void Start () {
		
		obs_genrate = false;
		obstacleLevel = 1;
		InvokeRepeating ("CreateBase", 0,MyConstant.WallRepeatTime);
		StartCoroutine (HardnessLevel());
	}
	IEnumerator HardnessLevel(){
		yield return new WaitForSeconds(12f);
		obstacleLevel = 2;
		yield return new WaitForSeconds(22);
		obstacleLevel = 3;
		MyConstant.ballrotationspeed = MyConstant.ballrotationspeed+1;
		yield return new WaitForSeconds(28f);
		obstacleLevel = 4;
		MyConstant.wallObstacleSpeed = 3f;
		MyConstant.ballrotationspeed = MyConstant.ballrotationspeed+2;
		yield return new WaitForSeconds(38f);
		obstacleLevel = 5;
		MyConstant.wallObstacleSpeed = 3.5f;
		MyConstant.ballrotationspeed =MyConstant.ballrotationspeed+1;
	}
	void CreateBase(){
		Instantiate (rocks);
	}
	public void generate_Obs(){
		obs_genrate = false;
		Instantiate (Obs);
	}

	public void restart(){
		Ball_Rotation_color.Fail = false;
		SceneManager.LoadScene(1);
		if (Test.GameAdStartday==0 ||(Test.GameAdStartday >= Test.installationDays)) Test.adsCalling (Test.GameAdType, Test.GameAdId);
	}

	public void back_menu(){
		SceneManager.LoadScene(0);
	}
	// Update is called once per frame
	void Update () {
		if (obs_genrate == true)
			generate_Obs ();
	}
}
