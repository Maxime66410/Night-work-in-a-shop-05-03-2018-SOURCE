using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour {


	void Start () {
		StartCoroutine(NextScene());
	}

	public IEnumerator NextScene()
    {
		yield return new WaitForSeconds(10.0f);
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
	}

}
