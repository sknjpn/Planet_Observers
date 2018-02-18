using UnityEngine;

public class SunLight : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Rotate(Vector3.up, 0.2f);
    }
}
