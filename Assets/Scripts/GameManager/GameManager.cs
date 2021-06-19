using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [Header("Others Scripts"), Space(5)]
    public Data data;
    public HealthManager healthManager;

    [Header("Value Scripts"), Space(5)]
    public int Tape;
    public Text textTape;
    public bool IsWin;

    public void Start()
    {
        Tape = 0;
        IsWin = false;
    }

    public void Update()
    {
        textTape.text = Tape.ToString() + " / 10";

        if(Tape == 10 && healthManager.Isdead == false)
        {
            IsWin = true;
        }

        if(IsWin)
        {
            healthManager.FirstPersonController.enabled = false;
            StartCoroutine(WinUser());
        }

        if(healthManager.Isdead == true && !IsWin)
        {
            healthManager.FirstPersonController.enabled = false;
            StartCoroutine(DeadSorryUser());
        }
    }

    public IEnumerator DeadSorryUser()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Dead", LoadSceneMode.Single);
    }

    public IEnumerator WinUser()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Win", LoadSceneMode.Single);
    }

}
