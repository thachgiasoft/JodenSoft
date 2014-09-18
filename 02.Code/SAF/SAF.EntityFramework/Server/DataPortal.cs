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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult LoadDataSet(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="dataSet"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult LoadDataSetByTransaction(string connectionName, DataSet dataSet, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteDataset(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteDatasetByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteScalar(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteScalarByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQuery(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQueryByTransaction(string connectionName, string commandText, params object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlScrips"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQuery(string connectionName, SqlCommandObject[] sqlScrips)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="sqlScrips"></param>
        /// <returns></returns>
        public OperationResult ExecuteNonQueryByTransaction(string connectionName, SqlCommandObject[] sqlScrips)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionName"></param>
        /// <param name="pageInfo"></param>
        /// <param name="commandText"></param>
        /// <param name="parameterValues"></param>
        /// <returns></returns>
        public OperationResult ExecuteDatasetByPage(string connectionName, PageInfo pageInfo, string commandText, object[] parameterValues)
        {
            try
            {
                Database db = DatabaseFactory.CreateDatabase(connectionName);
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