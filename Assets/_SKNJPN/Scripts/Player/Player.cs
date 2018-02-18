using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] Foot foot;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;

    }

    void FixedUpdate()
    {
        if (foot.OnGround)
        {
            rigidbody.velocity = transform.up * Vector3.Dot(rigidbody.velocity, transform.up);

            if (Input.GetKey(KeyCode.Space)) { rigidbody.velocity = 2.5f * transform.up; }

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
}
