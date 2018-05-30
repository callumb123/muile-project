using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Handles all player movement - looking and walking around. Fetches input from the user */
public class PlayerController : MonoBehaviour {


	[SerializeField]
	private float gravityScale = 70f;
	[SerializeField]
	private float speed;

	private bool grounded;
	private bool isControlled = false;

	Rigidbody playerRigidbody;
	Collider playerCollider;
	MouseLook _mouseLook= new MouseLook ();
	GameObject mainCameraObject;
	CameraStateController cc;


	float horizontalValue, verticalValue;

	// Use this for initialization
	void Awake () {
		playerRigidbody = GetComponent<Rigidbody> ();
		mainCameraObject = GameObject.FindGameObjectWithTag ("MainCamera");
		cc = mainCameraObject.GetComponent<CameraStateController> ();
		_mouseLook = new MouseLook ();
	}

	void Start() {
		Physics.gravity = Vector3.down * gravityScale;
		_mouseLook.Init (transform, mainCameraObject.transform);
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (!isControlled) {
			_mouseLook.SetCursorLock (false);
			return;
		}
		if(Input.GetKey(KeyCode.Escape)) {
			cc.unfocus ();
			return;
		}

		//move
		horizontalValue = Input.GetAxis ("Horizontal") * speed;
		verticalValue = Input.GetAxis ("Vertical") * speed;

		//store old gravity value
		Vector3 yValueFix = new Vector3(0f, playerRigidbody.velocity.y, 0f);
		Vector3 verticalHorizontalValue = (horizontalValue * transform.right + verticalValue * transform.forward);
		playerRigidbody.velocity = verticalHorizontalValue *Time.deltaTime + yValueFix;

	}
		
	void LateUpdate(){
		if (!isControlled) {
			_mouseLook.SetCursorLock (false);
			return;
		}
		_mouseLook.SetCursorLock (true);
		_mouseLook.LookRotation (transform, mainCameraObject.transform);

	}


	public void setIsControlled(bool value) {
		isControlled = value;
	}

	/* Sets grounded to true with player is touching the terrain */
	public void OnCollisionEnter(Collision theCollision) {
		if (theCollision.gameObject.name == "Terrain")
			grounded = true;
	}

	/* Sets grounded to false when player is in the air (not touching the terrain) */
	public void OnCollisionExit(Collision theCollision) {
		if (theCollision.gameObject.name == "Terrain")
			grounded = false;
	}
	
	/* Returns whether the player is on the ground/in the water or not */
	public bool isGrounded() {
		return grounded;
	}
	
	public float getYValue() {
		return transform.position.y;
	}
}
