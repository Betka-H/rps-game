using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public enum gameState { game, menu }
    [HideInInspector] public gameState gState;

    public Slider roundsSlider;
    public Slider rollsSlider;
    public Slider oppSlider;

    public menuNavigation menuNavigation;

    public void playgame()
    {
        float rounds = roundsSlider.value;
        float rolls = rollsSlider.value;
        float opp = oppSlider.value;

        Debug.Log($"starting game\n--------------------------------------------------------------");
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
