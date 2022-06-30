using System;

/// <summary>
/// Summary description for Class1
/// </summary>

namespace KOP.App_Data
{
    public class BaglantiYolu
    {
        public BaglantiYolu() //class oluşturduk.Bu sayede bağlantı kuracağımız zaman her seferinde aynı şeyleri yazıp uğraşmaya gerek kalmayacak.Her yerden erişilebilir bu sınıfa.
        {
            //
            // TODO: Add constructor logic here
            //
        }
        string connectionString = @"Server=DESKTOP-8BBA3PH\SQLEXPRESS01;Database=kutuphanedb;User Id=sa; Password =123456 ; ";
        //public her yerden ulaşılabilir demek.
        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }
    }
}