using UnityEngine;

public class PlanetObject : MonoBehaviour
{
    public Planet planet;
    public Area area;
    public Creature creature;
    public Plant plant;
    public Animal animal;
    public Clematis clematis;

    void Start()
    {
        planet = GetComponentInParent<Planet>();

        clematis = GetComponent<Clematis>();
        creature = GetComponent<Creature>();
        plant = GetComponent<Plant>();
        animal = GetComponent<Animal>();

        area = planet.GetArea(transform.position);

        if (area != null) { area.AddPlanetObject(this); }
    }

    void OnDestroy()
    {
        if (area != null) { area.RemovePlanetObject(this); }
    }
}