using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneSettings : MonoBehaviour {

    [Header("GameObject Settings"), Space(5)]
    public GameObject CameraPhone;
    public Light LightPhone;
    public DeferredNightVisionEffect DeferredNightVisionEffectPhone;
    public AudioSource audioSource;
    public AudioClip[] AudioClips;
    public bool isBug = false;
    public bool isOn = true;

    public void Update()
    {
        if(!isBug)
        {
            StopCoroutine(BugPhone());

            if(!isOn)
            {
                LightPhone.enabled = false;
                DeferredNightVisionEffectPhone.enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.F) && isOn)
            {
                if (LightPhone.enabled == false)
                {
                    LightPhone.enabled = true;
                }
                else
                {
                    LightPhone.enabled = false;
                }
                audioSource.clip = AudioClips[0];
                audioSource.Play();
            }
            /*
            if (Input.GetKeyDown(KeyCode.G) && isOn)
            {
                if (DeferredNightVisionEffectPhone.enabled == false)
                {
                    DeferredNightVisionEffectPhone.enabled = true;
                }
                else
                {
                    DeferredNightVisionEffectPhone.enabled = false;
                }
                audioSource.clip = AudioClips[0];
                audioSource.Play();
            }*/

            if (Input.GetKeyDown(KeyCode.V))
            {
                if (CameraPhone.GetComponent<Camera>().cullingMask == 0)
                {
                    CameraPhone.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
                    CameraPhone.GetComponent<Camera>().farClipPlane = 100;
                    CameraPhone.GetComponent<Camera>().cullingMask = -1;
                    isOn = true;
                }
                else
                {
                    CameraPhone.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
                    CameraPhone.GetComponent<Camera>().farClipPlane = 1;
                    CameraPhone.GetComponent<Camera>().cullingMask = 0;
                    isOn = false;
                }

                audioSource.clip = AudioClips[1];
                audioSource.Play();
            }
        }
        else
        {
            StartCoroutine(BugPhone());
        }
    }

    public IEnumerator BugPhone()
    {
        while(isBug)
        {
            if (LightPhone.enabled == false)
            {
                LightPhone.enabled = true;
                audioSource.clip = AudioClips[0];
                audioSource.Play();
            }
            else
            {
                LightPhone.enabled = false;
                audioSource.clip = AudioClips[0];
                audioSource.Play();
            }

            yield return new WaitForSeconds(3);

         /*   if (DeferredNightVisionEffectPhone.enabled == false)
            {
                DeferredNightVisionEffectPhone.enabled = true;
                audioSource.clip = AudioClips[0];
                audioSource.Play();
            }
            else
            {
                DeferredNightVisionEffectPhone.enabled = false;
                audioSource.clip = AudioClips[0];
                audioSource.Play();
            }*/

            yield return new WaitForSeconds(3);

            if (CameraPhone.GetComponent<Camera>().cullingMask == 0)
            {
                CameraPhone.GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
                CameraPhone.GetComponent<Camera>().farClipPlane = 100;
                CameraPhone.GetComponent<Camera>().cullingMask = -1;
                audioSource.clip = AudioClips[1];
                audioSource.Play();
            }
            else
            {
                CameraPhone.GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;
                CameraPhone.GetComponent<Camera>().farClipPlane = 1;
                CameraPhone.GetComponent<Camera>().cullingMask = 0;
                audioSource.clip = AudioClips[1];
                audioSource.Play();
            }

            yield return new WaitForSeconds(3);
        }
    }
}
