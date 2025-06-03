using TMPro;
using UnityEngine;

public class statsManager : MonoBehaviour
{
    [HideInInspector] public int[] games, rolls, timesRPS;
    // games started, won, lost, drew (4)
    // rolls started, won, lost, drew (4)
    // times rock, paper, scissors (3)

    [Header("text displays")]
    public TMP_Text[] gamesTxt, rollsTxt, timesRPSTxt;

    [Space]
    public saveManager saveManager;

    void Awake()
    {
        games = new int[gamesTxt.Length];
        rolls = new int[rollsTxt.Length];
        timesRPS = new int[timesRPSTxt.Length];
        saveManager.loadStats();
    }

    void OnEnable()
    {
        updateStatsDisplay();
    }

    public void updateStatsDisplay()
    {
        setTxt(gamesTxt, games);
        setTxt(rollsTxt, rolls);
        setTxt(timesRPSTxt, timesRPS);

        void setTxt(TMP_Text[] txts, int[] ints)
        {
            for (int i = 0; i < txts.Length; i++)
                txts[i].text = ints[i].ToString();
        }
    }
}