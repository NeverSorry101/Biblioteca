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
        Libro item1 = new Libro("1984", "George Orwell", true, null , null, "9780451524935", Generi.Fantascienza, null );
        Sql_actions.Insert(item1);
        Libro item2 = new Libro("Il Signore degli Anelli", "J.R.R. Tolkien", false, null, null, "9780544003415", Generi.Fantasy, null);
        Sql_actions.Insert(item2);
        Libro item3 = new Libro("Orgoglio e pregiudizio", "Jane Austen", true,null , null, "9780141439518", Generi.Romantico, null);
        Sql_actions.Insert(item3);
        Libro item4 = new Libro("Il nome della rosa", "Umberto Eco", false, null, null, "9780156001311", Generi.Giallo, null);
        Sql_actions.Insert(item4);
        Libro item5 = new Libro("Cento anni di solitudine", "Gabriel García Márquez", true, null , null, "9780307389732", Generi.Biografico, null);
        Sql_actions.Insert(item5);

    }

}

