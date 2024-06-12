using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using YohohoChobotov.Services;
using YohohoChobotov.Services.Levels;

namespace YohohoChobotov.App
{
    public class AppLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<ScriptableObject> configs = new();
        [SerializeField] private List<MonoBehaviour> controllers = new();

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Configure");

            RegisterConfigs(builder);
            RegisterControllers(builder);
            RegisterServices(builder);

            Debug.Log($"System : End Configure");
        }

        private void RegisterConfigs(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Register Configs");

            foreach (var config in configs)
            {
                Debug.Log($"Register : {config.name}");

                builder.RegisterComponent(config).AsSelf();
            }

            Debug.Log($"System : End Register Configs");
        }

        private void RegisterControllers(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Register Controllers");

            foreach (var controller in controllers) 
            {
                Debug.Log($"Register : {controller.name}");

                builder.RegisterInstance(controller).AsSelf();
            }

            Debug.Log($"System : End Register Controllers");
        }

        private void RegisterServices(IContainerBuilder builder)
        {
            Debug.Log($"System : Start Register Services");

            Debug.Log($"System : Register {nameof(LevelService)}");
            builder.Register<ILevelService, LevelService>(Lifetime.Singleton);

            Debug.Log($"System : Register {nameof(ScoreService)}");
            builder.Register<IScoreService, ScoreService>(Lifetime.Singleton);

            Debug.Log($"System : Register {nameof(StackService)}");
            builder.Register<IStackService, StackService>(Lifetime.Singleton);

            Debug.Log($"System : End Register Services");
        }
    }
}