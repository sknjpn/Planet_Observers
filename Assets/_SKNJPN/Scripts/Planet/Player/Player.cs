using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] Foot foot;
    new Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        if (foot.OnGround || transform.position.magnitude <= GetComponentInParent<Planet>().WaterHeight)
        {
            rigidbody.velocity = transform.up * Vector3.Dot(rigidbody.velocity, transform.up);

            if (Input.GetKey(KeyCode.Space)) { rigidbody.velocity = 20f * transform.up; }

            var speed = Input.GetKey(KeyCode.LeftShift) ? 10f : 5f;

            if (Input.GetKey(KeyCode.W)) { rigidbody.AddForce(speed * transform.forward, ForceMode.VelocityChange); }
            if (Input.GetKey(KeyCode.A)) { rigidbody.AddForce(speed * -transform.right, ForceMode.VelocityChange); }
            if (Input.GetKey(KeyCode.S)) { rigidbody.AddForce(speed * -transform.forward, ForceMode.VelocityChange); }
            if (Input.GetKey(KeyCode.D)) { rigidbody.AddForce(speed * transform.right, ForceMode.VelocityChange); }
        }
        if(transform.position.magnitude <= GetComponentInParent<Planet>().WaterHeight)
        {
            transform.position = transform.position.normalized * GetComponentInParent<Planet>().WaterHeight;
            rigidbody.velocity /= 1.05f;
        }
    }
}