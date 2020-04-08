namespace SimAntics.Engine
{
    /// <summary>
    /// Compatibility class 
    /// </summary>
    public class VMThread : VMInstruction { }
    
    /// <summary>
    /// Handles instruction sets
    /// </summary>
    public class VMInstruction
    {
        public static int MAX_USER_ACTIONS = 20;

        public VMContext Context;
        
        public bool IsCheck;
    }
}