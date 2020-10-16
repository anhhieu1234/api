using DAL.Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public partial class KhachHangRepository : IKhachHangRepository
    {
        private IDatabaseHelper _dbHelper;
        public KhachHangRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        
        public List<KhachHangModel> GetDataAll()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_kh_get_data");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachHangModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public KhachHangModel Getbyid( string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_kh_get_data_by_id","@id",id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachHangModel>().FirstOrDefault(); 
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
