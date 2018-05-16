using HospitalDatabase.Data;
using HospitalDatabaseInitializer;


namespace HospitalStartUp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            using (HospitalContext db = new HospitalContext())
            {
                db.Database.EnsureCreated();
                
                
            }
        }
    }
}
