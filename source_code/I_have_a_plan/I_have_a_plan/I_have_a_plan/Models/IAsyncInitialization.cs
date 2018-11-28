namespace I_have_a_plan.Models
{
    public interface IAsyncInitialization
    {
        /// <summary>
        /// The result of the asynchronous initialization of this instance.
        /// </summary>
        System.Threading.Tasks.Task Initialization { get; }
    }
}