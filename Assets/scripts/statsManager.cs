using TMPro;
using UnityEngine;

public class statsManager : MonoBehaviour
{
    [HideInInspector] public int[] games; // started, won, lost, drew
    [HideInInspector] public int[] rolls; // started, won, lost, drew
    [HideInInspector] public int[] timesRPS; // times rock, times paper, times scissors

    [Header("text displays")]
    public TMP_Text[] gamesTxt;
    public TMP_Text[] rollsTxt;
    public TMP_Text[] timesRPSTxt;

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

    public void resetStats()
    {
        Debug.Log($"resetting stats");
        games = new int[gamesTxt.Length];
        rolls = new int[rollsTxt.Length];
        timesRPS = new int[timesRPSTxt.Length];
        saveManager.saveStats();
    }
}