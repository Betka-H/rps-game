using TMPro;
using UnityEngine;

public class menuNavigation : MonoBehaviour
{
    [Header("title")]
    public TMP_Text titleObject;
    public string gameTitle;
    public string settingsTitle;

    [Header("menus")]
    public GameObject mainMenu;
    public GameObject settingsMenu;

    [Space]
    public gameManager gameManager;

    void Start()
    {
        openMainMenu();
        gameManager.gState = gameManager.gameState.menu;
    }

    public void openMainMenu()
    {
        settingsMenu.gameObject.SetActive(false);
        mainMenu.gameObject.SetActive(true);

        titleObject.text = gameTitle;
    }
    public void openSettingsMenu()
    {
        settingsMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);

        titleObject.text = settingsTitle;
    }
}
