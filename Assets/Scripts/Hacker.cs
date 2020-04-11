using System;
using UnityEngine;



public class Hacker : MonoBehaviour
{
    enum Screen
    {
        MainMenu,
        Password,
        Win
    }

    int currentLevel;
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        var greetings = "Hello Enrico";
        ShowMainMenu(greetings);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            //TODO
        }
    }

    private void ShowMainMenu(string greetings = "Hello")
    {
        //Reset level And screen
        currentLevel = 0;
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();

        Terminal.WriteLine(greetings);
        Terminal.WriteLine("What would you like to hack into?\n");
        Terminal.WriteLine("Press 1 for the local library");
        Terminal.WriteLine("Press 2 for the police station");
        Terminal.WriteLine("Press 3 for the NASA\n");
        Terminal.WriteLine("Enter your selection:");
    }

    private void RunMainMenu(string input)
    {
        switch (input)
        {
            case "1":
            case "2":
            case "3":
                int.TryParse(input, out currentLevel);
                StartGame();
                break;
            case "007":
                Terminal.WriteLine("Please select the level, Mr. Bond");
                break;
            default:
                Terminal.WriteLine("Please select a correct level");
                break;
        }
    }

    private void StartGame()
    {
        currentScreen = Screen.Password;
        if (currentLevel == 0)
        {
            Terminal.WriteLine("Something went wrong, returning to Main Menu");
            ShowMainMenu();
        }
        else
        {
            Terminal.WriteLine("You selected level " + currentLevel);
            Terminal.WriteLine("Please enter your Password: ");
        }
    }


}
