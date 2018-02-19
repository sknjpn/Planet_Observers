using UnityEngine;

public class Eye : MonoBehaviour
{
    [SerializeField] float sensitivity = 10f;
    [SerializeField] Transform player;
    Vector2 angle;

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        angle.x += sensitivity * Input.GetAxis("Mouse X");
        angle.y -= sensitivity * Input.GetAxis("Mouse Y");

        angle.y = Mathf.Clamp(angle.y, -80, 80);

        transform.localRotation = Quaternion.Euler(angle.y, 0, 0);

        player.rotation = Quaternion.AngleAxis(angle.x, transform.position.normalized) * Quaternion.FromToRotation(Vector3.up, transform.position.normalized);
    }
}
