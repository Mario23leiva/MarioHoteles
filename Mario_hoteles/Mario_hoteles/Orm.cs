using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario_hoteles
{
    public static class Orm
    {
        public static hoteles_entities entitites = new hoteles_entities();



        public static string ErrorMessage(SqlException sqlException)
        {
            string message;

            switch (sqlException.Number)
            {
                case 2:
                    message = "El servidor no esta operativo";
                    break;
                case 547:
                    message = "El registro tiene datos relacionados";
                    break;
                case 2601:
                    message = "El registro esta duplicado";
                    break;
                case 2627:
                    message = "El registro esta duplicado";
                    break;
                case 4060:
                    message = "No se puede abrir la base de datos";
                    break;
                case 18456:
                    message = "Error al iniciar la sesión";
                    break;
                default:
                    message = sqlException.Number + " - " + sqlException.Message;
                    break;
            }
            return message;
        }

        public static string MySaveChanges()
        {
            string messageError = "";

            try
            {
                entitites.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                SqlException sqlException = (SqlException)ex.InnerException.InnerException;
                messageError = ErrorMessage(sqlException);
                RejectedChanged();
            }

            return messageError;
        }


        public static void RejectedChanged()
        {
            foreach (DbEntityEntry item in entitites.ChangeTracker.Entries())
            {
                switch (item.State)
                {
                    case System.Data.Entity.EntityState.Detached:
                        break;
                    case System.Data.Entity.EntityState.Unchanged:
                        break;
                    case System.Data.Entity.EntityState.Added:
                        item.State = System.Data.Entity.EntityState.Detached;
                        break;
                    case System.Data.Entity.EntityState.Modified:
                        item.State = System.Data.Entity.EntityState.Unchanged;
                        break;
                    case System.Data.Entity.EntityState.Deleted:
                        item.Reload();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
