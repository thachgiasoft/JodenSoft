using System;
using SAF.EntityFramework.Server;
using System.Data;
using System.Data.Common;
using SAF.EntityFramework.Server.Hosts;
using SAF.Foundation;

namespace SAF.EntityFramework.Server
{
    /// <summary>
    /// 数据访问门户
    /// </summary>
    public class DataPortal : IDataPortalServer
    {
        public OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                {
                    db.LoadDataSet(cmd, dataSet);
                    return new OperationResult() { Data = true, IsSucess = true };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult LoadDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                {
                    db.LoadDataSet(cmd, dataSet, tableNames);
                    return new OperationResult() { Data = true, IsSucess = true };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var connection = db.GetNewOpenConnection())
                {
                    using (var trans = connection.BeginTransaction())
                    {
                        using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                        {
                            try
                            {
                                db.LoadDataSet(cmd, dataSet, trans);
                                trans.Commit();
                                return new OperationResult() { Data = true, IsSucess = true };
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult LoadDataSetByTransaction(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var connection = db.GetNewOpenConnection())
                {
                    using (var trans = connection.BeginTransaction())
                    {
                        using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                        {
                            try
                            {
                                db.LoadDataSet(cmd, dataSet, tableNames, trans);
                                trans.Commit();
                                return new OperationResult() { Data = true, IsSucess = true };
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult LoadReportDataSet(string serviceName, string connectionName, DataSet dataSet, string[] tableNames, string commandText, params object[] parameterValues)
        {
            try
            {
                if(commandText.IsEmpty())
                    return new OperationResult() { Data = true, IsSucess = true };

                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var connection = db.GetNewOpenConnection())
                {
                    using (var trans = connection.BeginTransaction())
                    {
                        using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                        {
                            try
                            {
                                db.LoadDataSet(cmd, dataSet, tableNames, trans);
                                trans.Rollback();
                                return new OperationResult() { Data = true, IsSucess = true };
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteDataset(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                {
                    var result = db.ExecuteDataSet(cmd);
                    return new OperationResult() { Data = result, IsSucess = true };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteDatasetByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var connection = db.GetNewOpenConnection())
                {
                    using (var trans = connection.BeginTransaction())
                    {
                        using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                        {
                            try
                            {
                                var result = db.ExecuteDataSet(cmd, trans);
                                trans.Commit();
                                return new OperationResult() { Data = result, IsSucess = true };
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteScalar(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                {
                    var result = db.ExecuteScalar(cmd);
                    return new OperationResult() { Data = result, IsSucess = true };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteScalarByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var connection = db.GetNewOpenConnection())
                {
                    using (var trans = connection.BeginTransaction())
                    {
                        using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                        {
                            try
                            {
                                var result = db.ExecuteScalar(cmd, trans);
                                trans.Commit();
                                return new OperationResult() { Data = result, IsSucess = true };
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteNonQuery(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                {
                    var result = db.ExecuteNonQuery(cmd);
                    return new OperationResult() { Data = result, IsSucess = true };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var connection = db.GetNewOpenConnection())
                {
                    using (var trans = connection.BeginTransaction())
                    {
                        using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                        {
                            try
                            {
                                var result = db.ExecuteNonQuery(cmd, trans);
                                trans.Commit();
                                return new OperationResult() { Data = result, IsSucess = true };
                            }
                            catch
                            {
                                trans.Rollback();
                                throw;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteNonQuery(string serviceName, string connectionName, SqlCommandObject[] sqlScrips)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                int result = 0;
                foreach (var item in sqlScrips)
                {
                    using (var cmd = db.GetSqlStringCommandFromSqlCommandObject(item))
                    {
                        result += db.ExecuteNonQuery(cmd);
                    }
                }
                return new OperationResult() { Data = result, IsSucess = true };
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteNonQueryByTransaction(string serviceName, string connectionName, SqlCommandObject[] sqlScrips)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var connection = db.GetNewOpenConnection())
                {
                    using (var trans = connection.BeginTransaction())
                    {
                        try
                        {
                            int result = 0;
                            foreach (var item in sqlScrips)
                            {
                                using (var cmd = db.GetSqlStringCommandFromSqlCommandObject(item))
                                {
                                    result += db.ExecuteNonQuery(cmd, trans);
                                }
                            }
                            trans.Commit();
                            return new OperationResult() { Data = result, IsSucess = true };
                        }
                        catch
                        {
                            trans.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

        public OperationResult ExecuteDatasetByPage(string serviceName, string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(serviceName, connectionName);
                using (var cmd = db.GetSqlStringCommand(commandText, parameterValues))
                {
                    var result = db.ExecuteDatasetByPage(cmd, pageInfo);
                    return new OperationResult() { Data = result, IsSucess = true };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult() { Message = ex.GetAllMessage(), IsSucess = false };
            }
        }

    }
}