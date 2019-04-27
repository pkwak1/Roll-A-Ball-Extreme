using UnityEngine;
using UnityEngine.UI; //UI for Unity
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed; 
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count; //holds count of cubes picked up

	void Start ()
	{
		rb = GetComponent<Rigidbody> (); ///creates the rb variable to reference later on
		count = 0;
		SetCountText (); //function called 
		winText.text = "";
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal"); ///get's the physics of each axis
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical); ///no y b/c the ball doesn't fly

		rb.AddForce (movement * speed); ///vector3 means (x,y,z)
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1; //when the sphere hits a cube, add score +1
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 12) 
		{
			winText.text = "You Win!";
		}
	}
}
//Destroy(other.gameObject); //destroys everything about the other object, including its children
//Destroy(other.gameObject)
//if (other.gameObject.CompareTag("Player")) 
	//gameObject.SetActive(false); //checks the player box, visible on or off
//this is a description