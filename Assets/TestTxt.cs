using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EquipDatas
{
    public string equipType;
    public string equipName;
    public string rarity;
    public float mountingEffect;
    public float retentionEffect;
    public float mountingIncrement;
    public float retentionIncrement;
}


[CustomEditor(typeof(EquipmentInfo))]
public class TestTxt : Editor
{
    TextAsset txt;

    int lineSize;

    EquipDatas[] equipDatas;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();

        txt = Resources.Load<TextAsset>("EquipmentData");
        string currentText = txt.text.Substring(0,txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        lineSize = line.Length;
        equipDatas = new EquipDatas[lineSize];
        for (int i = 0; i < lineSize; i++)
        {
            string[] row = line[i].Split('\t');
            equipDatas[i] = new EquipDatas();
            equipDatas[i].equipType = row[0];
            equipDatas[i].equipName = row[1];
            equipDatas[i].rarity = row[2];
            equipDatas[i].mountingEffect =  float.Parse(row[3]);
            equipDatas[i].mountingIncrement = float.Parse(row[4]);
            equipDatas[i].retentionEffect = float.Parse(row[5]);
            equipDatas[i].retentionIncrement = float.Parse(row[6]);
        }


        serializedObject.ApplyModifiedProperties();
    }

}

