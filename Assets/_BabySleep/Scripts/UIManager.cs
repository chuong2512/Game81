namespace MyNamespace
{
    using Jackal;
    using UnityEngine;

    public class UIManager : Singleton<UIManager>
    {
        public GameObject panelStart, panelApp;

        void Start()
        {
            OpenApp();
        }

        public void OpenApp()
        {
            panelStart.SetActive(false);
            panelApp.SetActive(true);
        }
    }
}