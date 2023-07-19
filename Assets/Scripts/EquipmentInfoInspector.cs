using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EquipmentInfo))]
public class EquipmentInfoInspector : Editor
{
    SerializedProperty equipTypeProperty;
    SerializedProperty weaponNameProperty;
    SerializedProperty defenseNameProperty;
    SerializedProperty glovesNameProperty;
    SerializedProperty ringNameProperty;

    public override void  OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();

        equipTypeProperty = serializedObject.FindProperty("equipType");
        weaponNameProperty = serializedObject.FindProperty("weaponName");
        defenseNameProperty = serializedObject.FindProperty("defenseName");
        glovesNameProperty = serializedObject.FindProperty("glovesName");
        ringNameProperty = serializedObject.FindProperty("ringName");

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


        switch (equipTypeProperty.enumNames[equipTypeProperty.enumValueFlag])
        {
            case "Weapon":
                //for (int i = 0; i < equipDatas.Length; i++)
                //{
                //    if (weaponNameProperty.enumNames[weaponNameProperty.enumValueFlag] == equipDatas[i].equipName)
                //    {
                //        Debug.Log("¸Õµ¥");
                //    }
                //}

                break;
            case "Defense":
                break;
            case "Gloves":
                break;
            case "Ring":
                break;

        }


        serializedObject.ApplyModifiedProperties();
    }
    void HideProperty(SerializedProperty property)
    {
        property.isExpanded = false;
    }
}
