using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnCursor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}
	
}
