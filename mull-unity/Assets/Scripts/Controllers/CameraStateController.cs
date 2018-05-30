using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Handles the current state the camera (and thus the game) is in - is it mid focus transition, 
doing a quiz, or attached to the player. */
public class CameraStateController : MonoBehaviour {

	public float zoomSpeed = 2;
	public float turnSpeed = 2;


	public Vector3 settlementOffset = new Vector3 (0, 0, 50); //amount we stay away from settlements when focusing on them
	private Transform target;

	private CameraState currentState;

	private Vector3 lastPosition;
	private Quaternion lastRotation;
	private Vector3 basePosition;
	private float height;
	RaycastHit moveTo;

	// Use this for initialization
	void Awake() {
		

	}
	void Start() {
		basePosition = transform.position;
		SetState (new UnfocusedState (this));
		focus(GameObject.FindGameObjectWithTag("Player").transform);
	}

	// Update is called once per frame
	void LateUpdate () {
		currentState.Tick ();
	}


	/** Move camera into focus mode on a given transform**/
	public void focus(Transform transform) {
		target = transform;
		SetState (new FocusingState (this));

	}
	/** Move camera into into free movement mode **/
	public void unfocus() {
		SetState (new UnfocusingState (this));
	}


	public void SetState(CameraState state) {
		if (currentState != null) {
			currentState.OnStateExit ();

		}

		currentState = state;

		if (currentState != null) {
			currentState.Init ();
			currentState.OnStateEnter ();
		}

	}

	public CameraState GetState() {
		return currentState;
	}

	public Transform getTarget() {
		return target;
	}

	public Vector3 getLastPosition() {
		return lastPosition;
	}

	public void updateLastPosition() {
		lastPosition = transform.position;
	}

	public Quaternion getLastRotation() {
		return lastRotation;
	}

	public void updateLastRotation() {
		lastRotation = transform.rotation;
	}

	public void setHeight(float height) {
		this.height = height;
	}

	public float getHeight() {
		return height;
	}

	public Vector3 getBasePosition() {
		return basePosition;
	}





}
