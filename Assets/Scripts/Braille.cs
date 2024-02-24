using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class Braille : MonoBehaviour
{
    public TMP_InputField playerInput;
    public GameObject tryYourLuck;
    public GameObject moveForward;
    public TMP_Text compliment;
    public GameObject[] braille;
    private string[] sentences = { "old tech sucks", "dont skip breakfast kids", "your package will be delivered today", "a quick brown fox jumps over the lazy dog", "with great power comes great responsibility", "all we had to do was follow the damn train cj", "two plus two is four minus one thats three quick maths" };
    public Timer timer;
    private void Update()
    {
        braille[Brunch.day - 1].SetActive(true);

        if (timer.time == 0)
        {
            tryYourLuck.SetActive(false);
            moveForward.SetActive(true);
            compliment.text = "WORTHLESS!!";
            IdentifyWord.gameState = "lose";
        }
    }

    public void ValidateInput()
    {
        string input = playerInput.text;
        if (input.ToLower() == sentences[Brunch.day - 1].ToLower())
        {
            tryYourLuck.SetActive(false);
            moveForward.SetActive(true);
            compliment.text = "Cool! You got it.";
            IdentifyWord.gameState = "win";
        }
        else
        {
            StartCoroutine(complimentTime());
        }

    }
    private IEnumerator complimentTime()
    {
        compliment.text = "Nahhhh!";
        yield return new WaitForSeconds(2f);
        compliment.text = "";
    }
}

