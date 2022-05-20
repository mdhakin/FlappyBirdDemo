using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FlappyBirdDemo.Web.Models
{
    public class GameManager
    {
        private readonly int _gravity = 2;

        public event EventHandler MainLoopCompleted;
        public BirdModel Bird { get; set; }
        public List<PipeModel> Pipes { get; set; }
        public bool IsRunning { get; set; } = false;
        public GameManager()
        {
            Bird = new BirdModel();
            Pipes = new List<PipeModel>();

        }

        public async void MainLoop()
        {
            IsRunning = true;
            while (IsRunning)
            {

                MoveObjects();
                checkForCollisions();

                ManagePipes();

                MainLoopCompleted?.Invoke(this, EventArgs.Empty);
                await Task.Delay(20);
            }
        }

        public void Jump()
        {
            if (IsRunning)
            {
                Bird.Jump();
            }
        }

        public void StartGame()
        {
            if (!IsRunning)
            {
                Bird = new BirdModel();
                Pipes = new List<PipeModel>();
                MainLoop();
            }
            
        }
        public void checkForCollisions()
        {
            if (Bird.IsOnGround())
            {
                GameOver();
            }
        }

        public void ManagePipes()
        {
            if (!Pipes.Any() || Pipes.Last().DistanceFromLeft <= 250)
            {
                Pipes.Add(new PipeModel());

                if (Pipes.First().IsOffScreen())
                {
                    Pipes.Remove(Pipes.First());
                }
            }
        }
        public void MoveObjects()
        {
            Bird.Fall(_gravity);


            foreach (var Pipe in Pipes)
            {
                Pipe.Move();
            }
        }

        public void GameOver()
        {
            IsRunning = false;
        }

    }
}
