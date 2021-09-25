using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuessNumber : MonoBehaviour
{
    private int maximum = 1000, minimum = 0, guessingNumber = 0;
    private bool smaller = false, bigger = false, currect = false;
    private Text godSays;

    void Start()
    {
        godSays = GameObject.Find("GodSays").GetComponent<Text>();

        Debug.Log($"請先想好一個介於 {minimum} ~ {maximum} 的數字。");
        godSays.text = $"請先想好一個介於 {minimum} ~ {maximum} 的數字。";
        this.guessNumber();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currect)
            {
                this.currectNumber();
            }
            else if (bigger)
            {
                this.onNumberTooSmall();
                this.guessNumber();
            }
            else if (smaller)
            {
                this.onNumberTooBig();
                this.guessNumber();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"TriggerEnter2D {collider.name}");
        if (collider.name == "Smaller")
            smaller = true;
        else if (collider.name == "Bigger")
            bigger = true;
        else if (collider.name == "Currect")
            currect = true;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log($"TriggerExit2D {collider.name}");
        if (collider.name == "Smaller")
            smaller = false;
        else if (collider.name == "Bigger")
            bigger = false;
        else if (collider.name == "Currect")
            currect = false;
    }

    void onNumberTooBig()
    {
        maximum = guessingNumber;
    }

    void onNumberTooSmall()
    {
        minimum = guessingNumber;
    }

    void guessNumber()
    {
        if (maximum == minimum)
        {
            godSays.text = "神懷疑你在玩他。";
            Debug.Log("神懷疑你在玩他。");
            this.quit(1);
            return;
        }

        this.generateRandomNumber();
        godSays.text = $"你想的數字是 {guessingNumber} 嗎？";
        Debug.Log($"你想的數字是 {guessingNumber} 嗎？");
    }

    void generateRandomNumber()
    {
        int randomNumber = (int)Math.Round(UnityEngine.Random.Range((float)minimum, (float)maximum));

        if (guessingNumber == randomNumber)
            generateRandomNumber();
        else
            guessingNumber = randomNumber;
    }

    void currectNumber()
    {
        godSays.text = $"原來你想的數字是 {guessingNumber}!";
        Debug.Log($"原來你想的數字是 {guessingNumber}!");
        this.quit(0);
    }

    void quit(int sceneAmount = 0)
    {
        SceneController.nextScene(sceneAmount);
    }
}
