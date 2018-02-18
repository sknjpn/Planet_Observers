using UnityEngine;
using System.Collections;

public class Eye : MonoBehaviour
{
    [SerializeField] float sy = 10f;
    float angle = 0;

    void Update()
    {
        angle -= sy * Input.GetAxis("Mouse Y");

        Debug.Log(angle);
        if (angle < -80) { angle = -80; }
        if (angle > 80) { angle = 80; }

        transform.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}
