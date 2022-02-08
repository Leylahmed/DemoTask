using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject firstPersonController;
    [SerializeField] private GameObject thirdPersonController;
    [SerializeField] private GameObject thirdPersonCam;

    private bool isFirstPerson;
    //private Transform currentTransform;
    //private Rotation currentRotation;

    void Start()
    {
        isFirstPerson = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(SwitchCam());
        }
    }

    private IEnumerator SwitchCam()
    {
        yield return new WaitForSeconds(0.001f);

        if (isFirstPerson)
        {
            firstPersonController.SetActive(false);
            thirdPersonController.SetActive(true);
            thirdPersonCam.SetActive(true);
            isFirstPerson = false;
        }

        else if (!isFirstPerson)
        {
            thirdPersonCam.SetActive(false);
            thirdPersonController.SetActive(false);
            firstPersonController.SetActive(true);
            isFirstPerson = true;
        }
    }
}
