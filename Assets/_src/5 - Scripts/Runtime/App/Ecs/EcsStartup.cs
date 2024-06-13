using System;
using Leopotam.Ecs;
using VContainer.Unity;
using YohohoChobotov.Ecs.Systems;
using YohohoChobotov.Game;
using YohohoChobotov.Services;

namespace YohohoChobotov.App
{
    public class EcsStartup : ITickable, IFixedTickable, ILateTickable, IDisposable
    {
        private EcsWorld world;

        private EcsSystems update;
        private EcsSystems fixedUpdate;
        private EcsSystems lateUpdate;

        private readonly IScoreService scoreService;

        private readonly GameState gameState;
        private readonly FixedJoystick joystick;

        public EcsStartup(
            IScoreService scoreService,
            GameState gameState,
            FixedJoystick joystick)
        {
            this.scoreService = scoreService;
            this.gameState = gameState;
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
                .Add(new CreateLevelSystem())
                .Add(new CreatePlayerSystem())
                .Add(new CameraInitSystem())
                
                .Add(new PlayerVelocitySystem())
                .Add(new PlayerAnimatorSystem())

                .Add(new CreateItemSystem())

                .Inject(world)
                .Inject(gameState)

                .Init();
        }

        private void InitFixedUpdateEcs()
        {
            fixedUpdate = new EcsSystems(world);

            fixedUpdate
                .Add(new PlayerInputSystem())
                .Add(new RotationSystem())
                .Add(new MoveSystem())

                .Inject(world)
                .Inject(gameState)
                .Inject(joystick)

                .Init();
        }

        private void InitLateUpdateEcs()
        {
            lateUpdate = new EcsSystems(world);

            lateUpdate
                .Add(new PickupItemDistanceSystem())
                .Add(new PickupItemSystem())
                .Add(new DropZoneDistanceSystem())
                .Add(new DropItemSystem())

                .Inject(world)
                .Inject(gameState)
                .Inject(scoreService)

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