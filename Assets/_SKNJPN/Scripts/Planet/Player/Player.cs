using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : PlanetObject
{
    [SerializeField] Foot foot;
    new Rigidbody rigidbody;

    void Start()
    {
        transform.position = Vector3.up * planet.GetHeight(Vector3.up);

        rigidbody = GetComponent<Rigidbody>();

        rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public override void ManagedUpdate()
    {
        if (foot.OnGround || transform.position.magnitude <= planet.WaterHeight)
        {
            rigidbody.velocity = transform.up * Vector3.Dot(rigidbody.velocity, transform.up);

            if (Input.GetKey(KeyCode.Space)) { rigidbody.velocity = 20f * transform.up; }

            var speed = Input.GetKey(KeyCode.LeftShift) ? 10f : 5f;

            if (Input.GetKey(KeyCode.W)) { rigidbody.AddForce(speed * transform.forward, ForceMode.VelocityChange); }
            if (Input.GetKey(KeyCode.A)) { rigidbody.AddForce(speed * -transform.right, ForceMode.VelocityChange); }
            if (Input.GetKey(KeyCode.S)) { rigidbody.AddForce(speed * -transform.forward, ForceMode.VelocityChange); }
            if (Input.GetKey(KeyCode.D)) { rigidbody.AddForce(speed * transform.right, ForceMode.VelocityChange); }
        }

        if(transform.position.magnitude <= planet.WaterHeight)
        {
            transform.position = transform.position.normalized * planet.WaterHeight;
            rigidbody.velocity /= 1.05f;
        }
    }
}
