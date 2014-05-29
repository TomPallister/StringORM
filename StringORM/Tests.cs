using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using StringORM.Infrastructure.Enums;
using Xunit;

namespace StringORM
{
    public class Tests
    {
        #region DynamicTests

        [Fact]
        public void get_dynamic_isnt_null_with_default_connection()
        {
            var dyn = "SELECT * FROM dbo.Names".GetDynamic();
        }

        [Fact]
        public void get_dynamic_isnt_null_with_specific_connection()
        {
            var dyn = "SELECT * FROM dbo.Names".GetDynamic(DataBase.Default);
        }

        [Fact]
        public void get_dynamic_isnt_null_with_parameter_with_default_connection()
        {
            var dyn =
                "SELECT * FROM dbo.Names where Name = @Name".GetDynamic(new SqlParameter("@Name", "SomeNameWithId"));
        }

        [Fact]
        public void get_dynamic_isnt_null_with_parameter_with_specific_connection()
        {
            var dyn = "SELECT * FROM dbo.Names where Name = @Name".GetDynamic(DataBase.Default,
                new SqlParameter("@Name", "SomeNameWithId"));
        }

        [Fact]
        public void get_dynamic_isnt_null_with_list_of_parameters_with_default_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            var dyn = "SELECT * FROM dbo.Names where Name = @Name AND Id = @Id".GetDynamic(sqlParameters);
        }

        [Fact]
        public void get_dynamic_isnt_null_with_list_of_parameters_with_specific_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            var stopWatch = Stopwatch.StartNew();
            var dyn =
                "SELECT * FROM dbo.Names where Name = @Name AND Id = @Id".GetDynamic(DataBase.Default, sqlParameters);
            stopWatch.Stop();
            Console.WriteLine("This db call took {0} milliseconds and returned n/a objects", stopWatch.ElapsedMilliseconds);

        }

        [Fact]
        public void get_dynamics_isnt_null_with_default_connection()
        {
            var dyn = "SELECT * FROM dbo.Names".GetDynamics();
        }

        [Fact]
        public void get_dynamics_isnt_null_with_specific_connection()
        {
            var dyn = "SELECT * FROM dbo.Names".GetDynamics(DataBase.Default);
        }

        [Fact]
        public void get_dynamics_isnt_null_with_parameter_with_default_connection()
        {
            var dyn =
                "SELECT * FROM dbo.Names where Name = @Name".GetDynamics(new SqlParameter("@Name", "SomeNameWithId"));
        }

        [Fact]
        public void get_dynamics_isnt_null_with_parameter_with_specific_connection()
        {
            var dyn = "SELECT * FROM dbo.Names where Name = @Name".GetDynamics(DataBase.Default,
                new SqlParameter("@Name", "SomeNameWithId"));
        }

        [Fact]
        public void get_dynamics_isnt_null_with_list_of_parameters_with_default_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            var dyn = "SELECT * FROM dbo.Names where Name = @Name AND Id = @Id".GetDynamics(sqlParameters);
        }

        [Fact]
        public void get_dynamics_isnt_null_with_list_of_parameters_with_specific_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            var stopWatch = Stopwatch.StartNew();
            var dyn =
                "SELECT * FROM dbo.Names where Name = @Name AND Id = @Id".GetDynamics(DataBase.Default, sqlParameters);
            stopWatch.Stop();
            Console.WriteLine("This db call took {0} milliseconds and returned n/a objects", stopWatch.ElapsedMilliseconds);

        }

        #endregion

        #region DataTableTests

        [Fact]
        public void get_data_table_isnt_null_with_default_connection()
        {
            DataTable table = "SELECT * FROM dbo.Names".GetDataTable();
            table.Should().NotBeNull();
        }

        [Fact]
        public void get_data_table_isnt_null_with_specific_connection()
        {
            DataTable table = "SELECT * FROM dbo.Names".GetDataTable(DataBase.Default);
            table.Should().NotBeNull();
        }

        [Fact]
        public void get_data_table_isnt_null_with_parameter_with_default_connection()
        {
            DataTable table =
                "SELECT * FROM dbo.Names where Name = @Name".GetDataTable(new SqlParameter("@Name", "SomeParamName"));
            table.Should().NotBeNull();
        }

        [Fact]
        public void get_data_table_isnt_null_with_parameter_with_specific_connection()
        {
            DataTable table = "SELECT * FROM dbo.Names where Name = @Name".GetDataTable(DataBase.Default,
                new SqlParameter("@Name", "SomeParamName"));
            table.Should().NotBeNull();
        }

        [Fact]
        public void get_data_table_isnt_null_with_list_of_parameters_with_default_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            DataTable table = "SELECT * FROM dbo.Names where Name = @Name".GetDataTable(sqlParameters);
            table.Should().NotBeNull();
        }

        [Fact]
        public void get_data_table_isnt_null_with_list_of_parameters_with_specific_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            DataTable table = "SELECT * FROM dbo.Names where Name = @Name".GetDataTable(DataBase.Default, sqlParameters);
            table.Should().NotBeNull();
        }

        #endregion

        #region ScalarTests

        [Fact]
        public void get_scalar_isnt_null_with_default_connection()
        {
            object scalar = "SELECT * FROM dbo.Names".GetScalar();
            scalar.Should().NotBeNull();
        }

        [Fact]
        public void get_scalar_isnt_null_with_specific_connection()
        {
            object scalar = "SELECT * FROM dbo.Names".GetScalar(DataBase.Default);
            scalar.Should().NotBeNull();
        }

        [Fact]
        public void get_scalar_isnt_null_with_parameter_with_default_connection()
        {
            object scalar =
                "SELECT * FROM dbo.Names where Name = @Name".GetScalar(new SqlParameter("@Name", "SomeParamName"));
            scalar.Should().NotBeNull();
        }

        [Fact]
        public void get_scalar_isnt_null_with_parameter_with_specific_connection()
        {
            object scalar = "SELECT * FROM dbo.Names where Name = @Name".GetScalar(DataBase.Default,
                new SqlParameter("@Name", "SomeParamName"));
            scalar.Should().NotBeNull();
        }

        [Fact]
        public void get_scalar_isnt_null_with_list_of_parameters_with_default_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            object scalar = "SELECT * FROM dbo.Names where Name = @Name and Id = @Id".GetScalar(sqlParameters);
            scalar.Should().NotBeNull();
        }

        [Fact]
        public void get_scalar_isnt_null_with_list_of_parameters_with_specific_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            object scalar = "SELECT * FROM dbo.Names where Name = @Name and Id = @Id".GetScalar(DataBase.Default,
                sqlParameters);
            scalar.Should().NotBeNull();
        }

        #endregion

        #region ExecuteTests

        [Fact]
        public void can_execute_without_exception_with_default_connection()
        {
            @"INSERT INTO Names (Name)
            VALUES ('SomeName')".Execute();
        }

        [Fact]
        public void can_execute_without_exception_with_specific_connection()
        {
            @"INSERT INTO Names (Name)
            VALUES ('SomeName')".Execute(DataBase.Default);
        }

        [Fact]
        public void can_execute_without_exception_using_parameters_with_default_connection()
        {
            "INSERT INTO Names (Name) VALUES (@Name)".Execute(new SqlParameter("@Name", "SomeParamName"));
        }

        [Fact]
        public void can_execute_without_exception_using_parameters_with_specific_connection()
        {
            "INSERT INTO Names (Name) VALUES (@Name)".Execute(DataBase.Default,
                new SqlParameter("@Name", "SomeParamName"));
        }

        [Fact]
        public void can_execute_without_exception_using_list_of_parameters_with_default_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            "INSERT INTO Names (Name, Id) VALUES (@Name, @Id)".Execute(sqlParameters);
        }

        [Fact]
        public void can_execute_without_exception_using_list_of_parameters_with_specific_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeNameWithId"),
                new SqlParameter("@Id", 1)
            };
            "INSERT INTO Names (Name, Id) VALUES (@Name, @Id)".Execute(DataBase.Default, sqlParameters);
        }

        #endregion

        #region ObjectReflectionTests

        [Fact]
        public void can_get_object_isnt_null_with_default_connection()
        {
            var name = "SELECT * FROM dbo.Names".GetObject<Names>();
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_object_isnt_null_with_specific_connection()
        {
            var name = "SELECT * FROM dbo.Names".GetObject<Names>(DataBase.Default);
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_object_isnt_null_with_parameter_and_default_connection()
        {
            var name =
                "SELECT * FROM dbo.Names where Name = @Name".GetObject<Names>(new SqlParameter("@Name", "SomeName"));
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_object_isnt_null_with_parameter_and_specfific_connection()
        {
            var name = "SELECT * FROM dbo.Names where Name = @Name".GetObject<Names>(DataBase.Default,
                new SqlParameter("@Name", "SomeName"));
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_object_isnt_null_with_list_of_parameters_and_default_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeName"),
                new SqlParameter("@Id", 1)
            };

            var name = "SELECT * FROM dbo.Names where Name = @Name".GetObject<Names>(sqlParameters);
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_object_isnt_null_with_list_of_parameters_and_specific_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeName"),
                new SqlParameter("@Id", 1)
            };

            var name = "SELECT * FROM dbo.Names where Name = @Name".GetObject<Names>(DataBase.Default, sqlParameters);
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_objects_isnt_null_with_default_connection()
        {
            List<Names> name = "SELECT * FROM dbo.Names".GetObjects<Names>();
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_objects_isnt_null_with_specific_connection()
        {
            List<Names> name = "SELECT * FROM dbo.Names".GetObjects<Names>(DataBase.Default);
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_objects_isnt_null_with_parameter_and_default_connection()
        {
            List<Names> name =
                "SELECT * FROM dbo.Names where Name = @Name".GetObjects<Names>(new SqlParameter("@Name", "SomeName"));
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_objects_isnt_null_with_parameter_and_specfific_connection()
        {
            List<Names> name = "SELECT * FROM dbo.Names where Name = @Name".GetObjects<Names>(DataBase.Default,
                new SqlParameter("@Name", "SomeName"));
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_objects_isnt_null_with_list_of_parameters_and_default_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeName"),
                new SqlParameter("@Id", 1)
            };

            List<Names> name = "SELECT * FROM dbo.Names where Name = @Name".GetObjects<Names>(sqlParameters);
            name.Should().NotBeNull();
        }

        [Fact]
        public void can_get_objects_isnt_null_with_list_of_parameters_and_specific_connection()
        {
            var sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@Name", "SomeName"),
                new SqlParameter("@Id", 1)
            };
            var stopWatch = Stopwatch.StartNew();
            List<Names> name = "SELECT * FROM dbo.Names where Name = @Name".GetObjects<Names>(DataBase.Default,
                sqlParameters);
            stopWatch.Stop();
            name.Should().NotBeNull();
            Console.WriteLine("This db call took {0} milliseconds and returned {1} objects", stopWatch.ElapsedMilliseconds, name.Count);
        }

        #endregion
    }

    #region Test Class

    public class Names
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }

    #endregion
}