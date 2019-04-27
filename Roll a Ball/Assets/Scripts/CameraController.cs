using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () { ///LateUpdate guarantees to run after all items are processed and updated.
		transform.position = player.transform.position + offset;
	}
}
///with LateUpdate, we know that the player has moved for a frame
///the camera will now move with the player's object