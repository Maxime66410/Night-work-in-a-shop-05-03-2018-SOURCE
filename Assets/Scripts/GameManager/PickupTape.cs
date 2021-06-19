using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PickupTape : MonoBehaviour {

    [Header("Others Scripts"), Space(5)]
    public GameManager gameManager;

    [Header("UI"), Space(5)]
    public Text textPickupView;

    [Header("Value Option"), Space(5)]
    public float rayLenght = 2f;
    public LayerMask layermask;
    public AudioSource audioSource;
    public AudioClip audioClip;

    public void Start()
    {
        audioSource.clip = audioClip;
    }

    public void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayLenght, layermask) && gameManager.Tape != 10 && this.gameObject)
        {
            textPickupView.enabled = true;
            if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                audioSource.Play();
                gameManager.Tape = gameManager.Tape + 1;
                textPickupView.enabled = false;
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            textPickupView.enabled = false;
        }
    }
}
