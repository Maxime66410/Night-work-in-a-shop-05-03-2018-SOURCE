using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {

    [SerializeField] private GameObject pausePanel;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonController;

    public int pauseInt;

    void Start()
    {
        pausePanel.SetActive(false);
        pauseInt = 0;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                PausesGame();
            }
            else if (pausePanel.activeInHierarchy)
            {
                ContinueGame();
            }
        }
        if (pauseInt == 1)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void PausesGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        FirstPersonController.enabled = false;
        pauseInt = 1;
        //Disable scripts that still work while timescale is set to 0
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseInt = 0;
        FirstPersonController.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //enable the scripts again
    }
}
