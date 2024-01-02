using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GD;
using My_Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SetShopPreferencesController : MonoBehaviour
    {
        [SerializeField]
        private LevelPreferencesData  levelPreferencesData;
        
        [SerializeField]
        private Slider countOfWordsToLearn;
    
        [SerializeField]
        private Slider countOfWordsToTest;
        
        public void SetCountOfWordsToLearnPreference()
        {
            levelPreferencesData.CountOfWordsToLearn = (int)countOfWordsToLearn.value;
        }

        public void SetCountOfWordsToTestPreference()
        {
            levelPreferencesData.CountOfWordsToTest = (int)countOfWordsToTest.value;
        }
    }
}
