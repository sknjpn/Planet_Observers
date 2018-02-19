using UnityEngine;

[RequireComponent(typeof(PlanetObject))]
public class Creature : MonoBehaviour
{
    Planet planet;
    Vector3 size;
    float energy;

    float Height { get { return transform.position.magnitude; } }

    void Start()
    {
        size = (Vector3.one + Random.Range(0.5f, 2.0f) * transform.localScale) / 2.0f;
        transform.localScale = Vector3.zero;

        planet = GetComponentInParent<Planet>();

        transform.position = transform.position.normalized * planet.GetHeight(transform.position);
        transform.LookAt(transform.position + planet.GetNormal(transform.position));

        if (Height < planet.WaterHeight) { Destroy(gameObject); }
    }

    void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, size, 0.1f);

        energy += 0.05f;

        if (energy > 1.0f)
        {
            energy = 0f;
            var c = MakeChild();
            var distance = 16.0f;

            c.transform.position += new Vector3(Random.Range(-distance, distance), Random.Range(-distance, distance), Random.Range(-distance, distance));
        }

        if (Random.Range(0, 100) < 10)
        {
            var length = 6.0f;
            var positionMin = planet.GetArea(transform.position - Vector3.one * length).position;
            var positionMax = planet.GetArea(transform.position + Vector3.one * length).position;

            for (var x = positionMin.x; x <= positionMax.x; x++)
            {
                for (var y = positionMin.y; y <= positionMax.y; y++)
                {
                    for (var z = positionMin.z; z <= positionMax.z; z++)
                    {
                        var area = planet.AreaGrid[x, y, z];

                        foreach (var po in area.planetObjects)
                        {
                            var c = po.creature;

                            if (c != null && c != this)
                            {
                                c.energy -= 0.25f * Mathf.Max(0.0f, length - Vector3.Distance(c.transform.position, transform.position));
                            }
                        }
                    }
                }
            }
        }

        if (energy < 0) { Destroy(gameObject); }
    }


    Creature MakeChild()
    {
        var c = Instantiate(this, transform.parent);

        c.name = name;

        return c;
    }
}