using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRocket
{
    public string hanzi;
    public string pinyin;
    public string translation;

    public FireRocket(string hanzi, string pinyin, string translation)
    {
        this.hanzi = hanzi;
        this.pinyin = pinyin;
        this.translation = translation;
    }
}