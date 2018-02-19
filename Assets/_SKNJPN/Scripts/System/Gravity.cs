using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
    void Update()
    {
        var k = 400000.0f;
        var r = transform.position.magnitude;

        GetComponent<Rigidbody>().AddForce(-transform.position.normalized * k * Mathf.Pow(r, -2), ForceMode.Acceleration);
    }
}
