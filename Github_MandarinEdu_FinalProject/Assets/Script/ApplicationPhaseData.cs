using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ApplicationPhaseData
{
    private static Dictionary<int, List<FireRocket>> fireRocketData = new Dictionary<int, List<FireRocket>>()
    {
        { 1, new List<FireRocket> { new FireRocket("火", "huǒ", "fire"), new FireRocket("水", "shuǐ", "water") } },
        { 2, new List<FireRocket> { new FireRocket("山", "shān", "mountain"), new FireRocket("月", "yuè", "moon") } },
    };

    private static Dictionary<int, List<string>> hanziData = new Dictionary<int, List<string>>()
    {
        { 1, new List<string> { "火", "水" } },
        { 2, new List<string> { "山", "月" } },
    };

    public static int GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("CurrentLevel", 1); // Get saved level, default to 1
    }

    public static List<FireRocket> GetFireRocketsForLevel(int level)
    {
        if (fireRocketData.ContainsKey(level))
        {
            return fireRocketData[level];
        }
        return new List<FireRocket>(); // Return empty list if level not found
    }

    public static string GetRandomHanzi(int level)
    {
        if (hanziData.ContainsKey(level) && hanziData[level].Count > 0)
        {
            int randomIndex = Random.Range(0, hanziData[level].Count);
            return hanziData[level][randomIndex];
        }
        return "无"; // Default placeholder if no Hanzi found
    }
}
