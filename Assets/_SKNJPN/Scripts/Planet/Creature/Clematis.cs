using UnityEngine;

public sealed class Clematis : Plant
{
    PlanetObject planetObject;

    void Start()
    {
        planetObject = GetComponent<PlanetObject>();

        transform.position = transform.position.normalized * planetObject.planet.GetHeight(transform.position);
        transform.LookAt(transform.position + planetObject.planet.GetNormal(transform.position));

        if (Height < planetObject.planet.WaterHeight) { Destroy(gameObject); }
        energy = 0.0f;
    }

    public override void UpdatePlant()
    {
        age++;
        energy += 0.5f;

        if (energy > 1.0f)
        {
            energy -= 1.0f;

            var c = MakeChild();
            var distance = 24.0f;

            c.transform.position += distance * new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }

        {
            var length = 12.0f;

            planetObject.ForEachToNear(length, po =>
            {
                if (po.plant != null && po.plant != this)
                {
                    energy -= 0.5f * Mathf.Max(0, 1.0f - (PlanetObject.Distance(planetObject, po) / length));
                }
            });
        }

        if (energy < 0 || age >= 5) { Destroy(gameObject); }
    }
}
