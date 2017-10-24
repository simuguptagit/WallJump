using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ball_Rotation_color : MonoBehaviour {
	//public float speed = 5f;
	//public Vector3 jumpForce = new Vector3(0, 5 , 0);
	public Rigidbody rb;
	public GameObject smily;
	public GameObject sad_smily;
	public Transform Destroy ;
	public Text GetScore;
	float  score;
	//float maxJumpHeight = 4.0f;
	//float groundHeight;
	Vector3 groundPos;
	//float jumpSpeed = .1f;
	//float fallSpeed = .1f;
	//public bool inputJump = false;
	public bool grounded = true;
	public static bool Fail ;
	public static bool collisionfail ;
	public GameObject FailFont;

	public GameObject FailPannel;
	public Text CurrentScoreText;
	public Text HighScoreText;

	private static float scoreweight;
	public AudioSource tapSound;
	public AudioSource colisionSound;
	// Use this for initialization
	void Start () {
		collisionfail=false;
		tapSound.Stop();
		colisionSound.Stop ();

		if ((Test.FailAdStartday==0 || (Test.FailAdStartday >= Test.installationDays)) && isFailrequest(Test.FailAdOccurance)) Test.adsCalling (Test.FailAdType, Test.FailAdId);

		smily.SetActive (true);
		sad_smily.SetActive (false);

		if (PlayerPrefs.GetInt ("Levels") <=2)
			gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
		else 
		gameObject.GetComponent<Renderer> ().material.color = Color.magenta;
		
		score = 0;
		scoreweight = .05f;

		StartCoroutine (Calculation_Score (scoreweight));
		StartCoroutine (Calculation_Scoretime ());
	}
	IEnumerator Calculation_Scoretime(){
		if (Fail == false) {
			yield return new WaitForSeconds (.5f);
			scoreweight -= .001f;
			StartCoroutine (Calculation_Scoretime ());
		}
	}
	IEnumerator Calculation_Score(float x){
		if (Fail == false) {
			yield return new WaitForSeconds (x);
			score++;
			GetScore.text = score.ToString ();
			StartCoroutine (Calculation_Score (scoreweight));
		}
	}
	void OnTriggerEnter(Collider other)
	{//Debug.Log("y position..."+groundPos.y);
		if (collisionfail == false) {
			if (other.name == "Cube") {
				rb.GetComponent<Rigidbody> ().useGravity = false;
				rb.GetComponent<Rigidbody> ().isKinematic = true;
				grounded = true;
				rb.transform.position = groundPos;
			} else {
				collisionfail = true;
				rb.GetComponent<Rigidbody> ().useGravity = false;
				rb.GetComponent<Rigidbody> ().isKinematic = true;
				Fail = true;
				if(PlayerPrefs.GetInt ("sound") == 0)
					colisionSound.Play();
				
				smily.SetActive (false);
				sad_smily.SetActive (true);
				Destroy.GetComponent<ParticleSystem> ().gameObject.transform.position = transform.position;
				Destroy.GetComponent<ParticleSystem> ().gameObject.SetActive (true);	
				Destroy.GetComponent<ParticleSystem> ().Play ();
				//FailFont.SetActive (true);
				StartCoroutine ("StartFailPannel");
			}
		}
	}

	IEnumerator StartFailPannel(){
		yield return new WaitForSeconds(.3f);
		FailFont.SetActive (true);
		if (Test.GameAdStartday==0||(Test.GameAdStartday >= Test.installationDays)) Test.adsDestroy(Test.GameAdType);
		if ((Test.FailAdStartday==0 ||(Test.FailAdStartday <= Test.installationDays)) && isFailDisplay(Test.FailAdOccurance)) Test.adsCallingrewardFull (Test.FailAdType, Test.FailAdId);
		yield return new WaitForSeconds(1.5f);
		FailFont.SetActive (false);

		if (PlayerPrefs.GetFloat ("BestScoreNormal") < score && PlayerPrefs.GetInt ("Levels") == 2)
			PlayerPrefs.SetFloat ("BestScoreNormal", score);
		else if (PlayerPrefs.GetFloat ("BestScoreEasy") < score && PlayerPrefs.GetInt ("Levels") == 1)
			PlayerPrefs.SetFloat ("BestScoreEasy", score);
		else if (PlayerPrefs.GetFloat ("BestScoreHard") < score && PlayerPrefs.GetInt ("Levels") == 3)
			PlayerPrefs.SetFloat ("BestScoreHard", score);
		
		if(PlayerPrefs.GetInt ("Levels") == 2)
			HighScoreText.text = PlayerPrefs.GetFloat ("BestScoreNormal").ToString();
		else if(PlayerPrefs.GetInt ("Levels") == 1)
			HighScoreText.text = PlayerPrefs.GetFloat ("BestScoreEasy").ToString();
		else
			HighScoreText.text = PlayerPrefs.GetFloat ("BestScoreHard").ToString();
		CurrentScoreText.text = score.ToString();
		FailPannel.SetActive (true);
	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (Test.GameAdStartday==0||(Test.GameAdStartday >= Test.installationDays)) Test.adsDestroy(Test.GameAdType);
			 SceneManager.LoadScene(0);
		}


		if (Input.GetMouseButtonDown (0) && Fail == false && grounded ==true ) {//Debug.Log("before..."+transform.position+"  "+groundHeight+"  "+maxJumpHeight);
			if(PlayerPrefs.GetInt ("sound") == 0)
				tapSound.Play();
			grounded = false;
			groundPos = rb.transform.position;
			rb.GetComponent<Rigidbody>().isKinematic = false;
			rb.GetComponent<Rigidbody>().useGravity = true;
			rb.AddForce(Vector3.up*MyConstant.ballforcejump, ForceMode.Impulse);
		
		}
		if(Fail == false && grounded == true)
			transform.Rotate(0,0,MyConstant.ballrotationspeed);

	}

	public bool isFailrequest(int server_val){
		int local_val = PlayerPrefs.GetInt ("FailOccurLocal");
		local_val++;
		//Debug.Log ("After2222.."+server_val+"  "+local_val);
		if(server_val == 0)
			return true;
		if (local_val % server_val == 0)
			return true;
		else
			return false;

	}
	public bool isFailDisplay(int server_val){
		int local_val = PlayerPrefs.GetInt ("FailOccurLocal");
		local_val++;
		//Debug.Log ("After333.."+server_val+"  "+local_val);
		if(server_val == 0)
			return true;
		if(server_val == local_val)
			PlayerPrefs.SetInt("FailOccurLocal",  0) ;
		else
			PlayerPrefs.SetInt("FailOccurLocal",  local_val) ;

		if (local_val % server_val == 0)
			return true;
		else
			return false;

	}
}
