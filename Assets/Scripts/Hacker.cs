using System;
using UnityEngine;

public enum Screen
{
    MainMenu,
    Password,
    Win
}

public class Hacker : MonoBehaviour
{
    int currentLevel;
    Screen currentScreen = Screen.MainMenu;
    string password;

    const string levelOnePwd = "science";
    const string levelTwoPwd = "judgement";
    const string levelThreePwd = "solar_storm";

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
            CheckPassword(input);
        }
    }

    private void ShowMainMenu(string greetings = "Hello")
    {
        //Reset level And screen
        currentLevel = 0;
        currentScreen = Screen.MainMenu;
        password = null;
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
        if (input == "1" || input == "2" || input == "3")
        {
            int.TryParse(input, out currentLevel);

            //Set Pwd for level
            password = currentLevel == 1
                ? levelOnePwd
                : currentLevel == 2
                    ? password = levelTwoPwd
                    : password = levelThreePwd;

            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Please select the level, Mr. Bond");
        }
        else
        {
            Terminal.WriteLine("Please select a correct level");
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

    private void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Congratulation! Password is correct");
        }
        else
        {
            Terminal.WriteLine("Sorry! Password is incorrect");
            Terminal.WriteLine("Please, try again: ");
        }
    }


}
