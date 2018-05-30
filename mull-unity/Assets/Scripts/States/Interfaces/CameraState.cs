using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Interface for basic state handling **/
public abstract class CameraState{
	protected CameraStateController camera;

	public abstract void Tick();
	public virtual void Init () {

	}
	public virtual void OnStateEnter() {
	}
	public virtual void OnStateExit() {
	}

	public CameraState(CameraStateController camera) {
		this.camera = camera;
	}
}
