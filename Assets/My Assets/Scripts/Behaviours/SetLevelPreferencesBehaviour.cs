using System;
using System.Collections;
using System.Collections.Generic;
using My_Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetLevelPreferencesBehaviour : MonoBehaviour
{
    [SerializeField]
    private InputField languageToLearn;
    
    [SerializeField]
    private Slider countOfWordsToLearn;
    
    [SerializeField]
    private Slider countOfWordsToTest;
    
    [SerializeField]
    private InputField  tutorialSelected;
    
    [SerializeField]
    private LevelPreferencesData  levelPreferencesData;

    void Update()
    {
        UpdateLevelPreferences();
    }

    private void UpdateLevelPreferences()
    {
        //levelPreferencesData.LanguageToLearn = languageToLearn.text;
        levelPreferencesData.CountOfWordsToLearn = (int)countOfWordsToLearn.value;
        levelPreferencesData.CountOfWordsToTest = (int)countOfWordsToTest.value;
        //levelPreferencesData.TutorialSelected = tutorialSelected.text;
    }
}
