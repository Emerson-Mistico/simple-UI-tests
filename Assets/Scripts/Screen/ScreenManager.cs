using UnityEngine;
using Ebac.Core.Singleton;
using System.Collections.Generic;
using System.Collections;

namespace Screens
{
    public class ScreenManager : Singleton<ScreenManager>
    {
        public List<ScreenBase> screenBases;
        public ScreenType startScreen = ScreenType.Panel;

        private ScreenBase _currentScreen;

        private void Start()
        {
            HideAll();
            ShowByType(startScreen);
        }

        public void ShowByType(ScreenType type)
        {
            if(_currentScreen != null)
            {
                _currentScreen.Hide();
            }

            Debug.Log("Aqui chegou: " + type);
            var nextScreen = screenBases.Find(i => i.ScreenType == type);
            nextScreen.Show();
            _currentScreen = nextScreen;
        }

        public void HideAll()
        {
            screenBases.ForEach (i => i.Hide());
        }

    }
}


