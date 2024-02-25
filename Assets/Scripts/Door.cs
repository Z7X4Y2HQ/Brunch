using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator animator;
    private Animator MarketPlaceDoorAnimator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        MarketPlaceDoorAnimator = GameObject.Find("MarketPlaceDoor").GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "Door")
        {
            animator.Play("DoorOpen");
        }
        else
        {
            MarketPlaceDoorAnimator.Play("Door2Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (gameObject.name == "Door")
        {
            animator.Play("DoorClose");
        }
        else
        {
            MarketPlaceDoorAnimator.Play("Door2Close");
        }
    }
}
