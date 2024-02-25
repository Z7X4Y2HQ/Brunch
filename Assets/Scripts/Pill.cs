using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pill : MonoBehaviour
{
    public GameObject InteractE;
    public GameObject workPlace;
    public Animator playerAnimator;
    private void OnTriggerEnter(Collider other)
    {
        InteractE.SetActive(true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            playerAnimator.SetBool("isDrink", true);
            gameObject.SetActive(false);
            workPlace.SetActive(false);
            InteractE.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractE.SetActive(false);
    }
}
