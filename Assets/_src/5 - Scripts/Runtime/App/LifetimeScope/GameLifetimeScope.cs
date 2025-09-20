using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using YohohoChobotov.Game;
using YohohoChobotov.Game.Items;
using YohohoChobotov.Game.Levels;
using YohohoChobotov.Game.Player;

namespace YohohoChobotov.App
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<MonoBehaviour> controllers = new();

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterControllers(builder);
            RegisterFactories(builder);

            builder.RegisterEntryPoint<EcsStartup>().AsSelf();
        }

        private void RegisterControllers(IContainerBuilder builder)
        {
            foreach (var controller in controllers) 
            {
                builder.RegisterInstance(controller).AsSelf();
            }
        }

        private static void RegisterFactories(IContainerBuilder builder)
        {
            builder.Register<IFactory<LevelView>, LevelFactory>(Lifetime.Scoped);
            builder.Register<IFactory<UnitView>,PlayerFactory>(Lifetime.Scoped);
            builder.Register<IFactory<Item>, ItemsFactory>(Lifetime.Scoped);
        }
    }
}