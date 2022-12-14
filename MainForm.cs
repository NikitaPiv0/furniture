using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace Мебель
{
    public partial class MainForm : Form
    {
        private FurnitureContext _db;

        User _userIn = null;
        List<ShopList> tempShopList = new List<ShopList>();
        decimal tempAllSum = 0;

        string chequeFileName = "cheque.docx";
        string orderFileName = "order.docx";
        string chequeTimeFileName = "chequeTime.docx";
        string chequeEmployeeFileName = "chequeEmployee.docx";

        public MainForm(FurnitureContext db, User user)
        {
            this._db = db;
            this._userIn = user;

            InitializeComponent();
        }

        // MainForm
        private void MainForm_Load(object sender, EventArgs e)
        {
            _db.Clients.Load();
            _db.FurnitureColors.Load();
            _db.FurnitureTypes.Load();
            _db.Units.Load();
            _db.Furnitures.Load();
            _db.Payments.Load();
            _db.Cheques.Load();
            _db.ShopLists.Load();

            // InitDGV
            foreach (Cheque cheque in _db.Cheques.ToList())
                AddDGV(chequeDGV, new object[] { cheque.Id, cheque.Date, cheque.User.Employee.FIO, 
                    cheque.Client.FIO, cheque.Assembly, cheque.Delivery, cheque.Payment.Name, 
                    cheque.Sum, cheque.Remarks
                });

            // InitCB
            DataSourceCB(clientChequeCB, _db.Clients.ToList(), "Id", "FIO");
            DataSourceCB(paymentChequeCB, _db.Payments.ToList(), "Id", "Name");
            DataSourceCB(furnitureShopListCB, _db.Furnitures.ToList(), "Id", "Name");

            // InitTB
            dateTextBox.Text = DateTime.Now.ToString("d");
            userNameTB.Text = _userIn.Employee.FIO;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _db.SaveChanges();
        }

        /********************************************************************/
        // CB
        private void DataSourceCB<T>(ComboBox cb, List<T> list, string value, string display)
        {
            cb.DataSource = list;
            cb.ValueMember = value;
            cb.DisplayMember = display;
        }

        // DGV
        private void AddDGV(DataGridView dgv, object[] data) => dgv.Rows.Add(data);
        private void RemoveDGV(DataGridView dgv, DataGridViewRow removeRow) => dgv.Rows.Remove(removeRow);
        private void UpdateDGV(DataGridView dgv, DataGridViewRow updateRow, params object[] newData) =>
            dgv.Rows[dgv.Rows.IndexOf(updateRow)].SetValues(newData);


        // CUD
        private bool AddEntity<T, DS, BS>(T addObject, DS listEntity, BS bindingSource)
                where T : EntityValidator
                where DS : DbSet<T>
                where BS : BindingSource
        {
            bindingSource.DataSource = addObject;
            if (addObject.IsValid)
            {
                listEntity.Add(addObject);
                _db.SaveChanges();
                bindingSource.Clear();
                return true;
            }
            return false;
        }

        private bool UpdateEntity<T, DS, BS>(object[] keys, T newObject, DS listEntity, BS bindingSource)
            where T : EntityValidator, IEntity<T>
            where DS : DbSet<T>
            where BS : BindingSource
        {
            bindingSource.DataSource = newObject;
            if (newObject.IsValid)
            {
                listEntity.Find(keys).Set(newObject);
                _db.SaveChanges();
                bindingSource.Clear();
                return true;
            }
            return false;
        }

        private bool RemoveEntity<T, DS>(T removeObject, DS listEntity,
            DataGridView dgv, DataGridViewRow removeRow, bool childEmpty)
                where T : EntityValidator
                where DS : DbSet<T>
        {
            if (childEmpty)
            {
                if (DialogResult.Yes == MessageBox.Show("Вы действительно хотите удалить запись?",
                    "Удалить?", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    listEntity.Remove(removeObject);
                    _db.SaveChanges();
                    dgv.Rows.Remove(removeRow);
                    return true;
                }
            }
            else
            {
                MessageBox.Show("У данной записи есть дочерние строки.", "Запись не удалена.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        /******************************************************/

        private void BTNEnabled(bool isEnabled, Button[] buttons)
        {
            foreach (Button btn in buttons)
                btn.Enabled = isEnabled;
        }

        // MainMenuStrip
        private void учетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BooksForm booksForm = new BooksForm(_db, _userIn);
            booksForm.ShowDialog();

            chequeDGV.Rows.Clear();
            foreach (Cheque cheque in _db.Cheques.ToList())
                AddDGV(chequeDGV, new object[] { cheque.Id, cheque.Date, cheque.User.Employee.FIO,
                    cheque.Client.FIO, cheque.Assembly, cheque.Delivery, cheque.Payment.Name,
                    cheque.Sum, cheque.Remarks
                });

            DataSourceCB(clientChequeCB, _db.Clients.ToList(), "Id", "FIO");
            DataSourceCB(paymentChequeCB, _db.Payments.ToList(), "Id", "Name");

            DataSourceCB(furnitureShopListCB, _db.Furnitures.ToList(), "Id", "Name");

            userNameTB.Text = _userIn.Employee.FIO;
        }

        // Cheque
        private void insertShopListBTN_Click(object sender, EventArgs e)
        {
            if (_db.Furnitures.Count() >= 0)
            {
                Furniture furniture = _db.Furnitures.Find((int)furnitureShopListCB.SelectedValue);

                if (tempShopList.Find(sl => sl.FurnitureId == furniture.Id) == null)
                {
                    decimal quantity = quantityShopListNUD.Value;
                    ShopList shopListItem = new ShopList
                    {
                        Id = tempShopList.Count + 1,
                        Furniture = furniture,
                        FurnitureId = furniture.Id,
                        Quantity = Convert.ToInt32(quantityShopListNUD.Value),
                        Sum = quantity * furniture.PriceOut - (quantity * furniture.PriceOut / 100 * furniture.Discount) 
                    };

                    if (furniture.Quantity >= shopListItem.Quantity)
                    {
                        tempShopList.Add(shopListItem);

                        tempAllSum += shopListItem.Sum;
                        allSumTB.Text = tempAllSum.ToString();
                        
                        AddDGV(shopListDGV, new object[] {
                            shopListItem.Id, shopListItem.Furniture.Name,
                            shopListItem.Quantity, shopListItem.Sum
                        });
                    }
                    else
                    {
                        MessageBox.Show($"На складе {furniture.Quantity} единиц данного товара.", "Не добавлено.",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Данный товар уже присутствует в списке.", "Не добавлено.",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("В дочерней таюлице нет записей.", "Заполните дочерние таблицы.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updateShopListBTN_Click(object sender, EventArgs e)
        {
            if (tempShopList.Count > 0)
            {
                ShopList shopListItem = tempShopList.Find(item => item.Id == (int)shopListDGV.CurrentRow.Cells[0].Value);
                decimal tempSum = shopListItem.Sum;
                tempAllSum -= shopListItem.Sum;

                Furniture furniture = _db.Furnitures.Find((int)furnitureShopListCB.SelectedValue);
                if (tempShopList.Find(sl => sl.FurnitureId == furniture.Id) == null)
                {
                    decimal quantity = quantityShopListNUD.Value;

                    shopListItem.Furniture = furniture;
                    shopListItem.FurnitureId = furniture.Id;
                    shopListItem.Quantity = Convert.ToInt32(quantityShopListNUD.Value);
                    shopListItem.Sum = quantity * furniture.PriceOut - (quantity * furniture.PriceOut / 100 * furniture.Discount);

                    if (furniture.Quantity >= shopListItem.Quantity)
                    {
                        tempAllSum += shopListItem.Sum;
                        allSumTB.Text = tempAllSum.ToString();

                        UpdateDGV(shopListDGV, shopListDGV.CurrentRow, new object[] {
                            shopListItem.Id,
                            shopListItem.Furniture.Name,
                            shopListItem.Quantity,
                            shopListItem.Sum
                        });
                    }
                    else
                    {
                        tempAllSum += tempSum;
                        MessageBox.Show($"На складе {furniture.Quantity} единиц данного товара.", "Не добавлено.",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Данный товар уже присутствует в списке.", "Не добавлено.",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void deleteShopListBTN_Click(object sender, EventArgs e)
        {
            if (shopListDGV.Rows.Count > 0)
            {
                ShopList shopListItem = tempShopList.Find(item => item.Id == (int)shopListDGV.CurrentRow.Cells[0].Value);
                
                tempShopList.Remove(shopListItem);
                
                tempAllSum -= shopListItem.Sum;
                allSumTB.Text = tempAllSum.ToString();

                RemoveDGV(shopListDGV, shopListDGV.CurrentRow);
            }
        }

        private void clearShopListBTN_Click(object sender, EventArgs e)
        {
            if (_db.Furnitures.Count() > 0)
            {
                shopListBindingSource.Clear();
                furnitureShopListCB.SelectedIndex = 0;
                quantityShopListNUD.Value = 1;
            }
        }

        private void shopListDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ShopList shopListItem = tempShopList.Find(item => item.Id == (int)shopListDGV.CurrentRow.Cells[0].Value);
                
                furnitureShopListCB.SelectedItem = shopListItem.Furniture;
                quantityShopListNUD.Value = shopListItem.Quantity;
            }
        }

        // Cheque
        private void insertChequeBTN_Click(object sender, EventArgs e)
        {
            if (_db.Payments.Count() > 0 && _db.Clients.Count() > 0)
            {
                if (tempShopList.Count > 0)
                {
                    if (ValidateChildren(ValidationConstraints.Enabled | ValidationConstraints.Visible))
                    {
                        Cheque cheque = new Cheque
                        {
                            Date = DateTime.Now,
                            User = _userIn,
                            UserId = _userIn.Id,
                            Client = clientChequeCB.SelectedItem as Client,
                            ClientId = (int)clientChequeCB.SelectedValue,
                            Payment = paymentChequeCB.SelectedItem as Payment,
                            PaymentId = (int)paymentChequeCB.SelectedValue,
                            Delivery = deliveryChequeCheckBox.Checked,
                            Assembly = assemblyChequeCheckBox.Checked,
                            Sum = tempAllSum,
                            ShopLists = tempShopList
                        };

                        if (issueCheckBox.Checked)
                            cheque.Remarks = dateIssueChequeDTP.Value.ToString("d");

                        if (AddEntity(cheque, _db.Cheques, chequeBindingSource))
                        {
                            foreach (ShopList shopList in cheque.ShopLists)
                                _db.Furnitures.Find(shopList.FurnitureId).Quantity -= shopList.Quantity;

                            _db.SaveChanges();

                            AddDGV(chequeDGV, new object[] { cheque.Id, cheque.Date, cheque.User.Employee.FIO,
                                cheque.Client.FIO, cheque.Assembly, cheque.Delivery, cheque.Payment.Name,
                                cheque.Sum, cheque.Remarks
                            });
                        }

                        ClearCheque();
                    }
                }
                else
                {
                    MessageBox.Show("Список покупок пуст.", "Добавьте продукт.",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("В дочерней таюлице нет записей.", "Заполните дочерние таблицы.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void delelteChequeBTN_Click(object sender, EventArgs e)
        {
            if (chequeDGV.Rows.Count > 0)
            {
                Cheque cheque = _db.Cheques.Find((int)chequeDGV.CurrentRow.Cells[0].Value);
                if (RemoveEntity(cheque, _db.Cheques, chequeDGV, chequeDGV.CurrentRow, true))
                    ClearCheque();
            }
        }

        private void ClearCheque()
        {
            if (_db.Clients.Count() > 0 && _db.Payments.Count() > 0)
            {
                issueCheckBox.Checked = false;
                dateIssueChequeDTP.Value = DateTime.Now;

                chequeBindingSource.Clear();

                tempAllSum = 0;
                allSumTB.Text = "0";

                sumChequeNUD.Value = 0;
                oddMoneyTextBox.Clear();

                clientChequeCB.SelectedIndex = 0;
                paymentChequeCB.SelectedIndex = 0;

                if (_db.Furnitures.Count() > 0)
                {
                    shopListBindingSource.Clear();
                    furnitureShopListCB.SelectedIndex = 0;
                    quantityShopListNUD.Value = 1;
                }

                shopListDGV.Rows.Clear();
                tempShopList = new List<ShopList>();

                BTNEnabled(true, new Button[] { insertChequeBTN, insertShopListBTN,
                    updateShopListBTN, deleteShopListBTN, clearShopListBTN
                });
            }
        }

        private void clearChequeBTN_Click(object sender, EventArgs e)
        {
            ClearCheque();
        }

        private void printChequeBTN_Click(object sender, EventArgs e)
        {
            if (chequeDGV.Rows.Count > 0)
            {
                Report report = new Report(orderFileName, saveFileDialog);
                report.PrintOrder(_db.Cheques.Find((int)chequeDGV.CurrentRow.Cells[0].Value));
            }
        }

        private void chequePrintChequeBTN_Click(object sender, EventArgs e)
        {
            if (chequeDGV.Rows.Count > 0)
            {
                Report report = new Report(chequeFileName, saveFileDialog);
                report.PrintCheque(_db.Cheques.Find((int)chequeDGV.CurrentRow.Cells[0].Value));
            }
        }

        private void chequeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Cheque cheque = _db.Cheques.Find((int)chequeDGV.CurrentRow.Cells[0].Value);
                dateIssueChequeDTP.Value = cheque.Date;
                clientChequeCB.SelectedItem = cheque.Client;
                paymentChequeCB.SelectedItem = cheque.Payment;
                assemblyChequeCheckBox.Checked = cheque.Assembly;
                deliveryChequeCheckBox.Checked = cheque.Delivery;
                
                if (!string.IsNullOrEmpty(cheque.Remarks))
                {
                    issueCheckBox.Checked = true; 
                    dateIssueChequeDTP.Value = Convert.ToDateTime(cheque.Remarks);
                }

                shopListDGV.Rows.Clear();
                int i = 0;
                tempAllSum = 0;
                foreach (ShopList shopListItem in cheque.ShopLists)
                {
                    shopListItem.Id = ++i;
                    tempShopList.Add(shopListItem);
                    AddDGV(shopListDGV, new object[] {
                        shopListItem.Id, shopListItem.Furniture.Name,
                        shopListItem.Quantity, shopListItem.Sum
                    });

                    tempAllSum += shopListItem.Sum;
                }
                
                allSumTB.Text = tempAllSum.ToString();

                BTNEnabled(false, new Button[] { insertChequeBTN, insertShopListBTN, 
                    updateShopListBTN, deleteShopListBTN, clearShopListBTN
                });

                if (!string.IsNullOrEmpty(cheque.Remarks))
                {
                    issueCheckBox.Checked = true;
                    dateIssueChequeDTP.Value = Convert.ToDateTime(cheque.Remarks);
                }
                else
                {
                    issueCheckBox.Checked = false;
                    dateIssueChequeDTP.Value = DateTime.Now;
                }
            }
        }

        // выходные документы
        private void покупкиЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chequeTimeForm chequeTimeF = new chequeTimeForm(_db, chequeTimeFileName);
            chequeTimeF.ShowDialog();
        }

        private void результатыРаботыСотрудникаЗаПериодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chequeFurnitureForm chequeEmployeeF = new chequeFurnitureForm(_db, chequeEmployeeFileName);
            chequeEmployeeF.ShowDialog();
        }

        private void sumChequeNUD_ValueChanged(object sender, EventArgs e)
        {
            oddMoneyTextBox.Text = (sumChequeNUD.Value - tempAllSum).ToString();
        }


        // Дата выдачи
        private void issueCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (issueCheckBox.Checked)
                dateIssueChequeDTP.Enabled = true;
            else
                dateIssueChequeDTP.Enabled = false;
        }

        private void dateIssueChequeDTP_Validating(object sender, CancelEventArgs e)
        {

            if (dateIssueChequeDTP.Value < DateTime.Now.Date)
            {
                e.Cancel = true;
                clientErrorProvider.SetError(dateIssueChequeDTP, "Дата выдачи не может быть меньше текущей даты.");
            }
            else
            {
                e.Cancel = false;
                clientErrorProvider.SetError(dateIssueChequeDTP, null);
            }
        }
    }
}
