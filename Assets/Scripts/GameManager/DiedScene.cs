using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiedScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(ChangementDeScene());
	}

	public IEnumerator ChangementDeScene()
    {
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}

}
