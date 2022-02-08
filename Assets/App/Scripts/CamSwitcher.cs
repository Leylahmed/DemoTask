using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject firstPersonController;
    [SerializeField] private GameObject thirdPersonController;
    [SerializeField] private GameObject thirdPersonCam;
    [SerializeField] private Transform firstPersonTransform;
    [SerializeField] private Transform thirdPersonTransform;

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
            currentPosition = firstPersonTransform.position;
            currentRotation = firstPersonTransform.rotation;
            firstPersonController.SetActive(false);

            thirdPersonController.SetActive(true);
            thirdPersonTransform.position = currentPosition;
            thirdPersonTransform.rotation = currentRotation;

            thirdPersonCam.SetActive(true);

            isFirstPerson = false;
        }

        else if (!isFirstPerson)
        {
            currentPosition = thirdPersonTransform.position;
            currentRotation = thirdPersonTransform.rotation;
            thirdPersonCam.SetActive(false);
            thirdPersonController.SetActive(false);

            firstPersonController.SetActive(true);
            firstPersonTransform.position = currentPosition;
            firstPersonTransform.rotation = currentRotation;

            isFirstPerson = true;
        }
    }
}
