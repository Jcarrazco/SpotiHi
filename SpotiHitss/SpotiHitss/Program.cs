using System;
using System.Data.SqlClient;
using System.Data;

namespace SpotiHitss
{
    class Program
    {
        static void Main(string[] args)
        {
            //Crea una clase de conexion a la BD con nombre de servidor,
            //se debe usar  \\ en vez de \ porque c# lo toma como identificador
            SqlConnection Conexion = new SqlConnection("server=HGDLAPCARRASCOJ\\SQLEXPRESS ; database=SpotiHitss ; integrated security = true");
            
            // SqlCommand Comando = new SqlCommand("SELECT * FROM Usuarios", Conexion);//se crea una instancia sqlcommand

            SqlCommand Comando = new SqlCommand("SP_ADD_User", Conexion);
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.Add("@Nam_2Put", SqlDbType.VarChar).Value = "Insertado2";
            Comando.Parameters.Add("@Mail_2Put", SqlDbType.VarChar).Value = "Insertado2@mail.com";
            Comando.Parameters.Add("@Pass_2Put", SqlDbType.VarChar).Value = "PassInsertado"; 
            Comando.Parameters.Add("@Type_Use", SqlDbType.VarChar).Value = "Premium";

            Conexion.Open();
            Console.WriteLine("Se abrió la conexión con el servidor SQL Server y se seleccionó la base de datos");

            Comando.ExecuteNonQuery();

            SqlCommand Comando2 = new SqlCommand("SELECT * FROM Usuarios", Conexion);

            

            SqlDataReader reader = Comando2.ExecuteReader();//se instancia un reader con el comando y executeReader

            if (reader.HasRows)//devuelve el valor true si hay datos aun por leer
            {
                while (reader.Read())//realiza el metodo de lectura
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}", reader.GetInt32(0),
                        reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            Conexion.Close();
            Console.WriteLine("Se cerró la conexión.");
            Console.ReadKey();
        }
    }
}
