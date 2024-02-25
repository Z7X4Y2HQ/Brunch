using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class IdentifyWord : DisplayWord
{
    private string[] wordsToGuessList = {  "plank", "crumb", "blush", "flint", "brine", "quirk", "glyph", "chasm", "bravo", "prism",
    "gusto", "blend", "knurl", "fluke", "hazel", "spire", "plume", "slant", "torch", "snare",
    "glint", "nymph", "tinge", "frown", "quail", "surge", "snarl", "brawn", "crust",
    "glaze", "wince", "scowl", "zebra", "smirk", "truce", "scamp", "plaid", "flung",
    "yacht", "blaze", "tryst", "venom", "flora", "cruxy", "pluck", "fjord", "grime", "flail",
    "joust", "gloat", "knave", "prong", "realm", "clasp", "fable", "mirth", "query",
    "plumb", "briny", "fluff", "giddy", "spark", "wring", "squash", "hunch", "skulk", "hovel",
    "vexed", "thump", "knoll", "smock", "wrist", "plump", "braid", "chive", "glade",
    "quash", "clime", "swirl", "chafe", "flume", "glide", "oxide", "grove", "blimp", "alias",
    "frail", "mango", "lunge", "glint", "abode", "scope", "prism", "tramp", "stoic", "drips" };
    private string actualWord = "";
    public TMP_Text WinLoseStatusText;
    public TMP_Text triesText;
    public TMP_Text wordText;
    public GameObject moveForward;
    public static string gameState = "";
    private int currentChar = 0;
    public static int tries = 0;
    private int temp;
    public Timer timer;
    System.Random Random = new System.Random();


    private void Start()
    {
        SetWord();
    }

    private void Update()
    {
        GuessWord();
        Debug.Log("game state " + gameState);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Word to Guess: " + actualWord);
        }
    }
    public void GuessWord()
    {
        if (wordComplete)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                foreach (TMP_Text guessCharacter in playerGuess)
                {
                    if (guessCharacter.text == actualWord[currentChar].ToString().ToUpper())
                    {
                        ColorSet(Color.green);
                    }
                    else if (guessCharacter.text != actualWord[currentChar].ToString().ToUpper())
                    {
                        for (int i = 0; i <= 4; i++)
                        {
                            if (guessCharacter.text == actualWord[i].ToString().ToUpper() && playerGuess[i].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color != Color.green)
                            {
                                ColorSet(Color.yellow);
                                break;
                            }
                            else
                            {
                                ColorSet(Color.red);
                            }
                        }
                    }
                    currentChar++;
                }

                foreach (TMP_Text Underline in playerGuess)
                {
                    if (Underline.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color == Color.green)
                    {
                        WinLoseStatusText.text = "DAMNN!";
                        gameState = "win";
                        moveForward.SetActive(true);
                    }
                    else
                    {
                        if (tries == 5)
                        {
                            WinLoseStatusText.text = "WORTHLESS!";
                            wordText.text = "THE WORD WAS '" + actualWord.ToUpper() + "'";
                            triesText.text = "TRIES: 6";
                            gameState = "lose";
                            moveForward.SetActive(true);
                        }
                        else
                        {
                            TriedWord();
                            ClearWord();
                            tries++;
                            triesText.text = "TRIES: " + tries;
                            WinLoseStatusText.text = "GUESS THE COMPLETE WORD";
                            gameState = "";
                            moveForward.SetActive(false);
                            currentChar = 0;
                            return;
                        }
                    }
                }
                currentChar = 0;
            }
        }
        else
        {
            WinLoseStatusText.text = "GUESS THE COMPLETE WORD";
        }
        if (timer.time == 0)
        {
            WinLoseStatusText.text = "WORTHLESS!";
            wordText.text = "THE WORD WAS '" + actualWord.ToUpper() + "'";
            triesText.text = "TRIES: " + tries.ToString();
            moveForward.SetActive(true);
            gameState = "lose";
        }
    }
    private void ColorSet(Color color)
    {
        playerGuess[currentChar].transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = color;
    }

    private void SetWord()
    {
        int length = wordsToGuessList.Length;
        actualWord = wordsToGuessList[Random.Next(0, length)];
    }

    // public void Retry()
    // {
    //     ClearWord();

    //     currentChar = 0;
    //     wordText.text = "";
    //     tries = 0;
    //     triesText.text = "TRIES: 0";
    //     triedList.text = "";
    //     gameState = "";
    //     foreach (TMP_Text Underline in playerGuess)
    //     {
    //         Underline.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().color = Color.white;
    //     }
    //     triedList.text = "";
    //     RetryButton.SetActive(false);
    //     SetWord();
    // }
}
