using UnityEngine;

public class Foot : MonoBehaviour
{
    bool onGround;

    public bool OnGround { get { return onGround; } }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Planet>()) { onGround = true; }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Planet>()) { onGround = false; }
    }
}
