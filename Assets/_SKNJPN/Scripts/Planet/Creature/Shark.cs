using UnityEngine;

public class Shark : Creature
{
    float angle;

    public override void ManagedUpdate()
    {
        angle += 1f;
        transform.rotation = Quaternion.AngleAxis(angle, transform.position.normalized) * Quaternion.FromToRotation(Vector3.up, transform.position.normalized);

        transform.position += 0.1f * transform.forward;

        transform.position = transform.position.normalized * planet.WaterHeight;
    }
}
