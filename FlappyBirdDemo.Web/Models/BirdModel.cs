namespace FlappyBirdDemo.Web.Models
{
    public class BirdModel
    {
        public int DistanceFromGround { get; set; } = 250;
        public int JumpStrength { get; set; } = 50;
        public void Fall(int gravity)
        {
            DistanceFromGround -= gravity;
        }

        public void Jump()
        {
            if (this.DistanceFromGround <= 530)
            {
                DistanceFromGround += this.JumpStrength;
            }
            
        }

        public bool IsOnGround()
        {

            return DistanceFromGround <= 0;
        }
    }
}
