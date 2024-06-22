namespace Server.Data.Services
{
    public class TaskService
    {
        private AppDbContext _contexct;

        public TaskService(AppDbContext contexct)
        {
            _contexct = contexct;
        }
    }
}
