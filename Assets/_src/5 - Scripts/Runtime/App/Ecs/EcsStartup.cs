using System;
using Leopotam.Ecs;
using VContainer.Unity;

namespace YohohoChobotov.App
{
    public class EcsStartup : ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private EcsWorld world;

        private EcsSystems update;
        private EcsSystems fixedUpdate;
        private EcsSystems lateUpdate;

        public EcsStartup()
        {
            world = new EcsWorld();

            InitUpdateEcs();
            InitFixedUpdateEcs();
            InitLateUpdateEcs();
        }

        private void InitUpdateEcs()
        {
            update = new EcsSystems(world);

            update.Init();
        }

        private void InitFixedUpdateEcs()
        {
            fixedUpdate = new EcsSystems(world);

            fixedUpdate.Init();
        }

        private void InitLateUpdateEcs()
        {
            lateUpdate = new EcsSystems(world);

            lateUpdate.Init();
        }

        public void Tick()
        {
            update?.Run();
        }

        public void FixedTick()
        {
            fixedUpdate?.Run();
        }

        public void LateTick()
        {
            lateUpdate?.Run();
        }

        public void Dispose()
        {
            if (update != null) 
            {
                update.Destroy();
                update = null;
            }

            if (fixedUpdate != null) 
            {
                fixedUpdate.Destroy();
                fixedUpdate = null;
            }

            if (lateUpdate != null) 
            {
                lateUpdate.Destroy();
                lateUpdate = null;
            }

            world.Destroy ();
            world = null;
        }
    }
}