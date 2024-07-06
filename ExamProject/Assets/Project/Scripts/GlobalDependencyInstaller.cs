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


        public override void InstallBindings()
        {

        }
    }
}