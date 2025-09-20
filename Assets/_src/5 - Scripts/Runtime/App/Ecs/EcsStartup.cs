using System;
using Leopotam.Ecs;
using VContainer.Unity;
using YohohoChobotov.Ecs.Systems;
using YohohoChobotov.Game;
using YohohoChobotov.Services;

namespace YohohoChobotov.App
{
    public class EcsStartup : ITickable, IFixedTickable, IDisposable
    {
        private EcsWorld world;

        private EcsSystems update;
        private EcsSystems fixedUpdate;

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
        }

        private void InitUpdateEcs()
        {
            update = new EcsSystems(world);

            update
                .Add(new CreateLevelSystem())
                .Add(new CreateUnitSystem())
                .Add(new CameraInitSystem())

                .Add(new MoveVelocitySystem())
                .Add(new AnimatorSystem())

                .Add(new CreateItemSystem())

                .Add(new PickupItemDistanceSystem())
                .Add(new PickupItemSystem())
                .Add(new DropZoneDistanceSystem())
                .Add(new DropItemSystem())

                .Inject(world)
                .Inject(gameState)
                .Inject(scoreService)

                .Init();
        }

        private void InitFixedUpdateEcs()
        {
            fixedUpdate = new EcsSystems(world);

            fixedUpdate
                .Add(new InputSystem())
                .Add(new RotationSystem())
                .Add(new MoveSystem())

                .Inject(world)
                .Inject(gameState)
                .Inject(joystick)

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

        private void DestroySystem(ref EcsSystems systems)
        {
            systems.Destroy();
            systems = null;
        }

        public void Dispose()
        {
            DestroySystem(ref update);
            DestroySystem(ref fixedUpdate);

            world.Destroy();
            world = null;
        }
    }
}