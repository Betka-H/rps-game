using UnityEngine;

public class gameManager : MonoBehaviour
{
    public enum gameState { game, menu }
    public gameState gState;

    public void quitGame()
    // called from quit button
    {
        Debug.Log($"quitting game");
        //! Environment.Exit(0);
    }
}
