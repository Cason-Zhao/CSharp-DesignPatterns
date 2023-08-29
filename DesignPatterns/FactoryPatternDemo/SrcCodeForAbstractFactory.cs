using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPatternDemo
{
    /// <summary>
    /// 源码中的抽象工厂模式
    ///     https://learn.microsoft.com/zh-cn/dotnet/api/system.data.common.dbproviderfactory?view=netframework-4.0
    /// </summary>
    public class SrcCodeForAbstractFactory
    {
        /// <summary>
        /// 抽象工厂的抽象定义
        /// </summary>
        private System.Data.Common.DbProviderFactory _abstractFactory;

        /// <summary>
        /// 具体工厂：针对SQLServer的实现
        ///     System.Data.dll/System.Data.SqlClient.SqlClientFactory
        /// </summary>
        private System.Data.SqlClient.SqlClientFactory _concreteFactorySqlClient;// SqlServer
        /// <summary>
        /// 具体工厂：针对支持OLE DB的数据库 的实现
        ///     System.Data.dll/System.Data.OleDb.OleDbFactory
        /// </summary>
        private System.Data.OleDb.OleDbFactory _concreteFactoryOleDb;// OLE DB的数据 如：Access

        /// <summary>
        /// 具体工厂：针对Oracle数据库 的实现
        ///     System.Data.OracleClient.dll/System.Data.OracleClient.OracleClientFactory
        /// </summary>
        private System.Data.OracleClient.OracleClientFactory _concreteFactoryOracle;// Oracle

        /// <summary>
        /// 具体工厂：针对支持ODBC的数据库 的实现
        ///     System.Data.dll/System.Data.Odbc.OdbcFactory
        /// </summary>
        private System.Data.Odbc.OdbcFactory _concreteFactoryOdbc;

        private System.Data.EntityClient.EntityProviderFactory _concreteFactoryEntity;
    }
}
