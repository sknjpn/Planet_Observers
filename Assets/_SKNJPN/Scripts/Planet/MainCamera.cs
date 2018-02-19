using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] Planet planet;
    Vector3 targetPosition;
    float length;
    float targetLength;

    public Vector3 TargetPosition { set { targetPosition = value; } }

    void Start()
    {
        length = transform.position.magnitude;
        targetLength = length;
        targetPosition = transform.position;
    }

    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;

            Physics.Raycast(GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit);
            targetPosition = hit.point;
        }

        targetLength *= (1.0f - Input.GetAxis("Mouse ScrollWheel"));

        targetLength = Mathf.Clamp(targetLength, planet.GetHeight(transform.position) + 4f, planet.MaximumHeight * 2f);

        length = Mathf.Lerp(length, targetLength, 0.1f);

        transform.position = Vector3.Lerp(transform.position, targetPosition.normalized * length, 0.1f).normalized * length;

        transform.LookAt(Vector3.zero);
    }
}
