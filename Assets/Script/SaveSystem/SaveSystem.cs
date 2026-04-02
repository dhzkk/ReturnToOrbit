using System;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static string Path = Application.dataPath + "/save.json";

    public static void Exists()
    {
        if (!File.Exists(Path))
        {
            File.Create(Path);
        }
    }

    public static SaveData Load()
    {
        return JsonUtility.FromJson<SaveData>(File.ReadAllText(Path));
    }

    public static void Save(int score, int stage, int money, int increaseHpAmount, int times, bool[] hasPart, bool[] isEquippedPart, ESkill[] equippedPart, int[] itemLevel)
    {
        SaveData data = new()
        {
            Score = score,
            Stage = stage,
            Money = money,
            Time = times,
            IncreaseHpAmount = increaseHpAmount,
            HasPart = hasPart,
            IsEquippedPart = isEquippedPart,
            EquippedPart = equippedPart,
            ItemLevel = itemLevel
        };
        File.WriteAllText(Path, JsonUtility.ToJson(data));
    }

    public static void Save(SaveData data)
    {
        File.WriteAllText(Path, JsonUtility.ToJson(data));
    }

    public static void Init()
    {
        bool[] hasPart = { false, false, false, false, false };
        bool[] isEquippedPart = { false, false, false, false, false };
        int[] itemLevel = { 0, 0, 0, 0, 0 };
        ESkill[] equippedPart = { ESkill.None, ESkill.None };
        Save(0, 0, 100000, 0, 0, hasPart, isEquippedPart, equippedPart, itemLevel);
    }

    [Serializable]
    public class SaveData
    {
        public int Score;
        public float Time;
        public int Stage;
        public int Money;
        public int IncreaseHpAmount;
        public bool[] HasPart, IsEquippedPart;
        public ESkill[] EquippedPart;
        public int[] ItemLevel;
    }
}