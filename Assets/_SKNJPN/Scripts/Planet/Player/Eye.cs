using UnityEngine;

public class Eye : MonoBehaviour
{
    [SerializeField] float sensitivity = 10f;
    [SerializeField] Transform player;

    void Update()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        {
            var p1 = player.position + player.forward - player.position.normalized * Vector3.Dot(player.position.normalized, player.forward);
            var p2 = player.position + player.position.normalized;
            player.LookAt(p1, p2);

            player.localRotation *= Quaternion.AngleAxis(sensitivity * Input.GetAxis("Mouse X"), Vector3.up);
        }

        {
            transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x - sensitivity * Input.GetAxis("Mouse Y"), 0, 0);
        }
    }
}
