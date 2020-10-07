namespace MouseScrollCoordinator
{
    class ScrollRecord
    {
        public readonly float Value;
        public readonly float Time;

        public ScrollRecord(float value, float time)
        {
            this.Value = value;
            this.Time = time;
        }
    }
}
