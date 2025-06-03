using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public enum gameState { game, menu }
    [HideInInspector] public gameState gState;

    public Slider roundsSlider, rollsSlider, oppSlider;

    public menuNavigation menuNavigation;

    public void playgame(bool tutorial)
    {
        float rounds, rolls, opp;

        if (tutorial)
        {
            rounds = 1;
            rolls = 3;
            opp = 0;
        }
        else
        {
            rounds = roundsSlider.value;
            rolls = rollsSlider.value;
            opp = oppSlider.value;
        }

        Debug.Log($"starting game\ngame settings: rounds: {rounds}, rolls: {rolls}, opp: {opp} --------------------------------------------------------------");
        menuNavigation.closeWholeMenu();

        playIntro(opp);

        for (int i = 0; i < rounds; i++) playRound(i);

        endGame();

        void playIntro(float opp)
        {
            Debug.Log($"hey im opp {opp}");
        }
        void playRound(int x)
        {
            Debug.Log($"starting round {x + 1}");
            for (int i = 0; i < rolls; i++) roll(i);
            void roll(int z)
            {
                Debug.Log($"rolling {z + 1}");
            }
        }
        void endGame()
        {
            Debug.Log($"ending game\n--------------------------------------------------------------");
            menuNavigation.openMainMenu();
        }
    }
}
