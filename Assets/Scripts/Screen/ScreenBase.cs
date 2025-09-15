using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;

namespace Screens
{

    public enum ScreenType 
    { 
        Panel,
        Info_Panel,
        Shop
    
    }

    public class ScreenBase: MonoBehaviour
    {
        public ScreenType ScreenType;

        public List<Transform> listOfObjects;

        public bool startHide = false;

        public float delayBetweenObjects = .05f;
        public float animationDuration = .3f;

        private void Start()
        {
            if (startHide)
            {
                HideObjects();
            }
        }

        [Button]      
        protected virtual void Force()
        {
            ForceShowObjects();
            Debug.Log("Force Show");
        }
        [Button]      
        protected virtual void Show()
        {
            ShowObjects();
            Debug.Log("Show");
        }
        
        [Button]
        protected virtual void Hide()
        {
            Debug.Log("Hide");
            HideObjects();
        }
        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
        }
        private void ShowObjects()
        {
            Debug.Log("Quantidade de Objetos = " + listOfObjects.Count);

            for (int i = 0; i < listOfObjects.Count; i++) 
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
        }
        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));            
        }
        
    }

}
