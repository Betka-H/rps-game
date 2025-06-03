using TMPro;
using UnityEngine;

public class menuNavigation : MonoBehaviour
{
    public enum menus { main, settings, play }

    [Header("title")]
    public TMP_Text titleObject;
    public string gameTitle;
    public string settingsTitle;
    public string playTitle;

    [Header("menu objects")]
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject playMenu;

    [Space]
    public gameManager gameManager;

    void Start()
    {
        openMenu(menus.main);
        gameManager.gState = gameManager.gameState.menu;
    }

    public void openMainMenu() => openMenu(menus.main);
    public void openSettingsMenu() => openMenu(menus.settings);
    public void openPlayMenu() => openMenu(menus.play);

    void openMenu(menus menu)
    {
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
