using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using YohohoChobotov.Configs;
using YohohoChobotov.Services;
using YohohoChobotov.Services.Levels;

namespace YohohoChobotov.App
{
    public class AppLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<Config> configs = new();
        [SerializeField] private List<MonoBehaviour> controllers = new();

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterConfigs(builder);
            RegisterControllers(builder);
            RegisterServices(builder);
        }

        private void RegisterConfigs(IContainerBuilder builder)
        {
            foreach (var config in configs)
            {
                builder.RegisterComponent(config).AsSelf();
            }
        }

        private void RegisterControllers(IContainerBuilder builder)
        {
            foreach (var controller in controllers) 
            {
                builder.RegisterInstance(controller).AsSelf();
            }
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            builder.Register<ILevelService, LevelService>(Lifetime.Singleton);
            builder.Register<IScoreService, ScoreService>(Lifetime.Singleton);
        }
    }
}