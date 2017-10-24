using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsForword : MonoBehaviour {
	//public float delta = .5f;  // Amount to move left and right from the start point
	//public float speed = .4f; 
	public GameObject G1;
	public GameObject G2;
	public string s; 
	//private Vector3 startPos;

	// Use this for initialization
	void Start () {
		
		if (s.StartsWith ("Ca")) {
			
			Vector3 v = G1.transform.position;
			Vector3 v1 = G2.transform.position;
			if (Generate.obstacleLevel == 1) {
				float i = Random.Range (.2f,1.5f);
				//Debug.Log ("mdnksjdnfk111..."+i);
				v1.y = v1.y + i;
				G2.transform.position = v1;
				G1.SetActive (false);
			}else if(Generate.obstacleLevel == 2){
				float i = Random.Range (.08f,.2f);
			  // Debug.Log ("mdnksjdnfk222..."+i);
				v1.y = v1.y + i;
				G2.transform.position = v1;

				v.y = v.y-i;
				G1.transform.position = v;
			}
			else if(Generate.obstacleLevel == 3){
				float i = Random.Range (.3f,.6f);
			//	Debug.Log ("mdnksjdnfk333..."+i);
				v1.y = v1.y + i;
				G2.transform.position = v1;

				float j = Random.Range (.2f,.8f);
				//Debug.Log ("mdnksjdnfk..."+i+"   "+j);
				v.y = v.y-j;
				G1.transform.position = v;
				//G1.SetActive (false);
			}
			else if(Generate.obstacleLevel == 4){
				float i = Random.Range (.2f,.5f);

				v1.y = v1.y + i;
				G2.transform.position = v1;

				float j = Random.Range (.8f,1f);
				//Debug.Log ("mdnksjdnfk44444..."+i+"   "+j);
				v.y = v.y-j;
				G1.transform.position = v;
			}
			else if(Generate.obstacleLevel ==5){
				float i = Random.Range (.15f,.4f);

				v1.y = v1.y + i;
				G2.transform.position = v1;

				float j = Random.Range (.9f,1.3f);
				//Debug.Log ("mdnksjdnfk5555..."+i+"   "+j);
				v.y = v.y-j;
				G1.transform.position = v;
			}
		} else {	
		}
		StartCoroutine (destroyWalls());
	}

	// Update is called once per frame
	void Update () {
		if(Ball_Rotation_color.Fail == false )
			transform.Translate(Vector3.right*MyConstant.wallObstacleSpeed*Time.smoothDeltaTime*3f);
	}

	IEnumerator destroyWalls(){

		yield return new WaitForSeconds(MyConstant.wallObstacledestroytime);
		if(Ball_Rotation_color.Fail == false)
		Destroy(this.gameObject);
	}
}
