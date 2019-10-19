namespace MvvmFrame.Entities
{
    /// <summary>
    /// Error detail
    /// </summary>
    public class MvvmFrameErrorDetail
    {
        /// <summary>
        /// Code error
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Message error
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Returns a string that represents the current object
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Code: '{Code}' Message: '{Message}'";
        }
    }
}
