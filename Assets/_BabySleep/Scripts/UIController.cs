namespace MyNamespace
{
    using Jackal;
    using UnityEngine;

    public class UIController : Singleton<UIController>
    {
        public GameObject panelStart, panelApp;

        
        public void OpenApp()
        {
            panelStart.SetActive(false);
            panelApp.SetActive(true);
        }
        
        void Start()
        {
            OpenApp();
        }

    }
}