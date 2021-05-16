using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthManager : MonoBehaviour
{
    [Header("Health Manager"), Space(5)]
    public int Health;
    public int MaxHealth = 250;
    public bool Isdead;
    public bool isdeadactive = true;

    [Header("UI Health Manager"), Space(5)]
    public Text textHealth;
    public Image imageDeath;
    public Text textDead;

    [Header("Animation Black Screen"), Space(5)]
    public Animator AnimatorOfScreen;

    [Header("Others Scripts & Components"), Space(5)]
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController FirstPersonController;
    public Collider colliderSphere;
    public Rigidbody RigidbodyCamera;
    public Camera CameraPlayer;
    public CharacterController CharacterController;
    public GameObject PhoneGameObject;
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    public void Start()
    {
        Isdead = false;
        Health = 100;
        MaxHealth = 250;
        imageDeath.color = new Color32(0, 0, 0, 0);
        imageDeath.enabled = false;
        textDead.enabled = false;
    }

    public void Update()
    {


        textHealth.text = "Health : " + Health;

        if(Health == 0 || Health <= 0)
        {
            Isdead = true;
        }

        if( Health == MaxHealth || Health >= MaxHealth)
        {
            Health = MaxHealth;
        }

        if(Isdead)
        {
            Health = 0;
            FirstPersonController.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            imageDeath.enabled = true;
            textDead.enabled = true;
            colliderSphere.enabled = true;
            RigidbodyCamera.isKinematic = false;
            CameraPlayer.usePhysicalProperties = true;
            CharacterController.enabled = false;
            PhoneGameObject.SetActive(false);
            AnimatorOfScreen.SetBool("IfDead", true);
            if(isdeadactive)
            {
                audioSource.PlayOneShot(audioClip[0],1.0f);

                audioSource.clip = audioClip[1];
                audioSource.Play();
                isdeadactive = false;
            }
        }
    }
}

