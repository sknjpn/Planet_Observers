﻿using UnityEngine;

public class MainCamera : MonoBehaviour
{
    Vector3 targetPosition;
    float length;
    float targetLength;

    void Start()
    {
        length = transform.position.magnitude;
        targetLength = length;
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            RaycastHit hit;

            Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit);
            targetPosition = hit.point;
        }

        targetLength *= (1.0f - Input.GetAxis("Mouse ScrollWheel"));

        length = Mathf.Lerp(length, targetLength, 0.1f);

        transform.position = Vector3.Lerp(transform.position, targetPosition.normalized * length, 0.1f).normalized * length;

        transform.LookAt(Vector3.zero);
    }
}