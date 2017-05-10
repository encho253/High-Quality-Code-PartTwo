using log4net;
using ProjectManagerSystem.Common.Contracts;

namespace ProjectManagerSystem.Common
{
    public class FileLogger : ILogger
    {
        private static ILog log;

        static FileLogger()
        {
            log = LogManager.GetLogger(typeof(FileLogger));
        }

        public void GetInfo(object mesage)
        {
            log.Info(mesage);
        }    
        
        public void ShowError(object mesage)
        {
            log.Error(mesage);
        }     
        
        public void ShowFatal(object mesage)
        {
            log.Fatal(mesage);
        }
    }
}
