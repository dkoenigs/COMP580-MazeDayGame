using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class playerController : MonoBehaviour
{
    public TextMeshProUGUI turnInfo;
    public TextMeshProUGUI score;

    public float wheelInput = 0;
    public float pedalInput = 0;
    public int convertInput = 0;
    public int instructionToggle;
    public int pedalToggle;
    public int scoreCounter = 0;
    //0 = sharp left
    //1 = gradual left
    //2 = center
    //3 = gradual right
    //4 = sharp right
    //5 = slow down
    //6 = speed up

    public AudioSource audioSource;
    public AudioClip sharpLeft;
    public AudioClip slightLeft;
    public AudioClip slightRight;
    public AudioClip sharpRight;
    public AudioClip straight;
    public AudioClip slowDown;
    public AudioClip speedUp;
    public AudioClip goodTurn;
    public AudioClip badTurn;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NewMessage", 2.0f, 4.0f);
        InvokeRepeating("CheckInput", 5.0f, 4.0f);
    }

    // Update is called once per frame
    void Update()
    {

        wheelInput = Input.GetAxis("Horizontal");
        pedalInput = Input.GetAxis("Vertical");


        // Get wheel input, this will convert the input to a number from 0-6
        convertInput = ConvertInput(wheelInput);


        transform.Translate(0, 0, pedalInput);
        transform.Rotate(0.0f, wheelInput, 0.0f);
    }

    void NewMessage()
    {
       Debug.Log("OK working.");

       instructionToggle = Random.Range(0, 6);

        if (instructionToggle == 0)
        { //Sharp Left
            Debug.Log("Co-driver: \"Sharp Left\"");
            turnInfo.text = "Sharp Left";
            audioSource.clip = sharpLeft;
            audioSource.Play();
           
        }
        else if (instructionToggle == 1)
        { //Gradual Left
            Debug.Log("Co-driver: \"Gradual Left\"");
            turnInfo.text = "Slight Left";
            audioSource.clip = slightLeft;
            audioSource.Play();

        }
        else if (instructionToggle == 2)
        { //Drive straight/center
            Debug.Log("Co-driver: \"Drive Straight\"");
            turnInfo.text = "Drive Straight";
            audioSource.clip = straight;
            audioSource.Play();
        }
        else if (instructionToggle == 3)
        { //Gradual Right
            Debug.Log("Co-driver: \"Gradual Right\"");
            turnInfo.text = "Slight Right";
            audioSource.clip = slightRight;
            audioSource.Play();

        }
        else if (instructionToggle == 4)
        { //Sharp Right
            Debug.Log("Co-driver: \"Sharp Right\"");
            turnInfo.text = "Sharp Right";
            audioSource.clip = sharpRight;
            audioSource.Play();

        }
        else if (instructionToggle == 5)
        { //Slow Down
            Debug.Log("Co-driver: \"Slow Down\"");
            audioSource.clip = slowDown;
            audioSource.Play();
        }
        else if (instructionToggle == 6)
        { //Speed Up
            Debug.Log("Co-driver: \"Speed Up\"");
            audioSource.clip = speedUp;
            audioSource.Play();
        }

    }

   void CheckInput()
    {
        Debug.Log("checking...");
        if (instructionToggle > 4)
        {
            if (instructionToggle == 5)
            {
                if (pedalInput < 0)
                {
                    audioSource.clip = goodTurn;
                    audioSource.Play();
                    scoreCounter += 1000;
                    Debug.Log("Correct");
                }
                else
                {
                    audioSource.clip = badTurn;
                    audioSource.Play();
                    Debug.Log("Wrong");
                    GameOver();
                }
            }
            else
            {
                if (pedalInput < 0)
                {
                    audioSource.clip = goodTurn;
                    audioSource.Play();
                    scoreCounter += 1000;
                    Debug.Log("Correct");
                }
                else
                {
                    audioSource.clip = badTurn;
                    audioSource.Play();
                    Debug.Log("Wrong");
                    GameOver();
                }
            }

        }
        else
        {
            if (convertInput == instructionToggle)
            {
                audioSource.clip = goodTurn;
                audioSource.Play();
                scoreCounter += 1000;
                score.text = scoreCounter.ToString();
                Debug.Log("Correct");
            }
            else
            {
                audioSource.clip = badTurn;
                audioSource.Play();
                Debug.Log("Wrong");
                GameOver();
            }
        }

    }

    void GameOver()
    {

        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }


    static int ConvertInput(float wheelInput)
    {
        int convertOutput = 0;

        if (wheelInput >= -1 && wheelInput <= -0.7)
        {
            convertOutput = 0;
        }
        else if (wheelInput >= -0.7 && wheelInput <= -0.15)
        {
            convertOutput = 1;
        }
        else if (wheelInput >= -0.15 && wheelInput <= 0.15)
        {
            convertOutput = 2;
        }
        else if (wheelInput >= 0.15 && wheelInput <= 0.7)
        {
            convertOutput = 3;
        }
        else if (wheelInput >= 0.7 && wheelInput <= 1)
        {
            convertOutput = 4;
        }

        return convertOutput;
    }

}
