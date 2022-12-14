using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Мебель
{
    class Report
    {
        private string fileNameTemplate;
        private string fileNameResult;
        private SaveFileDialog saveFileDialog;

        public Report(string fName, SaveFileDialog svg)
        {
            this.fileNameTemplate = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\АИС Магазина мягкой мебели\Reports\", fName);
            this.fileNameResult = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\АИС Магазина мягкой мебели\ReportsResult\", fName);
            this.saveFileDialog = svg;
        }

        public Report(string fName)
        {
            this.fileNameTemplate = Directory.GetCurrentDirectory() + @"\" + fName;
        }

        // замена строк
        private void ReplaceWordSub(string subToReplace, string text, Word.Document wordDoc)
        {
            var range = wordDoc.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: subToReplace, ReplaceWith: text);
        }

        // печать списания мебели
        public void PrintOffFurniture(Furniture furniture, Employee employee)
        {
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                Word.Document wordDocTemplate = wordApp.Documents.Open(FileName: this.fileNameTemplate, ReadOnly: false);

                ReplaceWordSub("{furnitureId}", furniture.Id.ToString(), wordDocTemplate);
                ReplaceWordSub("{furnitureName}", furniture.Name, wordDocTemplate);
                ReplaceWordSub("{furnitureQuantity}", furniture.Quantity.ToString(), wordDocTemplate);
                ReplaceWordSub("{furnitureRemarks}", furniture.Remarks, wordDocTemplate);
                ReplaceWordSub("{employeeFIO}", employee.FIO, wordDocTemplate);
                ReplaceWordSub("{date}", DateTime.Now.Date.ToString("d"), wordDocTemplate);

                wordDocTemplate.SaveAs(this.fileNameResult);
                wordDocTemplate.Close();

                Word.Document wordDocResult = wordApp.Documents.Open(FileName: this.fileNameResult, ReadOnly: false);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    wordDocResult.SaveAs(saveFileDialog.FileName);

                wordDocResult.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка." + ex.Message, "Ошибка.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wordApp.Quit();
            }
        }

        // печать лога(log) списания мебели
        public void PrintOffFurnitureLog(Furniture furniture, Employee employee)
        {
            using (FileStream writer = new FileStream(fileNameTemplate, FileMode.Append))
            {
                string text = DateTime.Now.ToString("d") + " | " + employee.FIO + " | " + furniture.Name + " | " + furniture.Quantity + " | " + furniture.Remarks + "\n";
                byte[] array = System.Text.Encoding.Default.GetBytes(text);

                writer.Write(array, 0, array.Length);
            }
        }

        // печать чека
        public void PrintCheque(Cheque cheque)
        {
            Employee employee = cheque.User.Employee;
            Client client = cheque.Client;
            List<ShopList> shopLists = new List<ShopList>(cheque.ShopLists);

            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                Word.Document wordDocTemplate = wordApp.Documents.Open(FileName: this.fileNameTemplate, ReadOnly: false);

                ReplaceWordSub("{chequeId}", cheque.Id.ToString(), wordDocTemplate);

                int tableImdex = 3;
                if (client.FIO != "Физическое лицо")
                {
                    string clientPassport = "Серия " + client.PassportSeries + " № " + client.PassportNumber +
                        ", выдан: " + client.PassportIssued + ", дата выдачи: " + client.PassportDate.ToString("d");
                    ReplaceWordSub("{clientFIO}", client.FIO, wordDocTemplate);
                    ReplaceWordSub("{clientPassport}", clientPassport, wordDocTemplate);
                    ReplaceWordSub("{clientPhone}", client.Phone, wordDocTemplate);
                }
                else
                {
                    wordDocTemplate.Tables[2].Delete();
                    tableImdex = 2;
                }

                ReplaceWordSub("{chequeEmployee}", employee.FIO, wordDocTemplate);
                ReplaceWordSub("{chequeAssembly}", cheque.Assembly == true ? "да" : "нет", wordDocTemplate);
                ReplaceWordSub("{chequeDelivery}", cheque.Delivery == true ? "да" : "нет", wordDocTemplate);
                ReplaceWordSub("{chequePayment}", cheque.Payment.Name, wordDocTemplate);
                ReplaceWordSub("{chequeSum}", cheque.Sum.ToString(), wordDocTemplate);

                ReplaceWordSub("{date}", DateTime.Now.ToString("d"), wordDocTemplate);

                Word.Table table = wordDocTemplate.Tables[tableImdex];
                if (shopLists.Count > 0)
                {

                    for (int i = 0; i < shopLists.Count; i++)
                    {
                        Word.Row row;
                        
                        if (i == 0)
                            row = table.Rows[1];
                        else
                            row = table.Rows.Add();

                        row.Cells[1].Range.Text = shopLists[i].Furniture.Name;
                        row.Cells[2].Range.Text = shopLists[i].Furniture.PriceOut.ToString("G") + '*' + shopLists[i].Quantity.ToString("G") + '(' + shopLists[i].Furniture.Unit.Name + ')';
                        row.Cells[3].Range.Text = (shopLists[i].Furniture.PriceOut * shopLists[i].Quantity / 100 * shopLists[i].Furniture.Discount).ToString("G") + "(Скидка)";

                        row = table.Rows.Add();

                        row.Cells[3].Range.Text = "Всего: " + shopLists[i].Sum.ToString("G");

                        row = table.Rows.Add();
                    }
                }
                else
                {
                    Word.Row row = table.Rows.Add();

                    row.Cells[1].Range.Text = "-";
                    row.Cells[2].Range.Text = "-";
                    row.Cells[3].Range.Text = "-";
                    row.Cells[4].Range.Text = "-";
                    row.Cells[5].Range.Text = "-";
                }

                wordDocTemplate.SaveAs(this.fileNameResult);
                wordDocTemplate.Close();

                Word.Document wordDocResult = wordApp.Documents.Open(FileName: this.fileNameResult, ReadOnly: false);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    wordDocResult.SaveAs(saveFileDialog.FileName);

                wordDocResult.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка." + ex.Message, "Ошибка.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wordApp.Quit();
            }
        }

        // печать заказа
        public void PrintOrder(Cheque order)
        {
            Employee employee = order.User.Employee;
            Client client = order.Client;
            List<ShopList> shopLists = new List<ShopList>(order.ShopLists);

            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                Word.Document wordDocTemplate = wordApp.Documents.Open(FileName: this.fileNameTemplate, ReadOnly: false);

                ReplaceWordSub("{chequeId}", order.Id.ToString(), wordDocTemplate);

                string clientPassport = "Серия " + client.PassportSeries + " № " + client.PassportNumber +
                    ", выдан: " + client.PassportIssued + ", дата выдачи: " + client.PassportDate.ToString("d");
                ReplaceWordSub("{clientFIO}", client.FIO, wordDocTemplate);
                ReplaceWordSub("{clientPassport}", clientPassport, wordDocTemplate);
                ReplaceWordSub("{clientPhone}", client.Phone, wordDocTemplate);
                ReplaceWordSub("{chequeDate}", string.IsNullOrEmpty(order.Remarks) ? "отсутствует" : order.Remarks, wordDocTemplate);
                ReplaceWordSub("{chequeEmployee}", employee.FIO, wordDocTemplate);
                ReplaceWordSub("{chequeAssembly}", order.Assembly == true ? "да" : "нет", wordDocTemplate);
                ReplaceWordSub("{chequeDelivery}", order.Delivery == true ? "да" : "нет", wordDocTemplate);
                ReplaceWordSub("{chequePayment}", order.Payment.Name, wordDocTemplate);
                ReplaceWordSub("{chequeSum}", order.Sum.ToString(), wordDocTemplate);
                ReplaceWordSub("{clientFIO}", client.FIO, wordDocTemplate);
                ReplaceWordSub("{chequeEmployee}", employee.FIO, wordDocTemplate);
                ReplaceWordSub("{date}", DateTime.Now.ToString("d"), wordDocTemplate);

                Word.Table table = wordDocTemplate.Tables[3];
                if (shopLists.Count > 0)
                {
                    for (int i = 0; i < shopLists.Count; i++)
                    {
                        Word.Row row = table.Rows.Add();

                        row.Cells[1].Range.Text = shopLists[i].Furniture.Name;
                        row.Cells[2].Range.Text = shopLists[i].Furniture.PriceOut.ToString();
                        row.Cells[3].Range.Text = shopLists[i].Furniture.Discount.ToString() + '%';
                        row.Cells[4].Range.Text = shopLists[i].Quantity.ToString();
                        row.Cells[5].Range.Text = shopLists[i].Furniture.Unit.Name;
                        row.Cells[6].Range.Text = shopLists[i].Sum.ToString();
                    }
                }
                else
                {
                    Word.Row row = table.Rows.Add();

                    row.Cells[1].Range.Text = "-";
                    row.Cells[2].Range.Text = "-";
                    row.Cells[3].Range.Text = "-";
                    row.Cells[4].Range.Text = "-";
                    row.Cells[5].Range.Text = "-";
                    row.Cells[6].Range.Text = "-";
                }
                
                wordDocTemplate.SaveAs(this.fileNameResult);
                wordDocTemplate.Close();

                Word.Document wordDocResult = wordApp.Documents.Open(FileName: this.fileNameResult, ReadOnly: false);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    wordDocResult.SaveAs(saveFileDialog.FileName);

                wordDocResult.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка." + ex.Message, "Ошибка.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wordApp.Quit();
            }
        }

        // печать заказов за период
        public void PrintChequeTime(List<Cheque> cheques, DateTime dateStart, DateTime dateEnd)
        {
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                Word.Document wordDocTemplate = wordApp.Documents.Open(FileName: this.fileNameTemplate, ReadOnly: false);
                Word.Table table = wordDocTemplate.Tables[wordDocTemplate.Tables.Count];

                decimal allSum = 0;
                decimal allSumByPriceIn = 0;
                if (cheques.Count > 0)
                {
                    for (int i = 0; i < cheques.Count; i++)
                    {
                        Word.Row row = table.Rows.Add();

                        row.Cells[1].Range.Text = cheques[i].Id.ToString();
                        row.Cells[2].Range.Text = cheques[i].Date.ToString("d");
                        row.Cells[3].Range.Text = cheques[i].User.Employee.FIO;
                        row.Cells[4].Range.Text = cheques[i].Client.FIO;
                        row.Cells[5].Range.Text = cheques[i].Assembly == true ? "да" : "нет";
                        row.Cells[6].Range.Text = cheques[i].Delivery == true ? "да" : "нет";
                        row.Cells[7].Range.Text = string.IsNullOrWhiteSpace(cheques[i].Remarks) ? "-" : cheques[i].Remarks;
                        row.Cells[8].Range.Text = cheques[i].Sum.ToString();

                        allSum += cheques[i].Sum;
                        
                        List<ShopList> shopList = new List<ShopList>();
                        for (int j = 0; j < cheques[i].ShopLists.Count; j++)
                            allSumByPriceIn += cheques[i].ShopLists[j].Furniture.PriceIn * cheques[i].ShopLists[j].Quantity;
                    }
                }
                else
                {
                    Word.Row row = table.Rows.Add();

                    row.Cells[1].Range.Text = "-";
                    row.Cells[2].Range.Text = "-";
                    row.Cells[3].Range.Text = "-";
                    row.Cells[4].Range.Text = "-";
                    row.Cells[5].Range.Text = "-";
                    row.Cells[6].Range.Text = "-";
                    row.Cells[7].Range.Text = "-";
                    row.Cells[8].Range.Text = "-";
                }

                ReplaceWordSub("{dateStart}", dateStart.ToString("d"), wordDocTemplate);
                ReplaceWordSub("{dateEnd}", dateEnd.ToString("d"), wordDocTemplate);
                ReplaceWordSub("{allSum}", allSum.ToString(), wordDocTemplate);
                ReplaceWordSub("{whiteMoney}", (allSum - allSumByPriceIn).ToString(), wordDocTemplate);
                
                ReplaceWordSub("{date}", DateTime.Now.ToString("d"), wordDocTemplate);

                wordDocTemplate.SaveAs(this.fileNameResult);
                wordDocTemplate.Close();

                Word.Document wordDocResult = wordApp.Documents.Open(FileName: this.fileNameResult, ReadOnly: false);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    wordDocResult.SaveAs(saveFileDialog.FileName);

                wordDocResult.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка." + ex.Message, "Ошибка.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wordApp.Quit();
            }
        }

        // печать проданных товаров за период
        public void PrintFurnitureTime(List<Cheque> cheques, DateTime dateStart, DateTime dateEnd)
        {
            Word.Application wordApp = new Word.Application();
            wordApp.Visible = false;

            try
            {
                Word.Document wordDocTemplate = wordApp.Documents.Open(FileName: this.fileNameTemplate, ReadOnly: false);
                Word.Table table = wordDocTemplate.Tables[wordDocTemplate.Tables.Count];

                List<ShopList> shopList = new List<ShopList>();
                decimal allSum = 0;
                if (cheques.Count > 0)
                {
                    for (int i = 0; i < cheques.Count; i++)
                    {
                        for (int j = 0; j < cheques[i].ShopLists.Count; j++)
                        {
                            if (!shopList.Any(s => s.FurnitureId == cheques[i].ShopLists[j].FurnitureId))
                            {
                                shopList.Add(new ShopList
                                {
                                    //ChequeId = cheques[i].ShopLists[j].ChequeId,
                                    //Cheque = cheques[i].ShopLists[j].Cheque,
                                    FurnitureId = cheques[i].ShopLists[j].FurnitureId,
                                    Furniture = cheques[i].ShopLists[j].Furniture,
                                    Quantity = cheques[i].ShopLists[j].Quantity,
                                    Sum = cheques[i].ShopLists[j].Sum
                                });
                            }
                            else
                            {
                                ShopList shop = shopList.Find(s => s.FurnitureId == cheques[i].ShopLists[j].FurnitureId);
                                shop.Quantity += cheques[i].ShopLists[j].Quantity;
                                shop.Sum += cheques[i].ShopLists[j].Sum;
                            }

                            allSum += cheques[i].ShopLists[j].Sum;
                        }
                    }

                    for (int i = 0; i < shopList.Count; i++)
                    {
                        Word.Row row = table.Rows.Add();

                        row.Cells[1].Range.Text = shopList[i].Furniture.Name;
                        row.Cells[2].Range.Text = shopList[i].Furniture.PriceOut.ToString();
                        row.Cells[3].Range.Text = shopList[i].Furniture.Discount.ToString();
                        row.Cells[4].Range.Text = shopList[i].Quantity.ToString();
                        row.Cells[5].Range.Text = shopList[i].Furniture.Unit.Name;
                        row.Cells[6].Range.Text = shopList[i].Sum.ToString();
                    }
                }
                else
                {
                    Word.Row row = table.Rows.Add();

                    row.Cells[1].Range.Text = "-";
                    row.Cells[2].Range.Text = "-";
                    row.Cells[3].Range.Text = "-";
                    row.Cells[4].Range.Text = "-";
                    row.Cells[5].Range.Text = "-";
                    row.Cells[5].Range.Text = "-";
                }

                ReplaceWordSub("{dateStart}", dateStart.ToString("d"), wordDocTemplate);
                ReplaceWordSub("{dateEnd}", dateEnd.ToString("d"), wordDocTemplate);
                ReplaceWordSub("{allSum}", allSum.ToString(), wordDocTemplate);

                ReplaceWordSub("{date}", DateTime.Now.ToString("d"), wordDocTemplate);

                wordDocTemplate.SaveAs(this.fileNameResult);
                wordDocTemplate.Close();

                Word.Document wordDocResult = wordApp.Documents.Open(FileName: this.fileNameResult, ReadOnly: false);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    wordDocResult.SaveAs(saveFileDialog.FileName);

                wordDocResult.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка." + ex.Message, "Ошибка.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                wordApp.Quit();
            }
        }

        private DateTime GerDateIssue(string str)
        {
            string template = "Дата выдачи: ";
            if (str.Contains(template))
            {
                int dateStringStart = str.LastIndexOf(template) + template.Length;
                return Convert.ToDateTime(str.Substring(dateStringStart, 10));
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
