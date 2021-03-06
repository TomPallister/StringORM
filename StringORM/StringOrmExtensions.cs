﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using StringORM.Infrastructure;
using StringORM.Infrastructure.Enums;

namespace StringORM
{
    public static class StringOrmExtensions
    {
        public static void ExecuteCommand(string command, DataBase dataBase, List<SqlParameter> sqlParameters)
        {
            if (sqlParameters != null)
            {
                using (var sqlQuery = new SqlQuery(dataBase, command, sqlParameters))
                {
                    sqlQuery.Execute();
                }
            }
            else
            {
                using (var sqlQuery = new SqlQuery(dataBase, command))
                {
                    sqlQuery.Execute();
                }
            }
        }

        public static void Execute(this string command)
        {
            ExecuteCommand(command, DataBase.Default, null);
        }

        public static void Execute(this string command, DataBase dataBase)
        {
            ExecuteCommand(command, dataBase, null);
        }

        public static void Execute(this string command, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            ExecuteCommand(command, DataBase.Default, sqlParameters);
        }

        public static void Execute(this string command, DataBase dataBase, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            ExecuteCommand(command, dataBase, sqlParameters);
        }

        public static void Execute(this string command, List<SqlParameter> sqlParameters)
        {
            ExecuteCommand(command, DataBase.Default, sqlParameters);
        }

        public static void Execute(this string command, DataBase dataBase, List<SqlParameter> sqlParameters)
        {
            ExecuteCommand(command, dataBase, sqlParameters);
        }

        public static dynamic GetDynamicObject(string command, DataBase dataBase, List<SqlParameter> sqlParameters)
        {
            if (sqlParameters != null)
            {
                using (var sqlQuery = new SqlQuery(dataBase, command, sqlParameters))
                {
                    SqlDataReader reader = sqlQuery.GetDataReader();
                    var expandoObject = new ExpandoObject() as IDictionary<string, object>;
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            expandoObject.Add(reader.GetName(i), reader[i]);
                        }
                        return expandoObject;
                    }
                    return expandoObject;
                }
            }
            using (var sqlQuery = new SqlQuery(dataBase, command))
            {
                SqlDataReader reader = sqlQuery.GetDataReader();
                var expandoObject = new ExpandoObject() as IDictionary<string, object>;
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        expandoObject.Add(reader.GetName(i), reader[i]);
                    }
                    return expandoObject;
                }
                return expandoObject;
            }
        }

        public static dynamic GetDynamic(this string command)
        {
            return GetDynamicObject(command, DataBase.Default, null);
        }

        public static dynamic GetDynamic(this string command, DataBase dataBase)
        {
            return GetDynamicObject(command, dataBase, null);
        }

        public static dynamic GetDynamic(this string command, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetDynamicObject(command, DataBase.Default, sqlParameters);
        }

        public static dynamic GetDynamic(this string command, DataBase dataBase, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetDynamicObject(command, dataBase, sqlParameters);
        }

        public static dynamic GetDynamic(this string command, List<SqlParameter> sqlParameters)
        {
            return GetDynamicObject(command, DataBase.Default, sqlParameters);
        }

        public static dynamic GetDynamic(this string command, DataBase dataBase,
            List<SqlParameter> sqlParameters)
        {
            return GetDynamicObject(command, dataBase, sqlParameters);
        }

        public static DataTable GetTable(string command, DataBase dataBase, List<SqlParameter> sqlParameters)
        {
            if (sqlParameters != null)
            {
                using (var sqlQuery = new SqlQuery(dataBase, command, sqlParameters))
                {
                    return sqlQuery.GetDataTable();
                }
            }
            using (var sqlQuery = new SqlQuery(dataBase, command))
            {
                return sqlQuery.GetDataTable();
            }
        }

        public static DataTable GetDataTable(this string command)
        {
            return GetTable(command, DataBase.Default, null);
        }

        public static DataTable GetDataTable(this string command, DataBase dataBase)
        {
            return GetTable(command, dataBase, null);
        }

        public static DataTable GetDataTable(this string command, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetTable(command, DataBase.Default, sqlParameters);
        }

        public static DataTable GetDataTable(this string command, DataBase dataBase, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetTable(command, dataBase, sqlParameters);
        }

        public static DataTable GetDataTable(this string command, List<SqlParameter> sqlParameters)
        {
            return GetTable(command, DataBase.Default, sqlParameters);
        }

        public static DataTable GetDataTable(this string command, DataBase dataBase, List<SqlParameter> sqlParameters)
        {
            return GetTable(command, dataBase, sqlParameters);
        }

        public static object GetScalarValue(string command, DataBase dataBase, List<SqlParameter> sqlParameters)
        {
            if (sqlParameters != null)
            {
                using (var sqlQuery = new SqlQuery(dataBase, command, sqlParameters))
                {
                    return sqlQuery.GetScalar();
                }
            }
            using (var sqlQuery = new SqlQuery(dataBase, command))
            {
                return sqlQuery.GetScalar();
            }
        }

        public static object GetScalar(this string command)
        {
            return GetScalarValue(command, DataBase.Default, null);
        }

        public static object GetScalar(this string command, DataBase dataBase)
        {
            return GetScalarValue(command, dataBase, null);
        }

        public static object GetScalar(this string command, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetScalarValue(command, DataBase.Default, sqlParameters);
        }

        public static object GetScalar(this string command, DataBase dataBase, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetScalarValue(command, dataBase, sqlParameters);
        }

        public static object GetScalar(this string command, List<SqlParameter> sqlParameters)
        {
            return GetScalarValue(command, DataBase.Default, sqlParameters);
        }

        public static object GetScalar(this string command, DataBase dataBase, List<SqlParameter> sqlParameters)
        {
            return GetScalarValue(command, DataBase.Default, sqlParameters);
        }

        public static T GetObjectUsingReflection<T>(string command, DataBase dataBase, List<SqlParameter> sqlParameters)
            where T : new()
        {
            if (sqlParameters != null)
            {
                using (var sqlQuery = new SqlQuery(dataBase, command, sqlParameters))
                {
                    SqlDataReader reader = sqlQuery.GetDataReader();
                    return SetUp<T>(reader);
                }
            }
            using (var sqlQuery = new SqlQuery(dataBase, command))
            {
                SqlDataReader reader = sqlQuery.GetDataReader();
                return SetUp<T>(reader);
            }
        }

        public static T GetObject<T>(this string command) where T : new()
        {
            return GetObjectUsingReflection<T>(command, DataBase.Default, null);
        }

        public static T GetObject<T>(this string command, DataBase dataBase) where T : new()
        {
            return GetObjectUsingReflection<T>(command, dataBase, null);
        }

        public static T GetObject<T>(this string command, SqlParameter sqlParameter) where T : new()
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetObjectUsingReflection<T>(command, DataBase.Default, sqlParameters);
        }

        public static T GetObject<T>(this string command, DataBase dataBase, SqlParameter sqlParameter) where T : new()
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetObjectUsingReflection<T>(command, dataBase, sqlParameters);
        }

        public static T GetObject<T>(this string command, List<SqlParameter> sqlParameters) where T : new()
        {
            return GetObjectUsingReflection<T>(command, DataBase.Default, sqlParameters);
        }

        public static T GetObject<T>(this string command, DataBase dataBase, List<SqlParameter> sqlParameters)
            where T : new()
        {
            return GetObjectUsingReflection<T>(command, dataBase, sqlParameters);
        }

        public static List<T> GetObjectsUsingReflection<T>(string command, DataBase dataBase,
            List<SqlParameter> sqlParameters) where T : new()
        {
            if (sqlParameters != null)
            {
                using (var sqlQuery = new SqlQuery(dataBase, command, sqlParameters))
                {
                    SqlDataReader reader = sqlQuery.GetDataReader();
                    return SetUpList<T>(reader);
                }
            }
            using (var sqlQuery = new SqlQuery(dataBase, command))
            {
                SqlDataReader reader = sqlQuery.GetDataReader();
                return SetUpList<T>(reader);
            }
        }

        public static List<T> GetObjects<T>(this string command) where T : new()
        {
            return GetObjectsUsingReflection<T>(command, DataBase.Default, null);
        }

        public static List<T> GetObjects<T>(this string command, DataBase dataBase) where T : new()
        {
            return GetObjectsUsingReflection<T>(command, dataBase, null);
        }

        public static List<T> GetObjects<T>(this string command, SqlParameter sqlParameter) where T : new()
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetObjectsUsingReflection<T>(command, DataBase.Default, sqlParameters);
        }

        public static List<T> GetObjects<T>(this string command, DataBase dataBase, SqlParameter sqlParameter)
            where T : new()
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetObjectsUsingReflection<T>(command, dataBase, sqlParameters);
        }

        public static List<T> GetObjects<T>(this string command, List<SqlParameter> sqlParameters) where T : new()
        {
            return GetObjectsUsingReflection<T>(command, DataBase.Default, sqlParameters);
        }

        public static List<T> GetObjects<T>(this string command, DataBase dataBase, List<SqlParameter> sqlParameters)
            where T : new()
        {
            return GetObjectsUsingReflection<T>(command, dataBase, sqlParameters);
        }

        private static T SetUp<T>(SqlDataReader reader) where T : new()
        {
            T obj = default(T);
            while (reader.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (
                    PropertyInfo prop in
                        obj.GetType().GetProperties().Where(prop => !Equals(reader[prop.Name], DBNull.Value)))
                {
                    prop.SetValue(obj, reader[prop.Name], null);
                }
                return obj;
            }
            return obj;
        }

        private static List<T> SetUpList<T>(SqlDataReader reader)
        {
            var list = new List<T>();
            while (reader.Read())
            {
                var obj = Activator.CreateInstance<T>();
                foreach (
                    PropertyInfo prop in
                        obj.GetType().GetProperties().Where(prop => !Equals(reader[prop.Name], DBNull.Value)))
                {
                    prop.SetValue(obj, reader[prop.Name], null);
                }
                list.Add(obj);
            }
            return list;
        }

        public static dynamic GetDynamicObjects(string command, DataBase dataBase, List<SqlParameter> sqlParameters)
        {
            var list = new List<dynamic>();

            if (sqlParameters != null)
            {
                using (var sqlQuery = new SqlQuery(dataBase, command, sqlParameters))
                {
                    SqlDataReader reader = sqlQuery.GetDataReader();
                    while (reader.Read())
                    {
                        var expandoObject = new ExpandoObject() as IDictionary<string, object>;

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            expandoObject.Add(reader.GetName(i), reader[i]);
                        }
                        list.Add(expandoObject);
                    }
                    return list;
                }
            }
            using (var sqlQuery = new SqlQuery(dataBase, command))
            {
                SqlDataReader reader = sqlQuery.GetDataReader();
                while (reader.Read())
                {
                    var expandoObject = new ExpandoObject() as IDictionary<string, object>;

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        expandoObject.Add(reader.GetName(i), reader[i]);
                    }
                    list.Add(expandoObject);
                }
                return list;
            }
        }

        public static dynamic GetDynamics(this string command)
        {
            return GetDynamicObjects(command, DataBase.Default, null);
        }

        public static dynamic GetDynamics(this string command, DataBase dataBase)
        {
            return GetDynamicObjects(command, dataBase, null);
        }

        public static dynamic GetDynamics(this string command, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetDynamicObjects(command, DataBase.Default, sqlParameters);
        }

        public static dynamic GetDynamics(this string command, DataBase dataBase, SqlParameter sqlParameter)
        {
            var sqlParameters = new List<SqlParameter> {sqlParameter};
            return GetDynamicObjects(command, dataBase, sqlParameters);
        }

        public static dynamic GetDynamics(this string command, List<SqlParameter> sqlParameters)
        {
            return GetDynamicObjects(command, DataBase.Default, sqlParameters);
        }

        public static dynamic GetDynamics(this string command, DataBase dataBase,
            List<SqlParameter> sqlParameters)
        {
            return GetDynamicObjects(command, dataBase, sqlParameters);
        }
    }
}