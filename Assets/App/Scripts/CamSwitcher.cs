using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSwitcher : MonoBehaviour
{
    [SerializeField] private GameObject firstPersonCharacter;
    [SerializeField] private GameObject thirdPersonCharacter;

    private bool isFirstPerson;

    void Start()
    {
        isFirstPerson = true;
    }

    void Update()
    {
        SwitchCam();
    }

    private void SwitchCam()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (isFirstPerson)
            {
                firstPersonCharacter.SetActive(false);
                thirdPersonCharacter.SetActive(true);
                isFirstPerson = false;
            }

            else if (!isFirstPerson)
            {
                thirdPersonCharacter.SetActive(false);
                firstPersonCharacter.SetActive(true);
                isFirstPerson = true;
            }
        }
    }
}
