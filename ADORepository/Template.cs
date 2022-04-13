using CommonDataRapository;
using System.Data.SqlClient;

namespace ADORepository
{
    public abstract class Template<T> : CommonRepository<T>
    {
        protected SqlConnection objConn = null;
        protected SqlCommand objCommand = null;

        public Template(string ConnectionString) : base(ConnectionString)
        {
        }

        private void Open()
        {
            objConn = new SqlConnection(ConnectionString);
            objConn.Open();
            objCommand = new SqlCommand();
            objCommand.Connection = objConn;
        }

        private void Close() => objConn.Close();

        protected abstract void ExecuteCommand(T entity);
        protected abstract List<T> ExecuteCommand();

        public void Execute(T query) //Insert/Update/Delete
        {
            Open();
            ExecuteCommand(query);
            Close();
        }

        public List<T> Execute() //select
        {
            List<T> res;
            Open();
            res = ExecuteCommand();
            Close();
            return res;
        }

        public override void Save() //save
        {
            foreach (T o in Res)
            {
                Execute(o);
            }
        }
        public override List<T> GetAll()
        {
            return Execute();
        }

    }
}