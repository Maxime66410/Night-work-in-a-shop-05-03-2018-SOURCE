using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityOrNot : MonoBehaviour {

    public MannequinScript MannequinScript;

    // Disable the behaviour when it becomes invisible...
    void OnBecameInvisible()
    {
        MannequinScript.isMove = true;
    }

    // ...and enable it again when it becomes visible.
    void OnBecameVisible()
    {
        MannequinScript.isMove = false;
        MannequinScript.IsVisible();
    }
}
