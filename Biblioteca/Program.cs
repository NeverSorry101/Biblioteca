using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data.SqlClient;
using System;
using Biblioteca_db_manager.Classi;
using Biblioteca_db_manager;
using static Biblioteca_db_manager.Classi.Enumeratori;

internal class Program
{

    private static void Main(string[] args)
    {
        Libro item = new Libro("Guerra e pace", "Tolstoj", false , null ,null ,"64564545455424" , Generi.Narrativa , null );
        Sql_actions.Insert(item);

    }

}

