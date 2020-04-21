namespace SFF.Logic
{
    [System.Serializable]
    public class AboveMaxRentCap : System.Exception
    {
        public AboveMaxRentCap() { }
        public AboveMaxRentCap(string message) : base(message) { }
        public AboveMaxRentCap(string message, System.Exception inner) : base(message, inner) { }
        protected AboveMaxRentCap(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}