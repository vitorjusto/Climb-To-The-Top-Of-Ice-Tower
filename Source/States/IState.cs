namespace IceGame.Source.States
{
    public interface IState
    {
        public bool Process(double delta);
        public void Start();
    }
}