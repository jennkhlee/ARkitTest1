using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropDotLogic : MonoBehaviour {
	public GameObject gameLogic;

	public AudioClip generateClip;
	public AudioClip deathClip;
	public AudioClip collectClip;

	// Use this for initialization
	void Start () {
		gameLogic = GameObject.Find ("gameLogic");

		// audio calling
		this.GetComponent<AudioSource> ().PlayOneShot (generateClip);

		// controlling increasing speed for falling mugs
		this.GetComponent<Rigidbody> ().drag = 20 - ((gameLogic.GetComponent<gameLogic> ().gameScore + 1) / 3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.tag == "collectable") {}

		else {
			// take away hp if mug hits ground

			// show where it hits
			Debug.Log (this.gameObject.name + " just hit " + col.gameObject.name);

			// tells game logic script to run decrease HP function
			gameLogic.GetComponent<gameLogic> ().decreaseHP ();

			// u ded
			this.GetComponent<AudioSource> ().PlayOneShot (generateClip, .3f);

			// gameLogic.GetComponent<gameLogic> ().hp -= 1;
			// gameLogic.GetComponent<gameLogic> ().hpDisplay.text = "HP: " + gameLogic.GetComponent<gameLogic> ().hp;

			// gets rid of mug after 5 sec
			Destroy (this.gameObject,1);
		}
	 
	}

	public void getCollected () {


		// this.GetComponent<MeshRenderer> ().enabled = false;

		this.GetComponent<AudioSource> ().PlayOneShot (collectClip, .4f);

		Handheld.Vibrate ();

		Destroy (this.gameObject);

	}

}
