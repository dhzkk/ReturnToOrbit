using System;
using System.IO;
using UnityEngine;

public class StatsSaveSystem : MonoBehaviour
{
    public static string Path = Application.dataPath + "/statsSave.json";

    public static void Exists()
    {
        if (!File.Exists(Path))
        {
            File.Create(Path);
        }
    }

    public static StatsSaveData Load()
    {
        return JsonUtility.FromJson<StatsSaveData>(File.ReadAllText(Path));
    }

    public static void Save(int enemyKillCount, int skillActivateCount, int itemActivateCount, float hitDamageAmount, float healAmount)
    {
        StatsSaveData data = new()
        {
            EnemyKillCount = enemyKillCount,
            SkillActivateCount = skillActivateCount,
            ItemActivateCount = itemActivateCount,
            HitDamageAmount = hitDamageAmount,
            HealAmount = healAmount
        };
        File.WriteAllText(Path, JsonUtility.ToJson(data));
    }

    public static void Save(StatsSaveData data)
    {
        File.WriteAllText(Path, JsonUtility.ToJson(data));
    }

    public static void Init()
    {
        Save(0, 0, 0, 0, 0);
    }

    [Serializable]
    public class StatsSaveData
    {
        public int EnemyKillCount;
        public int SkillActivateCount;
        public int ItemActivateCount;
        public float HitDamageAmount;
        public float HealAmount;
    }
}