namespace QuanlySinhVienApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var dataStore = new SchoolDataStore();
            var classDataAccess = new ClassDataAccess(dataStore);
            var studentDataAccess = new StudentDataAccess(dataStore);
            var classBusiness = new ClassBusiness(classDataAccess);
            var studentBusiness = new StudentBusiness(studentDataAccess, classBusiness);
            Application.Run(new srmquanlysinhvien());
        }
    }

    internal class ClassDataAccess
    {
        private SchoolDataStore dataStore;

        public ClassDataAccess(SchoolDataStore dataStore)
        {
            this.dataStore = dataStore;
        }
    }

    internal class SchoolDataStore
    {
        public SchoolDataStore()
        {

        }
    }

    internal class StudentBusiness
    {
        private StudentDataAccess studentDataAccess;
        private ClassBusiness classBusiness;

        public StudentBusiness(StudentDataAccess studentDataAccess, ClassBusiness classBusiness)
        {
            this.studentDataAccess = studentDataAccess;
            this.classBusiness = classBusiness;
        }
    }

    internal class ClassBusiness
    {
        private ClassDataAccess classDataAccess;

        public ClassBusiness(ClassDataAccess classDataAccess)
        {
            this.classDataAccess = classDataAccess;
        }
    }

    internal class StudentDataAccess
    {
        private SchoolDataStore dataStore;

        public StudentDataAccess(SchoolDataStore dataStore)
        {
            this.dataStore = dataStore;
        }
    }
}