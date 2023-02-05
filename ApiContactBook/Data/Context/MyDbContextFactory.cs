using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {
        public MyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseMySql("Server=bbhujhpfzymrbxzyuzlz-mysql.services.clever-cloud.com;Database=bbhujhpfzymrbxzyuzlz;User ID=uqd1kja8gacl8ibd;Password=1BXM8tjXjUMpBvfCMcKn;");

            return new MyDbContext(optionsBuilder.Options);
        }
    }
}