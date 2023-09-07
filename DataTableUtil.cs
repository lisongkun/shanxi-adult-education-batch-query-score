using System.Data;
using System.Windows.Forms;

namespace ShanxiAdultEducationBatchQueryScore
{
    internal class DataTableUtil
    {
        /// <summary>
        /// 从dataGridView中获取DataTable对象
        /// </summary>
        /// <param name="dataGridView">dataGridView对象</param>
        /// <returns>dataTable</returns>
        public static DataTable GetDataTableFromDataGridView(DataGridView dataGridView)
        {
            var dataTable = new DataTable();

            // 添加列名
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                dataTable.Columns.Add(column.HeaderText);
            }

            // 添加行数据
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var dataRow = dataTable.NewRow();
                for (var i = 0; i < dataGridView.Columns.Count; i++)
                {
                    dataRow[i] = row.Cells[i].Value;
                }
                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }
    }
}
