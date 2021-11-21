using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VideoBD.Model;

namespace VideoBD.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Video>().Wait();
        }

        //Guardar Datos
        public Task<int> SaveVideoAsync(Video videos)
        {
            if (videos.id != 0)
            {
                return db.UpdateAsync(videos);
            }
            else
            {
                return db.InsertAsync(videos);
            }
        }

        //Muestar todos los datos de la BD
        public Task<List<Video>> GetVideoAsync()
        {
            return db.Table<Video>().ToListAsync();
        }

        //Muestar todos los datos de la BD por ID
        public Task<Video> GetVideoByNameAsync(String name)
        {
            return db.Table<Video>().Where(a => a.nombre == name).FirstOrDefaultAsync();
        }

        //Borrar datos
        public Task<int> DeleteVideoAsync(Video videos)
        {
            return db.DeleteAsync(videos);
        }

    }
}
