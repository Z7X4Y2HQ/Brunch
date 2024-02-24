using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HandleScenes : MonoBehaviour
{
    public Transform roadSpawnPoint;
    public Transform houseSpawnPoint;
    public Transform MarketOutsideSpawnPonit;
    public Transform MarketInsideSpawnPonit;
    private bool inRange;
    public Animator levelLoader;
    public TMP_Text InteractE;
    GameObject player;

    private void Start()
    {
        levelLoader.Play("FadeOutBlack");
    }
    private void OnTriggerEnter(Collider other)
    {
        inRange = true;
        InteractE.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            player = GameObject.Find("Player");
            if (gameObject.name == "Hosue Door Outside")
            {
                StartCoroutine(setPosition(houseSpawnPoint));
            }
            else if (gameObject.name == "Hosue Door Inside")
            {
                StartCoroutine(setPosition(roadSpawnPoint));
            }
            Debug.Log(gameObject.name);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        InteractE.gameObject.SetActive(false);
    }

    private IEnumerator setPosition(Transform position)
    {
        levelLoader.Play("FadeInBlack");
        player.GetComponent<CharacterController>().enabled = false;
        yield return new WaitForSeconds(2f);
        player.transform.position = position.position;
        player.GetComponent<CharacterController>().enabled = true;
        yield return new WaitForSeconds(0.7f);
        levelLoader.Play("FadeOutBlack");
    }
}
