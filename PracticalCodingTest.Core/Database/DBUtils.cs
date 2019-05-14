//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System;
using System.IO;
using PracticalCodingTest.Core.Database.Models;

namespace PracticalCodingTest.Core.Database
{
    public class DBUtils
    {
        public static readonly string DatabaseName = "database.db3";
        private static SQLite.SQLiteConnection _Database;

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the DBC onn.
        /// </summary>
        /// <value>The DBC onn.</value>
        /// ------------------------------------------------------------------------------------------
        public static SQLite.SQLiteConnection DBConn
        {
            get
            {
                if (_Database == null)
                {
                    _Database = new SQLite.SQLiteConnection(DatabaseFilePath);
                    _Database.CreateTable<DBUser>();
                }
                return _Database;
            }
        }

        /// ------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the database file path.
        /// </summary>
        /// <value>The database file path.</value>
        /// ------------------------------------------------------------------------------------------
        public static string DatabaseFilePath
        {
            get
            {
#if __ANDROID__
                string libraryPath = Android.App.Application.Context.FilesDir.AbsolutePath;
#elif __IOS__
                // we need to put in /Library/ on iOS5.1 to meet Apple's iCloud terms
                string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
                string libraryPath = System.IO.Path.Combine(documentsPath, "../Library/");
#else
                string libraryPath = "./";
#endif
                string path = Path.Combine(libraryPath, DatabaseName);
                return path;
            }
        }
    }
}
