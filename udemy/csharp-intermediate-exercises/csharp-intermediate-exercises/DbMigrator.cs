using System;

namespace csharp_intermediate_exercises
{
    public class DbMigrator
    {
        private readonly Logger _logger;

        public DbMigrator(Logger logger)
        {
            _logger = logger;
        } 

        public void Migrate(){
            _logger.Log("Migrating DB");
        }
    }

}
