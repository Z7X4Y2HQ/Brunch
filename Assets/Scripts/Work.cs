using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Work : MonoBehaviour
{
    public GameObject InteractE;
    public GameObject pill;
    public bool inRange;
    public PlayableDirector timeline;
    private void OnTriggerEnter(Collider other)
    {
        InteractE.SetActive(true);
        inRange = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Brunch.puzzle != Brunch.work && IdentifyWord.gameState != "" && inRange)
        {
            timeline.Play();
            StartCoroutine(setWork());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        InteractE.SetActive(true);
        inRange = false;
    }

    IEnumerator setWork()
    {
        yield return new WaitForSeconds(2f);
        Brunch.work += 1;
        pill.SetActive(true);
        IdentifyWord.gameState = "";
        Currency.money += 30;
    }
}
