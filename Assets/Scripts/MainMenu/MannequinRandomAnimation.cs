using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MannequinRandomAnimation : MonoBehaviour {

    public Animator animationPlay;
    public int RandomAnimation;

    public void Update()
    {
        RandomAnimation = Random.Range(0, 6);
        animationPlay.SetInteger("IdleState", RandomAnimation);
    }
}
