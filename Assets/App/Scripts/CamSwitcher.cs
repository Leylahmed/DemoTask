using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject firstPersonController;
    [SerializeField] private GameObject thirdPersonController;
    [SerializeField] private GameObject thirdPersonCam;

    private bool isFirstPerson;
    private Vector3 currentPosition;
    private Quaternion currentRotation;

    void Start()
    {
        isFirstPerson = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Switch();
        }
    }

    private void Switch()
    {
        if (isFirstPerson)
        {
            currentPosition = firstPersonController.transform.position;
            currentRotation = firstPersonController.transform.rotation;
            firstPersonController.SetActive(false);

            thirdPersonController.SetActive(true);
            thirdPersonController.transform.position = currentPosition;
            thirdPersonController.transform.rotation = currentRotation;

            thirdPersonCam.SetActive(true);
            //thirdPersonCam.transform.position = new Vector3(thirdPersonController.transform.position.x, thirdPersonController.transform.position.y, thirdPersonController.transform.position.z - 3.5f);
            //thirdPersonCam.transform.rotation = currentRotation;

            isFirstPerson = false;
        }

        else if (!isFirstPerson)
        {
            currentPosition = thirdPersonController.transform.position;
            currentRotation = thirdPersonController.transform.rotation;
            thirdPersonCam.SetActive(false);
            thirdPersonController.SetActive(false);

            firstPersonController.SetActive(true);
            firstPersonController.transform.position = currentPosition + new Vector3(0, 0.01f, 0);
            firstPersonController.transform.rotation = currentRotation;

            isFirstPerson = true;
        }
    }
}
