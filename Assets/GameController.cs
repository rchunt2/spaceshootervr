using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject SpinnySpaceRock;
	public GameObject Enemy;
	public Vector3 spawnValues;
	public int SpinnySpaceRockCount;
	public float spawnWait;

	public float startWait;
	public float waveWait;

	public GUIText scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		score = 0;
		UpdateScore ();

		StartCoroutine (SpawnWaves ());

	}
	
	// Update is called once per frame
	void Update () {
	 
	}

	IEnumerator SpawnWaves(){



		Vector3 spawnPosition = new Vector3 (Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity;

		yield return new WaitForSeconds (startWait);
		while (true) {	
			for (int i = 0; i < SpinnySpaceRockCount; i++) {
				Instantiate (SpinnySpaceRock, spawnPosition, spawnRotation);
				spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				yield return new WaitForSeconds (spawnWait);

			}  yield return new WaitForSeconds (waveWait);
			  
		}
	}


	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	public void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

}
