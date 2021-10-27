using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeEvent : MonoBehaviour {
    [Header("Others Scripts"), Space(5)]
    public GameObject[] pickupTape;
    public int i;

    public void Start()
    {
        for(i = 0; i < pickupTape.Length; i++)
        {
            pickupTape[i].SetActive(true);
        }
    }
}
