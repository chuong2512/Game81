using MyNamespace;
using TMPro;
using UnityEngine;

public class MusicSelector : MonoBehaviour
{
    private PlayerData playerData; //todo delete
    private GameDataManager gameData; //todo delete
    public TextMeshProUGUI diamonds;
    public GameObject inApp;

    public int currentMusic;
    public MusicItem[] musicItems;

    void OnEnable()
    {
        gameData = GameDataManager.Instance;
        playerData = gameData.playerData;

        diamonds.text = "" + playerData.intDiamond;
        currentMusic = playerData.currentSong;
        if (currentMusic > -1)
        {
            musicItems[currentMusic].Choose();
            AudioManager.Instance.PlaySong(currentMusic);
            AudioManager.Instance.Play();
        }
    }

    void Start()
    {
        for (int i = 0; i < musicItems.Length; i++)
        {
            musicItems[i].Init(gameData.songSo.GetSongWithID(i).icon, i, this);

            if (playerData.listSongs[i])
            {
                musicItems[i].Unlock();
            }
        }
    }

    public void ChooseMusic(int index)
    {
        if (currentMusic == index)
        {
            return;
        }

        if (playerData.listSongs[index] == false)
        {
            if (!playerData.CheckCanUnlock())
            {
                inApp.SetActive(true);
                return;
            }

            UnlockSkin(index);
        }

        if (currentMusic > -1)
        {
            musicItems[currentMusic].UnChoose();
        }

        musicItems[index].Choose();
        currentMusic = index;
        playerData.ChooseSong(currentMusic);

        AudioManager.Instance.PlaySong(currentMusic);
    }

    public void UnlockSkin(int index)
    {
        if (!playerData.listSongs[index])
        {
            playerData.SubDiamond(Constant.priceUnlockSong);
        }

        diamonds.text = playerData.intDiamond.ToString();
        musicItems[index].Unlock();
        playerData.listSongs[index] = true;
    }

    public void AddDiamonds(int value)
    {
        IAPManager.OnPurchaseSuccess = () =>
        {
            //todo add PlayerData
            playerData.AddDiamond(value);
            diamonds.text = playerData.intDiamond.ToString();
        };

        switch (value)
        {
            case 100:
                IAPManager.Instance.BuyProductID(IAPKey.PACK1);
                break;
            case 200:
                IAPManager.Instance.BuyProductID(IAPKey.PACK2);
                break;
            case 500:
                IAPManager.Instance.BuyProductID(IAPKey.PACK3);
                break;
            case 1000:
                IAPManager.Instance.BuyProductID(IAPKey.PACK4);
                break;
        }
    }
}