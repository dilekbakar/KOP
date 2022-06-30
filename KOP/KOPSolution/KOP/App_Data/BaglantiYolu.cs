using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BaglantiYolu
{
	public BaglantiYolu()
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
