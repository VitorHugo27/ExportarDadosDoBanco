using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using ClosedXML.Excel;

namespace ExportarDoBanco
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conn.StrCon))
                {
                    string valueTable = SelectTable.Text.ToString();
                    string valueColun = SelectColuns.Text.ToString();

                    cn.Open();
                    var sqlQuery = "SELECT * FROM [" + valueTable + "] WHERE " + valueColun + " = '" + textBuscar.Text + "'";
                    using (SqlDataAdapter da = new SqlDataAdapter(sqlQuery, cn))
                    {
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            if (dt.Rows.Count > 0)
                            {
                                dataGridView1.DataSource = dt;
                            }
                            else
                            {
                                MessageBox.Show("Não possui valor!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    toolStripStatusLabel1.Text = "Dados carregados com sucesso!";
                    statusStrip1.Refresh();
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ops, houve uma falha!";
                statusStrip1.Refresh();
                MessageBox.Show("Falha ao tentar conectar\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Bom Vindo!";

            toLoad();
        }

        private void toLoad()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conn.StrCon))
                {
                    cn.Open();
                    var sqlQuery = "SELECT TABLE_NAME FROM information_schema.tables";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string tableName = reader["TABLE_NAME"].ToString();
                                    if (tableName != "sysdiagrams")
                                    {
                                        SelectTable.Items.Add(tableName);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhum dado encontrado!");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ops, houve uma falha!";
                statusStrip1.Refresh();
                MessageBox.Show("Falha ao tentar conectar\n\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(Conn.StrCon))
                {
                    string valueTable = SelectTable.Text.ToString();
                    cn.Open();

                    var sqlQuery = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS " +
                        "WHERE TABLE_NAME = '" + valueTable + "' ORDER BY ORDINAL_POSITION;";


                    using (SqlCommand cmd = new SqlCommand(sqlQuery, cn))
                    {

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var previousSelection = SelectColuns.SelectedItem;
                            SelectColuns.Items.Clear();

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    SelectColuns.Items.Add(reader["COLUMN_NAME"].ToString());
                                }

                                if (SelectColuns.Items.Contains(previousSelection))
                                {
                                    SelectColuns.SelectedItem = previousSelection;
                                }
                                else
                                {
                                    SelectColuns.SelectedIndex = -1;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Nenhum dado encontrado!");
                            }
                            toolStripStatusLabel1.Text = "";
                            toolStripStatusLabel1.Text = "Tebela carregada com suscesso!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "Ops, houve uma falha!";
                statusStrip1.Refresh();
                MessageBox.Show("Falha ao tentar conectar\n\n" + ex.Message);
            }
        }


        private void SelectColuns_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Não há dados para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
            string fileName = "dados.xlsx";
            string filePath = Path.Combine(downloadsPath, fileName);

            ExportToXlsx(dataGridView1, filePath);

            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.Text = "Relatório gerado!";
            MessageBox.Show("Relatório gerado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ExportToXlsx(DataGridView dataGridView, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sheet1");

                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dataGridView.Columns[i].HeaderText;
                }

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        var cellValue = dataGridView.Rows[i].Cells[j].Value;
                        worksheet.Cell(i + 2, j + 1).Value = cellValue?.ToString();
                    }
                }

                workbook.SaveAs(filePath);
            }
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;

            dataGridView1.Rows.Clear();

            textBuscar.Text = string.Empty;

            toolStripStatusLabel1.Text = "";
            toolStripStatusLabel1.Text = "Grid limpo!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sourceFile = @"P:\Projetinhos\ExportarDoBanco\ExportarDoBanco\Manual\Manual.pdf";

            string downloadDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\Manual.pdf";

            try
            {
                File.Copy(sourceFile, downloadDirectory);
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel1.Text = "Manual baixado!";
                MessageBox.Show("Manual baixado com suscesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "";
                toolStripStatusLabel1.Text = "Erro!";
                MessageBox.Show("Ocorreu um erro\n\n Talvez já tenha uma copia no diretorio download", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
