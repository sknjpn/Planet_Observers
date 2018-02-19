using UnityEngine;
using System.Collections;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Camera playerCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            mainCamera.gameObject.SetActive(!mainCamera.gameObject.activeSelf);
            playerCamera.gameObject.SetActive(!mainCamera.gameObject.activeSelf);

            if(mainCamera.gameObject.activeSelf)
            {
                mainCamera.GetComponent<MainCamera>().TargetPosition = playerCamera.transform.position;
            }
        }
    }
}
