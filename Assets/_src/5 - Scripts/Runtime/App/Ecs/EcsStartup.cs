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

        public EcsStartup(GameLogic gameLogic, FixedJoystick joystick)
        {
            this.gameLogic = gameLogic;
            this.joystick = joystick;

            world = new EcsWorld();

            InitUpdateEcs();
            InitFixedUpdateEcs();
            InitLateUpdateEcs();
        }

        public void CreateEntity<T>(in T component) where T : struct 
        {
            world.NewEntity().Replace(in component);
        }

        private void InitUpdateEcs()
        {
            update = new EcsSystems(world);

            update
                .Add(new PlayerVelocitySystem())
                .Add(new PlayerAnimatorSystem())

                .Add(new CreateItemSystem())

                .Inject(gameLogic.LevelFactory)
                .Inject(gameLogic.PlayerFactory)
                .Inject(gameLogic.ItemsFactory)
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

        private bool TryDestroySystem(ref EcsSystems systems)
        {
            if (systems != null)
            {
                systems.Destroy();
                systems = null;

                return true;
            }

            return false;
        }

        public void Dispose()
        {
            TryDestroySystem(ref update);
            TryDestroySystem(ref fixedUpdate);
            TryDestroySystem(ref lateUpdate);

            world.Destroy();
            world = null;
        }
    }
}