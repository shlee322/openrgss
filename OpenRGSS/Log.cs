namespace OpenRGSS
{
    public class Log
    {
        public static void Debug(string log)
        {
            if (Engine.GetInstance().Debug)
            {
                LogForm.GetInstance().Debug(log);
            }
        }
    }
}
