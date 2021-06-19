using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour {

    public Text text;
    public Image Image;
    public Sprite[] Sprite;

    public void Start()
    {
        StartCoroutine(LoadingScreens());
        StartCoroutine(LoadingImaged());
    }

    public IEnumerator LoadingScreens()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.05f);
            text.text = text.text + ".";

            if(text.text == "................................................................................................................................................................................................................................................................................................................................")
            {
                SceneManager.LoadScene("Intro", LoadSceneMode.Single);
            }
        }
    }

    public IEnumerator LoadingImaged()
    {
        while(true)
        {
            yield return new WaitForSeconds(5.0f);
            Image.sprite = Sprite[Random.Range(0, Sprite.Length)];
        }
    }
}
