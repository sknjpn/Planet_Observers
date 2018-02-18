using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    Rigidbody rigidbody;
    [SerializeField] Foot foot;
    [SerializeField] float sx = 10f;
    [SerializeField] float angle = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

    }

    void FixedUpdate()
    {
        if (foot.OnGround)
        {
            rigidbody.velocity = Vector3.zero;

            if (Input.GetKey(KeyCode.Space)) { rigidbody.AddForce(2.0f * transform.position.normalized, ForceMode.VelocityChange); }

            var speed = Input.GetKey(KeyCode.LeftShift) ? 50f : 25f;

            if (Input.GetKey(KeyCode.W)) { rigidbody.AddForce(speed * transform.forward, ForceMode.Acceleration); }
            if (Input.GetKey(KeyCode.A)) { rigidbody.AddForce(speed * -transform.right, ForceMode.Acceleration); }
            if (Input.GetKey(KeyCode.S)) { rigidbody.AddForce(speed * -transform.forward, ForceMode.Acceleration); }
            if (Input.GetKey(KeyCode.D)) { rigidbody.AddForce(speed * transform.right, ForceMode.Acceleration); }
        }

        if (Input.GetKey(KeyCode.RightShift))
        {
            var speed = 5;

            if (Input.GetKey(KeyCode.KeypadEnter)) { rigidbody.AddForce(-speed * transform.up, ForceMode.Acceleration); }
            if (Input.GetKey(KeyCode.Space)) { rigidbody.AddForce(speed * transform.up, ForceMode.Acceleration); }
            if (Input.GetKey(KeyCode.W)) { rigidbody.AddForce(speed * transform.forward, ForceMode.Acceleration); }
            if (Input.GetKey(KeyCode.A)) { rigidbody.AddForce(speed * -transform.right, ForceMode.Acceleration); }
            if (Input.GetKey(KeyCode.S)) { rigidbody.AddForce(speed * -transform.forward, ForceMode.Acceleration); }
            if (Input.GetKey(KeyCode.D)) { rigidbody.AddForce(speed * transform.right, ForceMode.Acceleration); }
        }

    }

    void Update()
    {
        angle += sx * Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.AngleAxis(angle, transform.position.normalized) * Quaternion.FromToRotation(Vector3.up, transform.position.normalized);
    }
}
