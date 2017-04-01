using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearController : MonoBehaviour {

    public enum VisibleState
    {
        VISIBLE,
        GONE
    }

    public float visibleTime;
    public float goneTime;

    private float timerV;
    private float timerG;
    MeshRenderer mesh;
    BoxCollider[] cols;
    VisibleState visibility;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        cols = GetComponents<BoxCollider>();
        visibility = VisibleState.VISIBLE;
    }

    void Update () {
		if(visibility == VisibleState.VISIBLE)
        {
            if(timerV >= visibleTime)
            {
                visibility = VisibleState.GONE;
                mesh.enabled = false;
                foreach (var item in cols)
                {
                    item.enabled = false;
                }
                timerV = 0;
            }
            else
            {
                timerV += Time.deltaTime;
            }
        }

        if (visibility == VisibleState.GONE)
        {
            if (timerG >= goneTime)
            {
                visibility = VisibleState.VISIBLE;
                mesh.enabled = true;
                foreach (var item in cols)
                {
                    item.enabled = true;
                }
                timerG = 0;
            }
            else
            {
                timerG += Time.deltaTime;
            }
        }
    }
}
