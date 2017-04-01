using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDestroyer : MonoBehaviour {

    private List<Transform> t;

    private void Start()
    {
        t = new List<Transform>(GetComponentsInChildren<Transform>());
    }

    public void DestroyHeart()
    {
        Destroy(t[t.Count-1].gameObject);
        t.RemoveAt(t.Count - 1);        
    }
}
