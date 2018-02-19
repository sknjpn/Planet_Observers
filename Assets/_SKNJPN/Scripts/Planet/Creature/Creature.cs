using UnityEngine;

[RequireComponent(typeof(PlanetObject))]
public class Creature : MonoBehaviour
{
    protected Vector3 size;
    protected float energy;

    public float Height { get { return transform.position.magnitude; } }
    public float Energy { get { return energy; } set { energy = value; } }

    protected Creature MakeChild()
    {
        var c = Instantiate(this, transform.parent);

        c.name = name;

        return c;
    }
}