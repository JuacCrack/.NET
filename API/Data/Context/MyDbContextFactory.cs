using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context
{
    public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext> //ESTA CLASE IMPLEMENTA UNA INTERFAZ QUE UTILIZA EL CONTEXTO DE BASE DE DATOS
    {
        public MyDbContext CreateDbContext(string[] args)//NUEVA INSTANCIA DE DB CONTEXT
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseMySql("Server=bbhujhpfzymrbxzyuzlz-mysql.services.clever-cloud.com;Database=bbhujhpfzymrbxzyuzlz;User ID=uqd1kja8gacl8ibd;Password=1BXM8tjXjUMpBvfCMcKn;");
            //UTILIZAMOS EL OPTIONSBUILDER PARA CONECTARNOS A UNA BASE DE DATOS MYSQL MEDIANTE UNA CADENA DE CONEXION
            return new MyDbContext(optionsBuilder.Options);
        }
    }
}