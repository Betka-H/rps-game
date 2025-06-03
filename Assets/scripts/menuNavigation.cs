using TMPro;
using UnityEngine;

public class menuNavigation : MonoBehaviour
{
    public enum menus { main, settings, play, hide }

    [Header("title")]
    public TMP_Text titleObject;
    public string gameTitle, settingsTitle, playTitle;

    [Header("menu objects")]
    public GameObject wholeMenu, mainMenu, settingsMenu, playMenu;

    [Space]
    public gameManager gameManager;

    void Start()
    {
        toggleMenu(menus.main);
        gameManager.gState = gameManager.gameState.menu;
    }

    public void openMainMenu() => toggleMenu(menus.main);
    public void openSettingsMenu() => toggleMenu(menus.settings);
    public void openPlayMenu() => toggleMenu(menus.play);
    public void closeWholeMenu() => toggleMenu(menus.hide);

    void toggleMenu(menus menu)
    {
        wholeMenu.SetActive(true);
        mainMenu.gameObject.SetActive(false);
        settingsMenu.gameObject.SetActive(false);
        playMenu.gameObject.SetActive(false);

        switch (menu)
        {
            case menus.main:
                titleObject.text = gameTitle;
                mainMenu.SetActive(true);
                break;
            case menus.settings:
                titleObject.text = settingsTitle;
                settingsMenu.SetActive(true);
                break;
            case menus.play:
                titleObject.text = playTitle;
                playMenu.SetActive(true);
                break;
            case menus.hide:
                wholeMenu.SetActive(false);
                break;
            default:
                Debug.LogError("invalid input");
                break;
        }
    }

    public void quitGame()
    // called from quit button
    {
        Debug.Log($"quitting game");
        //! Environment.Exit(0);
    }
}
