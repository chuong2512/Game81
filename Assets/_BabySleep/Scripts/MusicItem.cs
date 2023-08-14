using UnityEngine;
using UnityEngine.UI;

public class MusicItem : MonoBehaviour
{
    public Button button;

    public void Init(Sprite sprite, int id, MusicSelector musicSelector)
    {
        iconImage.sprite = sprite;

        button.onClick.AddListener(() => { musicSelector.ChooseMusic(id); });
    }


    public void Unlock()
    {
        lockObj.SetActive(false);
    }

    public void Choose()
    {
        chooseObj.SetActive(true);
    }

    public GameObject lockObj, chooseObj;
    public Image iconImage;

    public void UnChoose()
    {
        chooseObj.SetActive(false);
    }
}