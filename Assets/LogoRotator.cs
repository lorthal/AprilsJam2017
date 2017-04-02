using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoRotator : MonoBehaviour {

    public float rotationSpeed;

    private RectTransform rTransorm;

    private void Start()
    {
        rTransorm = GetComponent<RectTransform>();
    }

    void Update () {
        rTransorm.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
	}
}
