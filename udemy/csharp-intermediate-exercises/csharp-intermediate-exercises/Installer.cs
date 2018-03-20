namespace csharp_intermediate_exercises
{
    public class Installer
    {
        // example of composition allowing loose coupling
        private readonly Logger _logger;

        public Installer(Logger logger)
        {
            this._logger = logger;
        }

        public void Install()
        {
            _logger.Log("Installing application...");
        }
    }
}
