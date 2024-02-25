using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class Bed : MonoBehaviour
{
    public GameObject InteractE;
    public GameObject workRoom;
    private bool inBedRange;
    public PlayableDirector timeline;


    private void OnTriggerEnter(Collider other)
    {
        InteractE.SetActive(true);
        inBedRange = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Brunch.work == 3 && inBedRange)
        {
            timeline.Play();
            Brunch.day += 1;
            Brunch.work = 0;
            Brunch.puzzle = 0;
            workRoom.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractE.SetActive(false);
        inBedRange = false;
    }
}
