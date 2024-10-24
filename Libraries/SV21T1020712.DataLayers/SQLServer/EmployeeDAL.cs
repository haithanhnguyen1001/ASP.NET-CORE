using System;
using System.Collections.Generic;
using Dapper;
using SV21T1020712.DomainModels;


namespace SV21T1020712.DataLayers.SQLServer
{
    public class EmployeeDAL : BaseDAL, ICommonDAL<Employee>
    {
        public EmployeeDAL(string connectionString) : base(connectionString)
        {
        }

        public int Add(Employee data)
        {
            int id = 0;
            using (var connection = OpenConnection())
            {
                var sql = @"insert into Employees(FullName,BirthDate,Phone,Email,Address,Password,Photo,IsWorking)
                    values(@FullName,@BirthDate,@Phone,@Email,@Address,@Password,@Photo,@IsWorking);
                    select SCOPE_IDENTITY()";

                var parameters = new
                {
                    FullName = data.FullName ?? "",
                    BirthDate = data.BirthDate,
                    Phone = data.Phone,
                    Email = data.Email,
                    Address = data.Address,
                    Password = data.Password,
                    Photo = data.Photo
                };
                //Thực thi câu lệnh SQL
                id = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return id;

        }

        public int Count(string searchValue = "")
        {
            int count = 0;
            searchValue = $"%{searchValue}%";
            using (var connection = OpenConnection())
            {
                var sql = @"SELECT count(*)
                            from Employees
                            WHERE (FullName like @searchValue)";
                var parameters = new
                {
                    searchValue
                };
                count = connection.ExecuteScalar<int>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text);
                connection.Close();
            }
            return count;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee? Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool InUsed(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> List(int page = 1, int pageSize = 0, string searchValue = "")
        {
            List<Employee> data = new List<Employee>();
            searchValue = $"%{searchValue}%";
            using (var connection = OpenConnection())
            {
                var sql = @"SELECT *
                            from (
                                select *, ROW_NUMBER() over(order by FullName) AS RowNumber
                                from Employees
                                WHERE (FullName like @searchValue)
                            ) as t
                            where (@pageSize=0) or  (t.RowNumber BETWEEN (@page - 1) * @pageSize + 1 and @page * @pageSize)
                            ORDER BY RowNumber";
                var parameters = new
                {
                    page,
                    pageSize,
                    searchValue
                };
                data = connection.Query<Employee>(sql: sql, param: parameters, commandType: System.Data.CommandType.Text).ToList();
                connection.Close();
            }
            return data;
        }

        public bool Update(Employee data)
        {
            throw new NotImplementedException();
        }
    }
}