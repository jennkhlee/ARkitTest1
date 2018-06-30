using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeItRain : MonoBehaviour {

	public int score;
	public int scoreM;

	public GameObject gameLogic;

	// 60 fps roughly for VR
	// Use this for initialization
	void Start () {
		score = 0;
		scoreM = 50;

		// searches all scripts for this particular script so we can use the public function
		gameLogic = GameObject.Find ("gameLogic");

	}


	// Update is called once per frame
	void Update () {

		// increment counter each frame as long as max is not reached
		if (score < scoreM) {
			score++;
		}

		// reset score
		else {
			// accessing everything from the gameLogic script
			// createDrops() receives the vector3 point per update from the randomPos() function
			gameLogic.GetComponent<gameLogic>().createDrops(randomPos());

			score = 0;
		}
	}


	public Vector3 randomPos() {
		// mesh is a component that gets the mesh from this object
		Mesh objectMesh = this.gameObject.GetComponent<MeshFilter> ().mesh;

		// receives bounds in the mesh
		Bounds bounds = objectMesh.bounds;

		// game object x pos - whole global scale of object x pos * bounds size x * .5
		// .5f 'f' forces declaration into float
		float minX = this.gameObject.transform.position.x - this.gameObject.transform.lossyScale.x * bounds.size.x * .5f;
		float minZ = this.gameObject.transform.position.z - this.gameObject.transform.lossyScale.z * bounds.size.z * .5f;

		float maxX = this.gameObject.transform.position.x + this.gameObject.transform.lossyScale.x * bounds.size.x * .5f;
		float maxZ = this.gameObject.transform.position.z + this.gameObject.transform.lossyScale.z * bounds.size.z * .5f;

		// this is the individual random position generated per dot
		Vector3 randomDotPos = new Vector3 (Random.Range (minX, maxX), .5f, Random.Range (minZ, maxZ));

		// passes back to createDrops();
		return randomDotPos;

	}

}
