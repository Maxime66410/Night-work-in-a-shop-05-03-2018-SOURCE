using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour {

	public void Start () {
		StartCoroutine(IntroInitialisation());
	}

	public IEnumerator IntroInitialisation()
    {
		yield return new WaitForSeconds(15.0f);
		SceneManager.LoadScene("Game", LoadSceneMode.Single);
	}
	
}
