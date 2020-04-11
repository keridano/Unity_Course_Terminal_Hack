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
    readonly string[] level1Passwords = { "books", "aisle", "self", "password", "font", "borrow" };
    readonly string[] level2Passwords = { "prisoner", "handcuffs", "holster", "uniform", "arrest" };
    readonly string[] level3Passwords = { "solarstorm", "rocket", "andromeda", "universe", "propeler" };

    int currentLevel;
    string password;
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
            password = (string)(currentLevel == 1
                ? GetRandomValueFromArray(level1Passwords)
                : currentLevel == 2
                    ? GetRandomValueFromArray(level2Passwords)
                    : GetRandomValueFromArray(level3Passwords));

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

    private object GetRandomValueFromArray(object[] input)
    {
        var random = new System.Random();
        int index = random.Next(0, input.Length);
        return input[index];
    }

}
