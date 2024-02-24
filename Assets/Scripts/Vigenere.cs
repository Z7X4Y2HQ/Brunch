using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vigenere : MonoBehaviour
{
    public TMP_InputField playerInput;
    public GameObject tryYourLuck;
    public GameObject moveForward;
    public TMP_Text compliment;
    public TMP_Text encryptedMessageText;
    public TMP_Text keyText;
    private string[] decryptedMessages = { "BRAILLECIPHER", "ANIMEARENOTCARTOON", "SQUIRRELSINMYPANTS", "ATRUEARTISTISANUGLYMAN", "GIVEUPONYOURDREAMSANDDIE", "IWILLMAKEYOUANOFFERYOUCANTREFUSE", "KEEPYOURFRIENDSCLOSEBUTYOURENEMIESCLOSER" };
    private string[] key = { "ABCDEFGHIJKLM", "MONKEYEATSBANANA", "CARTOON", "MONALISA", "LEVI", "GODFATHER", "WORLDWAR" };
    private string[] encryptedMessage = { "BSCLPQKJQYRPD", "MBVWIYVEGGUCNRGOAB", "UQLBFFRNSZGAMCCNKL", "MHEUPIJTUGGIDIFUSZLMLV", "RMQMFTJVJSPZOVZIXWVVOHDM", "OKLQLFHOVECXFNHMJVXMRZCTUXIKTXXE", "GSVABKUIBFZPQZSTHCJPEQTPKIIPQAMZAGTWROEI" };
    public Timer timer;

    private void Update()
    {
        encryptedMessageText.text = "Encrypted Message : " + encryptedMessage[Brunch.day - 1];
        keyText.text = "Key : " + key[Brunch.day - 1];

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
        if (input.ToLower() == decryptedMessages[Brunch.day - 1].ToLower())
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
