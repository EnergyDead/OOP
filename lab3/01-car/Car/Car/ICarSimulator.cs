namespace CarSimulator
{
    public interface ICarSimulator
    {
        public void Info();
        public bool EngineOn();
        public bool EngineOff();
        public bool SetGear( int gear );
        public bool SetSpeed( int speed );
    }
}
