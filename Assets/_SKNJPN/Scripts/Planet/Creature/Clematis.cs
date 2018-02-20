using UnityEngine;

public sealed class Clematis : Creature
{
    void Start()
    {
        transform.position = transform.position.normalized * planet.GetHeight(transform.position);
        transform.LookAt(transform.position + planet.GetNormal(transform.position));

        if (Height < planet.WaterHeight) { Destroy(gameObject); }
    }

    public override void ManagedUpdate()
    {
        if (age % 5 == 4 && !Any(4.0f, po => po.clematis != null && po.clematis != this && Distance(this, po) < 4.0f))
        {
            var c = MakeChild();
            var distance = 4.0f;

            c.transform.position += Random.Range(distance, 2f * distance) * new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;

        }

        if (age % 10 == 9) { Destroy(gameObject); }
    }
}
