using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XML130.EasyData
{
    public class LoaiCD
    {
        public static DataTable ChiDinh()
        {
            var table = new DataTable();
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("name", typeof(string));

            table.Rows.Add(0, @"Chỉ định thường");
            table.Rows.Add(1, @"Chỉ định hình ảnh");
            return table;
        }
    }
}
