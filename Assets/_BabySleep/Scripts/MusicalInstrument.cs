using UnityEngine;
using UnityEngine.UI;

public class MusicalInstrument : MonoBehaviour
{
    public Button button;

    public void Init(Sprite sprite, int id, MusicalSelec musicalSelec)
    {
        iconImage.sprite = sprite;

        button.onClick.AddListener(() => { musicalSelec.ChooseMusicToPlay(id); });
    }



    public void Choose()
    {
        chooseObj.SetActive(true);
    }

    public void Unlock()
    {
        lockObj.SetActive(false);
    }

    public void UnChoose()
    {
        chooseObj.SetActive(false);
    }

    public GameObject lockObj, chooseObj;
    public Image iconImage;

   
}