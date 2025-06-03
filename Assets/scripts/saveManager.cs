using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class statSaveData
{
    public int[] stat_games, stat_rolls, stat_timesRPS;
}
[System.Serializable]
public class playSettingsSaveData
{
    public float play_rounds, play_rolls, play_opp;
}
[System.Serializable]
public class volumeSettingsSaveData
{
    public float vol_music, vol_SFX;
}

public class saveManager : MonoBehaviour
{
    string statsSaveKey = "statsSave", playSaveKey = "playSave", volSaveKey = "volSave";

    [Header("stats")]
    public statsManager statsManager;

    [Header("play sliders")]
    public Slider roundSlider, rollSlider, oppSlider;
    [Min(1)] public int defaultRounds, defaultRolls, defaultOpp;

    [Header("volume sliders")]
    public Slider musicSlider, SFXSlider;
    [Min(0)] public float defaultMusicVol, defaultSFXVol;

    void Start()
    {
        // do not load stats here (loaded at awake in statsmanager)
        loadPlaySettings();
        loadVolumeSettings();
    }

    public void saveStats()
    {
        save(statsSaveKey,
        JsonUtility.ToJson(new statSaveData
        {
            stat_games = statsManager.games,
            stat_rolls = statsManager.rolls,
            stat_timesRPS = statsManager.timesRPS
        }));

        Debug.Log($"saved stats:\ngames: {string.Join(", ", statsManager.games)}, rolls: {string.Join(", ", statsManager.rolls)}, timesRPS: {string.Join(", ", statsManager.timesRPS)}");
    }
    public void savePlaySettings()
    {
        save(playSaveKey,
        JsonUtility.ToJson(new playSettingsSaveData
        {
            play_rounds = roundSlider.value,
            play_rolls = rollSlider.value,
            play_opp = oppSlider.value
        }));

        Debug.Log($"saved play settings:\nrounds: {roundSlider.value}, rolls: {rollSlider.value}, opp: {oppSlider.value}");
    }
    public void saveVolumeSettings()
    {
        save(volSaveKey,
        JsonUtility.ToJson(new volumeSettingsSaveData
        {
            vol_music = musicSlider.value,
            vol_SFX = SFXSlider.value,
        }));

        Debug.Log($"saved volume settings:\nmusic: {musicSlider.value}, sfx: {SFXSlider.value}");
    }
    void save(string key, string data)
    {
        PlayerPrefs.SetString(key, data);
        PlayerPrefs.Save();
    }

    public void loadStats()
    {
        if (PlayerPrefs.HasKey(statsSaveKey))
        {
            statSaveData data = JsonUtility.FromJson<statSaveData>(PlayerPrefs.GetString(statsSaveKey));

            statsManager.games = data.stat_games;
            statsManager.rolls = data.stat_rolls;
            statsManager.timesRPS = data.stat_timesRPS;
        }
        else Debug.LogWarning("no stat save present!");

        Debug.Log($"loaded stats:\ngames: {string.Join(", ", statsManager.games)}, rolls: {string.Join(", ", statsManager.rolls)}, timesRPS: {string.Join(", ", statsManager.timesRPS)}");
    }
    public void loadPlaySettings()
    {
        if (PlayerPrefs.HasKey(playSaveKey))
        {
            playSettingsSaveData data = JsonUtility.FromJson<playSettingsSaveData>(PlayerPrefs.GetString(playSaveKey));

            roundSlider.value = data.play_rounds;
            rollSlider.value = data.play_rolls;
            oppSlider.value = data.play_opp;
        }
        else
        {
            Debug.LogWarning("no game settings save present! setting default values");

            roundSlider.value = defaultRounds;
            rollSlider.value = defaultRolls;
            oppSlider.value = defaultOpp;
        }

        Debug.Log($"loaded play settings:\nrounds: {roundSlider.value}, rolls: {rollSlider.value}, opp: {oppSlider.value}");
    }
    public void loadVolumeSettings()
    {
        if (PlayerPrefs.HasKey(volSaveKey))
        {
            volumeSettingsSaveData data = JsonUtility.FromJson<volumeSettingsSaveData>(PlayerPrefs.GetString(volSaveKey));

            musicSlider.value = data.vol_music;
            SFXSlider.value = data.vol_SFX;
        }
        else
        {
            Debug.LogWarning("no volume settings save present! setting default values");

            musicSlider.value = defaultMusicVol;
            SFXSlider.value = defaultSFXVol;
        }

        Debug.Log($"loaded volume settings:\nmusic: {musicSlider.value}, sfx: {SFXSlider.value}");
    }

    public void resetStats() => clearPref("stats", statsSaveKey);
    public void resetPlaySettings() => clearPref("game settings", playSaveKey);
    public void resetVolumeSettings() => clearPref("volume settings", volSaveKey);

    void clearPref(string what, string key)
    {
        Debug.Log($"clearing {what}");
        PlayerPrefs.DeleteKey(key);
        PlayerPrefs.Save();

        if (key == statsSaveKey) loadStats();
        else if (key == playSaveKey) loadPlaySettings();
        else if (key == volSaveKey) loadVolumeSettings();
    }

    void OnApplicationQuit()
    {
        saveStats();
        savePlaySettings();
        saveVolumeSettings();
    }
}
