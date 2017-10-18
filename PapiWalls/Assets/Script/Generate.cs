using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Generate : MonoBehaviour {

	public GameObject rocks;
	public GameObject Obs;
	public static bool obs_genrate;
	//public static bool Level_Hard;
	//float generateTime;
	public static int obstacleLevel;
	public GameObject FailPannel;

	// Use this for initialization
	void Start () {
		
		obs_genrate = false;
		obstacleLevel = 1;
		InvokeRepeating ("CreateBase", 0,MyConstant.WallRepeatTime);
		//generateTime =5f;
		//StartCoroutine (generateObstacle());
		StartCoroutine (HardnessLevel());
		//InvokeRepeating ("generateObstacle", 0,5f);
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
/*	IEnumerator generateObstacle(){Debug.Log ("obstacle generate..."+MyConstant.generateTime);
		if(Ball_Rotation_color.Fail == false )
		yield return new WaitForSeconds(MyConstant.generateTime);
		if(Ball_Rotation_color.Fail == false )
		Instantiate (Obs);
		//MyConstant.generateTime = Random.Range (MyConstant.generateTime, MyConstant.generateTime+3);
		if(Ball_Rotation_color.Fail == false )
		StartCoroutine (generateObstacle());
	}
*/
	public void restart(){
		Ball_Rotation_color.Fail = false;
		SceneManager.LoadScene(1);
	}

	public void back_menu(){
		SceneManager.LoadScene(0);
		//FailPannel.SetActive (false);
	}
	// Update is called once per frame
	void Update () {
		if (obs_genrate == true)
			generate_Obs ();
	}
}
