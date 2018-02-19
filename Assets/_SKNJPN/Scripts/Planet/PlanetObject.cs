using UnityEngine;

public class PlanetObject : MonoBehaviour
{
    public Area area;
    public Creature creature;

    void Start()
    {
        creature = GetComponent<Creature>();

        area = GetComponentInParent<Planet>().GetArea(transform.position);

        if (area != null) { area.AddPlanetObject(this); }
    }

    void OnDestroy()
    {
        if (area != null) { area.RemovePlanetObject(this); }
    }
}