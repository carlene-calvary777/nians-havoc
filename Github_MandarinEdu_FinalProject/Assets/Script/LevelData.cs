using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HanziQuestion
{
    public string hanzi;
    public string correctPinyin;
    public string correctTranslation;
}

[System.Serializable]
public class Level
{
    public int levelNumber;
    public List<HanziQuestion> questions;
}

[CreateAssetMenu(fileName = "LevelData", menuName = "Game Data/Level Data")]
public class LevelData : ScriptableObject
{
    public List<Level> levels = new List<Level>
    {
        new Level
        {
            levelNumber = 1,
            questions = new List<HanziQuestion>
            {
                new HanziQuestion { hanzi = "谢谢", correctPinyin = "xièxie", correctTranslation = "Terima kasih" },
                // new HanziQuestion { hanzi = "不", correctPinyin = "bù", correctTranslation = "Tidak" },
                // new HanziQuestion { hanzi = "客气", correctPinyin = "kèqì", correctTranslation = "Sama-sama" },
                // new HanziQuestion { hanzi = "对不起", correctPinyin = "duìbuqǐ", correctTranslation = "Maaf" },
                // new HanziQuestion { hanzi = "没关系", correctPinyin = "méi guānxi", correctTranslation = "Tidak apa-apa" },
                // new HanziQuestion { hanzi = "什么", correctPinyin = "shénme", correctTranslation = "Apa" },
                // new HanziQuestion { hanzi = "再见", correctPinyin = "zàijiàn", correctTranslation = "Selamat tinggal" },
                // new HanziQuestion { hanzi = "叫", correctPinyin = "jiào", correctTranslation = "Memanggil/Bernama" }


            }
        },
        new Level
        {
            levelNumber = 2,
            questions = new List<HanziQuestion>
            {
                new HanziQuestion { hanzi = "苹果", correctPinyin = "píngguǒ", correctTranslation = "Apple" },
                new HanziQuestion { hanzi = "香蕉", correctPinyin = "xiāngjiāo", correctTranslation = "Banana" },
                new HanziQuestion { hanzi = "橙子", correctPinyin = "chéngzi", correctTranslation = "Orange" }
            }
        },
        // new Level
        // {
        //     levelNumber = 3,
        //     questions = new List<HanziQuestion>
        //     {
        //         new HanziQuestion { hanzi = "猫", correctPinyin = "māo", correctTranslation = "Cat" },
        //         new HanziQuestion { hanzi = "狗", correctPinyin = "gǒu", correctTranslation = "Dog" },
        //         new HanziQuestion { hanzi = "鸟", correctPinyin = "niǎo", correctTranslation = "Bird" }
        //     }
        // },
        // new Level
        // {
        //     levelNumber = 4,
        //     questions = new List<HanziQuestion>
        //     {
        //         new HanziQuestion { hanzi = "红色", correctPinyin = "hóngsè", correctTranslation = "Red" },
        //         new HanziQuestion { hanzi = "蓝色", correctPinyin = "lánsè", correctTranslation = "Blue" },
        //         new HanziQuestion { hanzi = "绿色", correctPinyin = "lǜsè", correctTranslation = "Green" }
        //     }
        // },
        // new Level
        // {
        //     levelNumber = 5,
        //     questions = new List<HanziQuestion>
        //     {
        //         new HanziQuestion { hanzi = "学校", correctPinyin = "xuéxiào", correctTranslation = "School" },
        //         new HanziQuestion { hanzi = "老师", correctPinyin = "lǎoshī", correctTranslation = "Teacher" },
        //         new HanziQuestion { hanzi = "学生", correctPinyin = "xuéshēng", correctTranslation = "Student" }
        //     }
        // }
    };

    public HanziQuestion GetRandomHanzi()
    {
        int randomLevelIndex = Random.Range(0, levels.Count);
        Level randomLevel = levels[randomLevelIndex];

        int randomQuestionIndex = Random.Range(0, randomLevel.questions.Count);
        return randomLevel.questions[randomQuestionIndex];
    }


}

