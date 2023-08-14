using UnityEngine.Serialization;

namespace MyNamespace
{
    using Jackal;
    using UnityEngine;
    using UnityEngine.UI;

    [DefaultExecutionOrder(-99)]
    public class AudioManager : Singleton<AudioManager>
    {
        public AudioSource musicSource;
        private SongInfoSO _songInfoSo;

        public Image image;
        public Sprite iconOn, iconOff;
        
        [FormerlySerializedAs("timer")] public TimeControl timeControl;


        public void Stop()
        {
            musicSource.Stop();
        }

        public void Continue()
        {
            musicSource.Play();
        }

        public void Play()
        {
            if (musicSource.isPlaying)
            {
                musicSource.Stop();
                timeControl.Stop();
            }
            else
            {
                musicSource.Play();
            }
        }

        void Update()
        {
            if (musicSource.isPlaying)
            {
                image.sprite = iconOff;
            }
            else
            {
                image.sprite = iconOn;
            }
        }

        protected override void Awake()
        {
            base.Awake();

            _songInfoSo = GameDataManager.Instance.songInfoSo;
            musicSource.loop = true;
        }

        public void ChangeVolume(float value)
        {
            musicSource.volume = value;
        }

        public void PlaySong(int id)
        {
            musicSource.clip = _songInfoSo.GetSongWithID(id).song;
            musicSource.Play();
        }

        public void TurnMusicOff()
        {
            ChangeVolume(0.0f);
        }

        public void TurnMusicOn()
        {
            ChangeVolume(1.0f);
        }
    }
}