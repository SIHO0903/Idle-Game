using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

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
public class EquipmentInfoInspector : Editor
{
    SerializedProperty equipTypeProperty;
    SerializedProperty weaponNameProperty;
    SerializedProperty defenseNameProperty;
    SerializedProperty glovesNameProperty;
    SerializedProperty ringNameProperty;

    SerializedProperty mountingEffect;
    SerializedProperty mountingIncrement;
    SerializedProperty retentionEffect;
    SerializedProperty retentionIncrement;

    TextAsset txt;
    AsyncOperationHandle<TextAsset> handle;
    int lineSize;
    EquipDatas[] equipDatas;

    public override async void  OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();

        equipTypeProperty = serializedObject.FindProperty("equipType");
        weaponNameProperty = serializedObject.FindProperty("weaponName");
        defenseNameProperty = serializedObject.FindProperty("defenseName");
        glovesNameProperty = serializedObject.FindProperty("glovesName");
        ringNameProperty = serializedObject.FindProperty("ringName");

        mountingEffect = serializedObject.FindProperty("mountingEffect");
        mountingIncrement = serializedObject.FindProperty("mountingIncrement");
        retentionEffect = serializedObject.FindProperty("retentionEffect");
        retentionIncrement = serializedObject.FindProperty("retentionIncrement");


        switch (equipTypeProperty.enumValueFlag)
        {
            case 0:
                EditorGUILayout.PropertyField(weaponNameProperty);
                HideProperty(defenseNameProperty);
                HideProperty(glovesNameProperty);
                HideProperty(ringNameProperty);
                break;
            case 1:
                EditorGUILayout.PropertyField(defenseNameProperty);
                HideProperty(weaponNameProperty);
                HideProperty(glovesNameProperty);
                HideProperty(ringNameProperty);
                break;
            case 2:
                EditorGUILayout.PropertyField(glovesNameProperty);
                HideProperty(weaponNameProperty);
                HideProperty(defenseNameProperty);
                HideProperty(ringNameProperty);
                break;
            case 3:
                EditorGUILayout.PropertyField(ringNameProperty);
                HideProperty(weaponNameProperty);
                HideProperty(defenseNameProperty);
                HideProperty(glovesNameProperty);
                break;
        }

        if (txt == null)
        {
            handle = Addressables.LoadAssetAsync<TextAsset>("EquipmentData");
            await handle.Task;
            txt = handle.Result;
            string currentText = txt.text.Substring(0, txt.text.Length - 1);
            string[] line = currentText.Split('\n');
            lineSize = line.Length;
            equipDatas = new EquipDatas[lineSize];
            for (int i = 0; i < equipDatas.Length; i++)
            {
                equipDatas[i] = new EquipDatas();
            }
            for (int i = 0; i < lineSize; i++)
            {
                string[] row = line[i].Split('\t');

                equipDatas[i].equipType = row[0];
                equipDatas[i].equipName = row[1];
                equipDatas[i].rarity = row[2];
                equipDatas[i].mountingEffect = float.Parse(row[3]);
                equipDatas[i].mountingIncrement = float.Parse(row[4]);
                equipDatas[i].retentionEffect = float.Parse(row[5]);
                equipDatas[i].retentionIncrement = float.Parse(row[6]);
            }

        }

        for (int i = 0; i < equipDatas.Length; i++)
        {

            if(equipTypeProperty.enumNames[equipTypeProperty.enumValueFlag] == equipDatas[i].equipType)
            {

                if (weaponNameProperty.enumNames[weaponNameProperty.enumValueFlag] == equipDatas[i].equipName)
                {
                    Init(i);
                }
                else if(defenseNameProperty.enumNames[defenseNameProperty.enumValueFlag] == equipDatas[i].equipName)
                {
                    Init(i);
                }
                else if (glovesNameProperty.enumNames[glovesNameProperty.enumValueFlag] == equipDatas[i].equipName)
                {
                    Init(i);
                }
                else if (ringNameProperty.enumNames[ringNameProperty.enumValueFlag] == equipDatas[i].equipName)
                {
                    Init(i);
                }
            }
        }


        serializedObject.ApplyModifiedProperties();
    }
    void HideProperty(SerializedProperty property)
    {
        property.isExpanded = false;
    }
    void Init(int i)
    {
        mountingEffect.floatValue = equipDatas[i].mountingEffect;
        mountingIncrement.floatValue = equipDatas[i].mountingIncrement;
        retentionEffect.floatValue = equipDatas[i].retentionEffect;
        retentionIncrement.floatValue = equipDatas[i].retentionIncrement;
    }
}
