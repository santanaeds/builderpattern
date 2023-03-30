namespace SearchAPI.Models
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(string msg = null, Exception innerEx = null) : base(msg, innerEx)
        {
        }
    }
}
