using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraSystem : MonoBehaviour {

    [Header("UI"), Space(5)]
    public Text textUseView;
    public Text textUseViews;
    public Text textMonitorName;

    [Header("Value Option"), Space(5)]
    public float rayLenght = 2f;
    public LayerMask layermask;
    public LayerMask layermasks;
    public LayerMask layermaskss;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public RenderTexture[] renderTextures;
    public Camera[] cameras;
    public int i = 0;
    public Material materialOfCam;

    [Header("GameObject"), Space(5)]
    public GameObject PreviewBtn;
    public GameObject NextBtn;
    public GameObject Screen;

    public void Start()
    {
        audioSource.clip = audioClip;

        for (int a = 0; a < cameras.Length; a++)
        {
            cameras[a].enabled = false;
        }
    }

    public void Update()
    {
        materialOfCam.SetTexture("_MainTex", renderTextures[i]);
        cameras[i].enabled = true;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, rayLenght, layermask) && PreviewBtn)
        {
            textUseView.enabled = true;
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (i > 0)
                {
                    i--;
                }
            }
        }
        else
        {
            textUseView.enabled = false;
        }

        RaycastHit hits;
        Ray rays = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rays, out hits, rayLenght, layermasks) && NextBtn)
        {
            textUseViews.enabled = true;
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                if (i + 1 < renderTextures.Length && i + 1 < cameras.Length)
                {
                    i++;
                }
            }
        }
        else
        {
            textUseViews.enabled = false;
        }

        RaycastHit hitss;
        Ray rayss = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayss, out hitss, rayLenght, layermaskss) && Screen)
        {
            textMonitorName.enabled = true;

            if(materialOfCam.GetTexture("_MainTex").Equals(renderTextures[0]))
            {
                textMonitorName.text = "CamA";
            }
            if (materialOfCam.GetTexture("_MainTex").Equals(renderTextures[1]))
            {
                textMonitorName.text = "CamB";
            }
            if (materialOfCam.GetTexture("_MainTex").Equals(renderTextures[2]))
            {
                textMonitorName.text = "CamC";
            }
            if (materialOfCam.GetTexture("_MainTex").Equals(renderTextures[3]))
            {
                textMonitorName.text = "CamD";
            }
        }
        else
        {
            textMonitorName.enabled = false;
        }
    }
}
