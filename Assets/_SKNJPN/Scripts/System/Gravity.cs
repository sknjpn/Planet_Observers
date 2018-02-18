using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Gravity : MonoBehaviour
{
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        var r = transform.position.magnitude;
        var k = 100.0f;

        rigidbody.AddForce(-transform.position.normalized * k * Mathf.Pow(r, -2), ForceMode.Acceleration);
    }
}
