using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Keypad3 : MonoBehaviour
{
    GameObject Orange;
    GameObject Red;
    GameObject hint1;
    GameObject hint2;
    public GameObject objectToEnable;
    public GameObject Door2;
    GameObject DoorOpenS;

    [Header("Keypad Settings")]
    public string curPassword = "9724";
    public string input;
    public Text displayText;
    public AudioSource audioData;

    private bool keypadScreen;
    private bool IsPlayerEnter;
    private float btnClicked = 0;
    private float numOfGuesses;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.Orange = GameObject.Find("Orange");
        this.Red = GameObject.Find("Red");
        this.hint1 = GameObject.Find("hint1");
        this.hint2 = GameObject.Find("hint2");
        this.DoorOpenS = GameObject.Find("FinalDoorOpen");
        objectToEnable.SetActive(false);
        IsPlayerEnter = false;
        player = GameObject.FindGameObjectWithTag("Player");
        btnClicked = 0; // No of times the button was clicked
        numOfGuesses = curPassword.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (btnClicked == numOfGuesses)
        {
            if (input == curPassword)
            {
                //Load the next scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                // LOG message that password is correct
                Debug.Log("Correct Password!");
                input = ""; //Clear Password
                btnClicked = 0;
                this.DoorOpenS.GetComponent<AudioSource>().Play();

                Door2.transform.rotation = Quaternion.Euler(new Vector3(-90, 0, 0));

                Destroy(Orange);
                Destroy(hint1);
                Destroy(Red);
                Destroy(hint2);
            }
            else
            {
                //Reset input varible
                input = "";
                displayText.text = input.ToString();
                audioData.Play();
                btnClicked = 0;
            }

        }
        if (Input.GetMouseButtonDown(0) && IsPlayerEnter)
        {
            objectToEnable.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // Action for clicking keypad( GameObject ) on screen
        IsPlayerEnter = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            IsPlayerEnter = false;
        }
    }

    public void ValueEntered(string valueEntered)
    {
        switch (valueEntered)
        {
            case "C": // QUIT
                objectToEnable.SetActive(false);
                btnClicked = 0;
                keypadScreen = false;
                input = "";
                displayText.text = input.ToString();
                break;

            case "M": //CLEAR
                input = "";
                btnClicked = 0;// Clear Guess Count
                displayText.text = input.ToString();
                break;

            default: // Buton clicked add a variable
                btnClicked++; // Add a guess
                input += valueEntered;
                displayText.text = input.ToString();
                break;
        }


    }
}