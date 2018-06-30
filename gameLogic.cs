 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameLogic : MonoBehaviour {


	// instantiating dropDot
	public GameObject dropDot;
	// where to drop dot
	public GameObject camControlPoint;

	public int gameScore;
	public int hp;
	public Text scoreDisplay;
	public Text hpDisplay;

	public GameObject restartButton;

	// array for how many drops total in that current round
	public GameObject[] mugsInScene;


	public AudioClip gameOver;



	// Use this for initialization
	void Start () {
		gameScore = 0;
		hp = 20;

		scoreDisplay.text = "Score: "  + gameScore;
		hpDisplay.text = "HP: " + hp;

		// starts w restart off
		restartButton.SetActive (false);
	}


	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			// call ze dotz
			//createDrops ();
			Debug.Log("Tapped");
			RaycastHit hit;
			Ray rayPoint = Camera.main.ScreenPointToRay (Input.mousePosition);

			// out = returning point + object it collided with (kinda)
			// Physics.Raycast is accessing the actual raycast stuff
			if (Physics.Raycast (rayPoint, out hit)) {
				Debug.Log("Hit Something");
				if (hit.transform.gameObject.tag == "collectable") {
					Debug.Log("That something is " + hit.transform.gameObject.name);
					// makes taps disappear
					// hit needs to reference the transform because it's looking
					// for the collision (associated with the transform) first, not necessarily the game object.

					//this.GetComponent<AudioSource> ().PlayOneShot (hitClip, .3f);


					//Destroy(hit.transform.gameObject);

					hit.transform.gameObject.GetComponent<dropDotLogic> ().getCollected ();


					// increment score
					gameScore++;

					scoreDisplay.text = "Score: " + gameScore;

				}

			}

		}


	}


	public void createDrops(Vector3 spawnPosition) {

		// (prefab type, location xyz, rotation)
		GameObject dot = Instantiate (dropDot, spawnPosition, Quaternion.identity);



	}

	// HP decreases
	public void decreaseHP () {

		// if alive, decrement hp
		if (hp > 0) {
			hp -= 1;
		}

		// show button
		else {
			restartButton.SetActive (true);

			// play get over sound
			this.GetComponent<AudioSource> ().PlayOneShot (gameOver, .3f);
		}

		hpDisplay.text = "HP: " + hp;
	}



	public void restart () {
		gameScore = 0;
		hp = 20;

		// reset text strings
		scoreDisplay.text = "Score: "  + gameScore;
		hpDisplay.text = "HP: " + hp; 

		// uncheck button active
		restartButton.SetActive (false);


		// this part refreshes / deletes all mugs in scene
		// the array catches all the mugs (tags w 'collectable')
		mugsInScene = GameObject.FindGameObjectsWithTag ("collectable");

		// identifying 'mugs' from the array and destroys all 
		foreach (GameObject mug in mugsInScene) {
			Destroy (mug);
		}

	}


}


	