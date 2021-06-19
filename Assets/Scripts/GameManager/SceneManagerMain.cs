using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMain : MonoBehaviour {

    public GameObject[] CanvasPanel;


    public void BtnPlay()
    {
        SceneManager.LoadScene("LoadingScreen", LoadSceneMode.Single);
    }

    public void BtnReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void BtnOption()
    {
        if(CanvasPanel[0].activeSelf == true)
        {
            CanvasPanel[0].SetActive(false);
            CanvasPanel[1].SetActive(true);
        }
        else
        {
            CanvasPanel[0].SetActive(true);
            CanvasPanel[1].SetActive(false);
        }
    }

    public void BtnQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void BtnFurranyStudio()
    {
        Application.OpenURL("https://furranystudio.fr/");
    }

}
