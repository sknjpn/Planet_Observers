public class Creature : PlanetObject
{
    public float energy;
    
    public Creature MakeChild()
    {
        var c = Instantiate(this, transform.parent);

        c.age = 0;
        c.energy = 0;
        c.name = name;

        return c;
    }
}
