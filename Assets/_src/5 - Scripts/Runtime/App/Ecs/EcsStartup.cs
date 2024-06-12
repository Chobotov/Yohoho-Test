using System;
using Leopotam.Ecs;
using VContainer.Unity;
using YohohoChobotov.Ecs.Systems;
using YohohoChobotov.Game;

namespace YohohoChobotov.App
{
    public class EcsStartup : ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private EcsWorld world;

        private EcsSystems update;
        private EcsSystems fixedUpdate;
        private EcsSystems lateUpdate;

        private readonly GameLogic gameLogic;
        private readonly FixedJoystick joystick;

        public EcsWorld World => world;

        public EcsStartup(
            GameLogic gameLogic,
            FixedJoystick joystick)
        {
            this.gameLogic = gameLogic;
            this.joystick = joystick;
            
            world = new EcsWorld();

            InitUpdateEcs();
            InitFixedUpdateEcs();
            InitLateUpdateEcs();
        }

        private void InitUpdateEcs()
        {
            update = new EcsSystems(world);

            update

                .Inject(world)

                .Init();
        }

        private void InitFixedUpdateEcs()
        {
            fixedUpdate = new EcsSystems(world);

            fixedUpdate
                .Add(new InputSystem())
                .Add(new RotationSystem())
                .Add(new MoveSystem())

                .Inject(gameLogic.PlayerFactory)
                .Inject(world)
                .Inject(joystick)

                .Init();
        }

        private void InitLateUpdateEcs()
        {
            lateUpdate = new EcsSystems(world);

            lateUpdate
                .Add(new InputClearSystem())

                .Init();
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