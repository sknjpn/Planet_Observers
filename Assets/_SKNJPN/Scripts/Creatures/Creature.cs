using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    Planet planet;
    float energy;
    Vector3 size;

    float Height { get { return transform.position.magnitude; } }

    void Start()
    {
        size = (Vector3.one * 0.25f + Random.Range(0.5f, 2.0f) * transform.localScale) / 2.0f;
        transform.localScale = Vector3.zero;

        planet = GetComponentInParent<Planet>();

        transform.position = transform.position.normalized * planet.GetHeight(transform.position);
        transform.LookAt(transform.position + planet.GetNormal(transform.position));

        planet.AddCreature(this);

        if (Height < planet.WaterHeight) { Destroy(gameObject); }
    }

    void OnDestroy()
    {
        planet.RemoveCreature(this);
    }

    void FixedUpdate()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, size, 0.1f);

        energy += 0.05f;

        if (energy > 1.0f)
        {
            energy = 0f;
            var c = MakeChild();
            var distance = 2.0f;

            c.transform.position += new Vector3(Random.Range(-distance, distance), Random.Range(-distance, distance), Random.Range(-distance, distance));
        }

        var p = Vector3Int.FloorToInt(transform.position) + Vector3Int.one * (planet.ArrayLength / 2);

        for (var x = -1; x <= 1; x++)
        {
            for (var y = -1; y <= 1; y++)
            {
                for (var z = -1; z <= 1; z++)
                {
                    foreach (var c in planet.Creatures[p.x + x, p.y + y, p.z + z])
                    {
                        if (c != this)
                        {
                            c.energy -= 0.025f * Mathf.Max(0.0f, 1.0f - Vector3.Distance(c.transform.position, transform.position));
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
