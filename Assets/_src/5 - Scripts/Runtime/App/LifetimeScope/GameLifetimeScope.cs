using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace YohohoChobotov.App
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private List<MonoBehaviour> controllers = new();

        protected override void Configure(IContainerBuilder builder)
        {
            RegisterControllers(builder);
        }

        private void RegisterControllers(IContainerBuilder builder)
        {
            Debug.Log($"Game : Start Register Controllers");

            foreach (var controller in controllers) 
            {
                Debug.Log($"Register : {controller.name}");

                builder.RegisterInstance(controller).AsSelf();
            }

            builder.RegisterEntryPoint<EcsStartup>().AsSelf();

            Debug.Log($"Game : End Register Controllers");
        }
    }
}