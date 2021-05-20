using ContactDB;

namespace ContactRepository
{
    public class DatabaseManager
    {
        private static readonly ContactsContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new ContactsContext();
        }

        // Provide an accessor to the database
        public static ContactsContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}