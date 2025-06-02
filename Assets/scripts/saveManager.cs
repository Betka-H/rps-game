using UnityEngine;

[System.Serializable]
public class saveData
{
    public int[] games;
    public int[] rolls;
    public int[] timesRPS;
}

public class saveManager : MonoBehaviour
{
    string saveKey = "statsSave";
    public statsManager sm;

    public void save()
    {
        saveData data = new saveData();

        data.games = sm.games;
        data.rolls = sm.rolls;
        data.timesRPS = sm.timesRPS;

        PlayerPrefs.SetString(saveKey, JsonUtility.ToJson(data));
        PlayerPrefs.Save();

        Debug.Log($"saved save:\ngames: {string.Join(", ", data.games)}, rolls: {string.Join(", ", data.rolls)}, timesRPS: {string.Join(", ", data.timesRPS)}");
    }

    public void loadSave()
    {
        if (PlayerPrefs.HasKey(saveKey))
        {
            saveData data = JsonUtility.FromJson<saveData>(PlayerPrefs.GetString(saveKey));

            sm.games = data.games;
            sm.rolls = data.rolls;
            sm.timesRPS = data.timesRPS;
        }
        else Debug.LogWarning("no game save present!");

        Debug.Log($"loaded save:\ngames: {string.Join(", ", sm.games)}, rolls: {string.Join(", ", sm.rolls)}, timesRPS: {string.Join(", ", sm.timesRPS)}");
    }

    public void clearPrefs()
    {
        Debug.Log($"clearing save");
        PlayerPrefs.DeleteKey(saveKey);
        PlayerPrefs.Save();
    }
}
