using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyConstant  {
	public static float wallObstacleSpeed;
	public static float wallObstacledestroytime;
	public static float ballforcejump;
	public static float ballrotationspeed;
	public static float generateTime;
	public static float WallRepeatTime;
	//public static bool Level_Hard;

	public static void Variable_defenation(int level){
		if (PlayerPrefs.GetFloat ("BestScoreNormal") == 0)
			PlayerPrefs.SetFloat ("BestScoreNormal", 0);

		if (PlayerPrefs.GetFloat ("BestScoreHard") == 0)
			PlayerPrefs.SetFloat ("BestScoreHard", 0);

		if (PlayerPrefs.GetInt ("sound") == 0)
			PlayerPrefs.SetInt ("sound", 0);

	//	Debug.Log ("wrong.."+level+"  "+PlayerPrefs.GetInt ("BestScoreNormal")+"  "+PlayerPrefs.GetInt ("BestScoreHard")+"   "+PlayerPrefs.GetString ("sound"));

		if (level == 2) {
			
			//wallObstacleSpeed = .4f;
			//wallObstacledestroytime = 12f;
			wallObstacleSpeed = 2.2f;
			wallObstacledestroytime = 8.3f;
			ballforcejump = 9f;
			ballrotationspeed = 5f;

			WallRepeatTime = 1f;
			generateTime = 1f;
		} 
		else if (level == 1) {

			//wallObstacleSpeed = .4f;
			//wallObstacledestroytime = 12f;
			wallObstacleSpeed = 2f;
			wallObstacledestroytime = 8f;
			ballforcejump = 9f;
			ballrotationspeed = 5f;

			WallRepeatTime = 1f;
			generateTime = 1f;
		} 
		else if(level == 3) {
		     //wallObstacleSpeed = .4f;
			//wallObstacledestroytime = 12f;
			wallObstacleSpeed = 2.8f;
			wallObstacledestroytime = 7f;
			ballforcejump = 9f;
			ballrotationspeed = 8f;

			WallRepeatTime = .7f;
			generateTime = .7f;
		}
	}
}
