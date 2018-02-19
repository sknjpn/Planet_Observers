using UnityEngine;

public static class Extensions
{
    public static bool HasComponent<T>(this GameObject self) where T : Component
    {
        return self.GetComponent<T>() != null;
    }
    public static bool HasComponent<T>(this Component self) where T : Component
    {
        return self.GetComponent<T>() != null;
    }
}
