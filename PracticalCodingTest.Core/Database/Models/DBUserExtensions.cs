//--------------------------------------------------------------------------------------------------------
// Project: PracticalCodingTest
// Author: Jason Peixoto
// Version: v1.0
// Copyright: IOTEcoSystem
// May not use this code without granted permission from Jason Peixoto
//--------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using PracticalCodingTest.Models;

namespace PracticalCodingTest.Core.Database.Models
{
    static public partial class DBModels
    {
        static object object_lock = new Object();

        /// <summary>
        /// Insert the specified record.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="record">Record.</param>
        static public int Insert(this DBUser record)
        {
            int result = 0;
            lock (object_lock)
            {
                result = DBUtils.DBConn.Insert(record);
            }
            return result;
        }

        /// <summary>
        /// Insert the specified record.
        /// </summary>
        /// <returns>The insert.</returns>
        /// <param name="record">Record.</param>
        static public int Insert(this UsersModel record)
        {
            return Insert(new DBUser(record));
        }

        /// <summary>
        /// Gets the DBUS ers.
        /// </summary>
        /// <returns>The DBUS ers.</returns>
        static public IEnumerable<DBUser> GetAllDBUSers()
        {
            IEnumerable<DBUser> records = null;
            lock (object_lock)
            {
                records = DBUtils.DBConn.Query<DBUser>("SELECT * FROM DBUser ORDER BY FullName");
            }
            return records;
        }
    }
}

