using Interfaces;
using SO;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GlobalDependencyInstaller : MonoInstaller
    {
        [SerializeField] private UIFactory _uiFactory;
        /*[SerializeField] private AudioService _audioService;*/

        /*[Header("Ads")]
        [SerializeField] private BannerAd _bannerAd;
        [SerializeField] private RewardedAd_AdMob _rewardedAd;*/

        [Header("Lists")]
        [SerializeField] private BirdList _birdsList;
        [SerializeField] private LevelList _levelsList;
        public override void InstallBindings()
        {
            Container.Bind<UIFactory>().FromInstance(_uiFactory);


            Container.Bind<BirdList>().FromInstance(_birdsList);
            Container.Bind<IBirdSaveManager>().FromInstance(_birdsList);
            Container.Bind<LevelList>().FromInstance(_levelsList);
            Container.Bind<ILevelSaveManager>().FromInstance(_levelsList);

            _birdsList.Initialize();
        }
    }
}