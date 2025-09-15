using UnityEngine;
using System.Collections.Generic;
using NaughtyAttributes;
using DG.Tweening;
using UnityEditor;

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
        public List<Typper> listOfPhrases;

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
            //Debug.Log("Force Show");

            if (!EditorApplication.isPlaying) { return; }
            ForceShowObjects();            
        }

        [Button]      
        protected virtual void Show()
        {
            //Debug.Log("Show");

            if (!EditorApplication.isPlaying) { return; }
            ShowObjects();            
        }
        
        [Button]
        protected virtual void Hide()
        {
            // Debug.Log("Hide");

            if (!EditorApplication.isPlaying) { return; }
            HideObjects();
        }
        private void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
        }
        private void ShowObjects()
        {
            // Debug.Log("Quantidade de Objetos = " + listOfObjects.Count);

            for (int i = 0; i < listOfObjects.Count; i++) 
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);

        }
        private void StartType()
        {
            
            for (int i = 0; i < listOfPhrases.Count; i++) 
            {
                listOfPhrases[i].StartType();                                
            }
        }
        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));            
        }
        
    }

}
