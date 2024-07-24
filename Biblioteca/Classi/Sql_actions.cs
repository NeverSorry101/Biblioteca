using Biblioteca_db_manager.Classi;
using Biblioteca_db_manager.Interfacce;
using System.Data.SqlClient;
namespace Biblioteca_db_manager
{
    internal class Sql_actions: IMediaAction
    {
        private static string connectionString = "Server=V-SQLSRV01;Database=_Minisini;User Id=minidevelopment;Password=minidevelopment;";
        public static void CreateBiblioteca()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {

                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query = "CREATE TABLE MediaItems (  Id INT PRIMARY KEY IDENTITY(1,1), Titolo NVARCHAR(255) NOT NULL,Autore NVARCHAR(255) NOT NULL, Status BIT NOT NULL DEFAULT 0 , datadiprestito datetime, datadirestituzione datetime); " +
                                    "CREATE TABLE Libri ( Id INT UNIQUE NOT NULL, AnnoPubblicazione INT , ISBN NVARCHAR(20) NOT NULL, Genere INT , FOREIGN KEY (Id) REFERENCES MediaItems(Id) );" +
                                    "CREATE TABLE Ebooks ( Id INT UNIQUE NOT NULL, FormatoFile NVARCHAR(50) , DimensioneFile INT ,  FOREIGN KEY (Id) REFERENCES MediaItems(Id) );" +
                                    "CREATE TABLE Audiobooks (Id INT UNIQUE NOT NULL,Durata TIME ,Narratore NVARCHAR(255),FOREIGN KEY (Id) REFERENCES MediaItems(Id));" +
                                    "CREATE TABLE Log ( Id int NULL, Datetime datetime NULL, Action int NULL ); ";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Transaction = tran;

                    command.ExecuteNonQuery();

                    tran.Commit();
                    Console.WriteLine("Create con successo\n");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public static void Prestito(int id_item, int DataDiPrestito)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {

                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"SELECT * FROM MediaItems WHERE Id = {id_item}";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    SqlDataReader reader = command1.ExecuteReader();
                    if (Convert.ToInt32(reader.GetValue(0)) == 0)
                    {
                        string query2 = $"UPDATE MediaItems SET Status = 1 , datadiprestito = '{DataDiPrestito}'";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.ExecuteNonQuery();
                        tran.Commit();
                        Console.WriteLine("Inerito con successo\n");
                    }
                    else { Console.WriteLine("L'item selezionato risulta già in prestito\n"); }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
        public static void Prestito(int id_item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {

                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"SELECT * FROM MediaItems WHERE Id = {id_item}";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    SqlDataReader reader = command1.ExecuteReader();
                    if (Convert.ToInt32(reader.GetValue(0)) == 0)
                    {
                        string query2 = $"UPDATE MediaItems SET Status = 1 , datadiprestito = '{DateTime.Now}'";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.ExecuteNonQuery();
                        tran.Commit();
                        Console.WriteLine("Inerito con successo\n");
                    }
                    else { Console.WriteLine("L'item selezionato risulta già in prestito\n"); }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
        public static void Restituzione(int id_item, int DataDiRestituzione)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {

                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"SELECT * FROM MediaItems WHERE Id = {id_item}";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    SqlDataReader reader = command1.ExecuteReader();
                    if (Convert.ToInt32(reader.GetValue(0)) == 1)
                    {
                        string query2 = $"UPDATE MediaItems SET Status = 0 , datadirestituzione = '{DataDiRestituzione}'";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.ExecuteNonQuery();
                        tran.Commit();
                        Console.WriteLine("Inerito con successo\n");
                    }
                    else { Console.WriteLine("L'item selezionato risulta già consegnato\n"); }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public static void Restituzione(int id_item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {

                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"SELECT * FROM MediaItems WHERE Id = {id_item}";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    SqlDataReader reader = command1.ExecuteReader();
                    if (Convert.ToInt32(reader.GetValue(0)) == 1)
                    {
                        string query2 = $"UPDATE MediaItems SET Status = 0 , datadirestituzione = '{DateTime.Now}'";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.ExecuteNonQuery();
                        tran.Commit();
                        Console.WriteLine("Inerito con successo\n");
                    }
                    else { Console.WriteLine("L'item selezionato risulta già consegnato\n"); }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
        public static void Insert(Libro item)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"INSERT INTO MediaItems OUTPUT inserted.id VALUES ( '{item.Titolo}', '{item.Autore}','{item.Status}', '{item.DataDiPrestito}' , '{item.DataDiRestituzione}'); ";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Transaction = tran;
                    var id = command1.ExecuteScalar();
                    string query2 = $"INSERT INTO Libri VALUES ('{id}', '{item.Anno}', '{item.ISBN}', '{item.Genere}')";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Transaction = tran;
                    command2.ExecuteNonQuery();
                    tran.Commit();
                    Console.WriteLine("Inserito con successo\n");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
        }
        public static void Insert(Audiobook item)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"INSERT INTO MediaItems OUTPUT inserted.id VALUES ( '{item.Titolo}', '{item.Autore}','{item.Status}', '{item.DataDiPrestito}' , '{item.DataDiRestituzione}'); ";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Transaction = tran;
                    var id = command1.ExecuteScalar();
                    string query2 = $"INSERT INTO Audiobooks VALUES ('{id}', '{item.Durata}', '{item.Narratore}')";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Transaction = tran;
                    command2.ExecuteNonQuery();
                    tran.Commit();
                    Console.WriteLine("Inserito con successo\n");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }


        }
        public static void Insert(Ebook item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"INSERT INTO MediaItems OUTPUT inserted.id VALUES ( '{item.Titolo}', '{item.Autore}','{item.Status}', '{item.DataDiPrestito}' , '{item.DataDiRestituzione}'); ";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Transaction = tran;
                    var id = command1.ExecuteScalar();
                    string query2 = $"INSERT INTO Ebooks VALUES ('{id}', '{item.FormatoFile}', '{item.DimensioneFile}')";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Transaction = tran;
                    command2.ExecuteNonQuery();
                    tran.Commit();
                    Console.WriteLine("Inserito con successo\n");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }

        }
        public static void Update(int id_item, Libro item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"UPDATE  MediaItems SET   Titolo = '{item.Titolo}', Autore = '{item.Autore}',Status = '{item.Status}', DataDiPresti = '{item.DataDiPrestito}' , DataDiPrestito = '{item.DataDiRestituzione}' WHERE id = {id_item} ";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Transaction = tran;
                    var id = command1.ExecuteNonQuery();
                    string query2 = $"UPDATE  Libri SET '{id}', Anno = '{item.Anno}', ISBN = '{item.ISBN}', Genere = '{item.Genere}' WHERE id = {id_item}";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Transaction = tran;
                    command2.ExecuteNonQuery();
                    tran.Commit();
                    Console.WriteLine("Inserito con successo\n");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public static void Update(int id_item, Ebook item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"UPDATE  MediaItems SET   Titolo = '{item.Titolo}', Autore = '{item.Autore}',Status = '{item.Status}', DataDiPrestito = '{item.DataDiPrestito}' , DataDiRestituzione = '{item.DataDiRestituzione}' WHERE id = {id_item} ";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Transaction = tran;
                    var id = command1.ExecuteNonQuery();
                    string query2 = $"UPDATE  Ebook SET '{id}', formatofile = '{item.FormatoFile}', Dimensionefile = '{item.DimensioneFile}' WHERE id = {id_item}";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Transaction = tran;
                    command2.ExecuteNonQuery();
                    tran.Commit();
                    Console.WriteLine("Inserito con successo\n");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

        }
        public static void Update(int id_item, Audiobook item)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query1 = $"UPDATE  MediaItems SET   Titolo = '{item.Titolo}', Autore = '{item.Autore}',Status = '{item.Status}', DataDiPrestito = '{item.DataDiPrestito}' , DataDiRestituzione = '{item.DataDiRestituzione}' WHERE id = {id_item} ";
                    SqlCommand command1 = new SqlCommand(query1, connection);
                    command1.Transaction = tran;
                    var id = command1.ExecuteNonQuery();
                    string query2 = $"UPDATE  Ebook SET '{id}', durata = '{item.Durata}', Narratore = '{item.Narratore}' WHERE id = {id_item}";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Transaction = tran;
                    command2.ExecuteNonQuery();
                    tran.Commit();
                    Console.WriteLine("Inserito con successo\n");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public static void Delete(int id_item, Enumeratori.Tipo tipo)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            using (connection)
            {
                connection.Open();
                SqlTransaction tran = connection.BeginTransaction();
                try
                {
                    string query = $"DELETE FROM MediaItems where id = {id_item}";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Transaction = tran;
                    command.ExecuteNonQuery();

                    if (tipo != Enumeratori.Tipo.MediaItems)
                    {
                        string query2 = $"DELETE FROM {Enum.GetName(typeof(Enumeratori.Tipo), tipo)} where id = {id_item}";
                        SqlCommand command2 = new SqlCommand(query2, connection);
                        command2.Transaction = tran;
                        command2.ExecuteNonQuery();
                    }

                    tran.Commit();
                    Console.WriteLine("Elemento eliminato con successo\n");
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
        public static void GetInfo(int id_item, Enumeratori.Tipo tipo)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string query = $"SELECT*FROM MediaItems as m Inner join {Enum.GetName(typeof(Enumeratori.Tipo), tipo)} as s ON s.id = m.id WHERE s.id = {id_item}";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Transaction = tran;
                    SqlDataReader reader = command.ExecuteReader();
                    for (int i = 0; i < reader.FieldCount; i++) if (i != 6) Console.Write($"{reader.GetName(i),-27}");
                    Console.Write("\n");
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++) if (i != 6) Console.Write($"{reader.GetValue(i),-27}");
                        Console.Write("\n");
                    }
                    reader.Close();
                    tran.Commit();
                }
                catch (Exception ex) { 
                    tran.Rollback();
                    Console.WriteLine(ex.Message);  
                }
                
            }
        }
        public static void ShowItems( Enumeratori.Tipo tipo)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            using (conn)
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                try
                {
                    string query = $"SELECT*FROM MediaItems as m Inner join {Enum.GetName(typeof(Enumeratori.Tipo), tipo)} as s ON s.id = m.id ";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Transaction = tran;
                    SqlDataReader reader = command.ExecuteReader();
                    for (int i = 0; i < reader.FieldCount; i++) if (i != 6) Console.Write($"{reader.GetName(i),-27}");
                    Console.Write("\n");
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++) if (i != 6) Console.Write($"{reader.GetValue(i),-27}");
                        Console.Write("\n");
                    }
                    reader.Close();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}