using NUnit.Framework;
using UnityEngine;

namespace Screens
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType screenType;

        public void OnClick()
        {
            Debug.Log("Open UI: " + screenType);
            ScreenManager.Instance.ShowByType(screenType);
        }

    }
}



