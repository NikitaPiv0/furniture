using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мебель
{
    public interface IEntity<T>
    {
        void Set(T obj);
    }

    public partial class BooksForm : Form
    {
        private FurnitureContext _db;
        private User _userIn;
        private string _offFurnitureFileName = "OffFurniture.docx";
        private string _offFurnitureLogFileName = "OffFurnitureLog.txt";

        public BooksForm(FurnitureContext db, User userIn)
        {
            this._db = db;
            this._userIn = userIn;

            InitializeComponent();
        }

        private void BooksForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _db.SaveChanges();
        }

        private void BooksForm_Load(object sender, EventArgs e)
        {
            // InitDGV
            foreach (FurnitureColor furnitureColor in _db.FurnitureColors.ToList())
                AddDGV(furnitureColorDGV, new object[] { furnitureColor.Id, furnitureColor.Name });
            
            foreach (FurnitureType furnitureType in _db.FurnitureTypes.ToList())
                AddDGV(furnitureTypeDGV, new object[] { furnitureType.Id, furnitureType.Name });
            
            foreach (Unit unit in _db.Units.ToList())
                AddDGV(unitDGV, new object[] { unit.Id, unit.Name });

            foreach (Payment payment in _db.Payments.ToList())
                AddDGV(paymentDGV, new object[] { payment.Id, payment.Name });

            foreach (Employee employee in _db.Employees.ToList())
                AddDGV(employeeDGV, new object[] { employee.Id, employee.FIO });

            foreach (User user in _db.Users.ToList())
                AddDGV(userDGV, new object[] { user.Id, user.Employee.FIO, user.Login, user.Password, user.EmployeeId });

            foreach (Client client in _db.Clients.ToList())
                AddDGV(clientDGV, new object[] { 
                    client.Id, client.Name, client.FIO,
                    client.Phone, client.PassportSeries, client.PassportNumber,
                    client.PassportIssued, client.PassportDate, client.BIK, client.PaymentAccount,
                    client.CorrespondentAccount, client.INN, client.OGRN });

            foreach (Furniture furniture in _db.Furnitures.ToList())
                AddDGV(furnitureDGV, new object[] {
                    furniture.Id, furniture.Name, furniture.ArticleNumber, furniture.FurnitureColor.Name,
                    furniture.FurnitureType.Name, furniture.Warranty, furniture.PriceIn, furniture.PriceOut,
                    furniture.Discount, furniture.Quantity, furniture.Unit.Name, furniture.Remarks
                });

            // InitCB
            DataSourceCB(employeeUserCB, _db.Employees.ToList(), "Id", "FIO");
            
            DataSourceCB(furnitureColorIdFurnitureCB, _db.FurnitureColors.ToList(), "Id", "Name");
            DataSourceCB(furnitureTypeIdFurnitureCB, _db.FurnitureTypes.ToList(), "Id", "Name");
            DataSourceCB(unitsIdFurnitureCB, _db.Units.ToList(), "Id", "Name");
            
            nameClientCB.SelectedIndex = 0;
        }

        /********************************************************************/
        // CB
        private void DataSourceCB<T>(ComboBox cb,  List<T> list, string value, string display)
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



        private void insertClientBTN_Click(object sender, EventArgs e)
        {
            Client client = new Client
            {
                FIO = fioClientTB.Text.Trim(),
                Name = nameClientCB.Text.Trim(),
                Phone = phoneClientTB.Text.Trim(),
                BIK = bikClientTB.Text.Trim(),
                CorrespondentAccount = caClientTB.Text.Trim(),
                PaymentAccount = paClientTB.Text.Trim(),
                INN = innClientTB.Text.Trim(),
                OGRN = ogrnClientTB.Text.Trim(),
                PassportNumber = numberClientTB.Text.Trim(),
                PassportSeries = seriesClientTB.Text.Trim(),
                PassportIssued = issuedClientTB.Text.Trim(),
                PassportDate = passportDateClientDTP.Value
            };

            if (client.FIO != "Физическое лицо")
            {
                if (AddEntity(client, _db.Clients, clientBindingSource))
                    AddDGV(clientDGV, new object[] { client.Id, client.Name, client.FIO,
                    client.Phone, client.PassportSeries, client.PassportNumber,
                    client.PassportIssued, client.PassportDate, client.BIK, client.PaymentAccount,
                    client.CorrespondentAccount, client.INN, client.OGRN });
            }
            else
            {
                MessageBox.Show($"Клиента с именем \"Физическое лицо\" нельзя добавить.", "Запись не добавлена.", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void updateClientBTN_Click(object sender, EventArgs e)
        {
            if (clientDGV.Rows.Count > 0)
            {
                Client newClient = new Client
                {
                    FIO = fioClientTB.Text.Trim(),
                    Name = nameClientCB.Text.Trim(),
                    Phone = phoneClientTB.Text.Trim(),
                    BIK = bikClientTB.Text.Trim(),
                    CorrespondentAccount = caClientTB.Text.Trim(),
                    PaymentAccount = paClientTB.Text.Trim(),
                    INN = innClientTB.Text.Trim(),
                    OGRN = ogrnClientTB.Text.Trim(),
                    PassportNumber = numberClientTB.Text.Trim(),
                    PassportSeries = seriesClientTB.Text.Trim(),
                    PassportIssued = issuedClientTB.Text.Trim(),
                    PassportDate = passportDateClientDTP.Value
                };

                Client client = _db.Clients.Find((int)clientDGV.CurrentRow.Cells[0].Value);
                if (newClient.FIO != "Физическое лицо")
                {
                    if (client.FIO != "Физическое лицо")
                    {
                        if (UpdateEntity(new object[] { client.Id }, newClient, _db.Clients, clientBindingSource))
                            UpdateDGV(clientDGV, clientDGV.CurrentRow, new object[] {
                                client.Id, client.Name, client.FIO,
                                client.Phone, client.PassportSeries, client.PassportNumber,
                                client.PassportIssued, client.PassportDate, client.BIK, client.PaymentAccount,
                                client.CorrespondentAccount, client.INN, client.OGRN });
                    }
                    else
                    {
                        MessageBox.Show($"Клиента с именем \"Физическое лицо\" нельзя изменить.", "Запись не изменена.",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show($"Клиент с именем \"Физическое лицо\" уже существует.", "Запись не изменена.",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deleteClientBTN_Click(object sender, EventArgs e)
        {
            if (clientDGV.Rows.Count > 0)
            {
                Client client = _db.Clients.Find((int)clientDGV.CurrentRow.Cells[0].Value);
                if (client.FIO != "Физическое лицо")
                {
                    RemoveEntity(client, _db.Clients, clientDGV, clientDGV.CurrentRow, client.Cheques.Count == 0);
                }
                else
                {
                    MessageBox.Show($"Клиента с именем \"Физическое лицо\" нельзя удалить.", "Запись не удалена.",
                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void clearClientBTN_Click(object sender, EventArgs e)
        {
            clientBindingSource.Clear();
            nameClientCB.SelectedIndex = 0;
        }

        private void clientDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Client client = _db.Clients.Find((int)clientDGV.Rows[e.RowIndex].Cells[0].Value);

                nameClientCB.SelectedValue = client.Name;
                fioClientTB.Text = client.FIO;
                phoneClientTB.Text = client.Phone;
                bikClientTB.Text = client.BIK;
                caClientTB.Text = client.CorrespondentAccount;
                paClientTB.Text = client.PaymentAccount;
                innClientTB.Text = client.INN;
                ogrnClientTB.Text = client.OGRN;
                seriesClientTB.Text = client.PassportSeries;
                numberClientTB.Text = client.PassportNumber;
                issuedClientTB.Text = client.PassportIssued;
                passportDateClientDTP.Value = client.PassportDate;
            }
        }

        // FurnitureColor
        private void insertFurnitureColorBTN_Click(object sender, EventArgs e)
        {
            FurnitureColor furnitureColor = new FurnitureColor { Name = nameFurnitureColorTB.Text.Trim() };
            if (AddEntity(furnitureColor, _db.FurnitureColors, furnitureColorBindingSource))
            {
                AddDGV(furnitureColorDGV, new object[] { furnitureColor.Id, furnitureColor.Name });
                DataSourceCB(furnitureColorIdFurnitureCB, _db.FurnitureColors.ToList(), "Id", "Name");
            }
        }

        private void updateFurnitureColorBTN_Click(object sender, EventArgs e)
        {
            if (furnitureColorDGV.Rows.Count > 0)
            {
                FurnitureColor newFurnitureColor = new FurnitureColor { Name = nameFurnitureColorTB.Text.Trim() };
                FurnitureColor furnitureColor = _db.FurnitureColors.Find((int)furnitureColorDGV.CurrentRow.Cells[0].Value);
                if (UpdateEntity(new object[] { furnitureColor.Id }, newFurnitureColor, _db.FurnitureColors, furnitureColorBindingSource))
                {
                    UpdateDGV(furnitureColorDGV, furnitureColorDGV.CurrentRow, new object[] { furnitureColor.Id, newFurnitureColor.Name });
                    DataSourceCB(furnitureColorIdFurnitureCB, _db.FurnitureColors.ToList(), "Id", "Name");
                }
            }
        }

        private void deleteFurnitureColorBTN_Click(object sender, EventArgs e)
        {
            if (furnitureColorDGV.Rows.Count > 0)
            {
                FurnitureColor furnitureColor = _db.FurnitureColors.Find((int)furnitureColorDGV.CurrentRow.Cells[0].Value);
                if (RemoveEntity(furnitureColor, _db.FurnitureColors, furnitureColorDGV, furnitureColorDGV.CurrentRow, furnitureColor.Furnitures.Count == 0))
                    DataSourceCB(furnitureColorIdFurnitureCB, _db.FurnitureColors.ToList(), "Id", "Name");
            }
        }



        private void furnitureColorDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                nameFurnitureColorTB.Text = _db.FurnitureColors.Find((int)furnitureColorDGV.Rows[e.RowIndex].Cells[0].Value).Name; 
        }

        private void clearFurnitureColorBTN_Click(object sender, EventArgs e)
        {
            furnitureColorBindingSource.Clear();
        }

        // FurnitureType
        private void insertFurnitureTypeBTN_Click(object sender, EventArgs e)
        {
            FurnitureType furnitureType = new FurnitureType { Name = nameFurnitureTypeTB.Text.Trim() };
            if (AddEntity(furnitureType, _db.FurnitureTypes, furnitureTypeBindingSource))
            {
                AddDGV(furnitureTypeDGV, new object[] { furnitureType.Id, furnitureType.Name });
                DataSourceCB(furnitureTypeIdFurnitureCB, _db.FurnitureTypes.ToList(), "Id", "Name");
            }
        }

        private void updateFurnitureTypeBTN_Click(object sender, EventArgs e)
        {
            if (furnitureTypeDGV.Rows.Count > 0)
            {
                FurnitureType newFurnitureType = new FurnitureType { Name = nameFurnitureTypeTB.Text.Trim() };
                FurnitureType furnitureType = _db.FurnitureTypes.Find((int)furnitureTypeDGV.CurrentRow.Cells[0].Value);
                if (UpdateEntity(new object[] { furnitureType.Id }, newFurnitureType, _db.FurnitureTypes, furnitureTypeBindingSource))
                {
                    UpdateDGV(furnitureTypeDGV, furnitureTypeDGV.CurrentRow, new object[] { furnitureType.Id, newFurnitureType.Name });
                    DataSourceCB(furnitureTypeIdFurnitureCB, _db.FurnitureTypes.ToList(), "Id", "Name");
                }
            }
        }

        private void deleteFurnitureTypeBTN_Click(object sender, EventArgs e)
        {
            if (furnitureTypeDGV.Rows.Count > 0)
            {
                FurnitureType furnitureType = _db.FurnitureTypes.Find((int)furnitureTypeDGV.CurrentRow.Cells[0].Value);
                if (RemoveEntity(furnitureType, _db.FurnitureTypes, furnitureTypeDGV, furnitureTypeDGV.CurrentRow, furnitureType.Furnitures.Count == 0))
                    DataSourceCB(furnitureTypeIdFurnitureCB, _db.FurnitureTypes.ToList(), "Id", "Name");
            }
        }

        private void clearFurnitureTypeBTN_Click(object sender, EventArgs e)
        {
            furnitureTypeBindingSource.Clear();
        }

        private void furnitureTypeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                nameFurnitureTypeTB.Text = _db.FurnitureTypes.Find((int)furnitureTypeDGV.Rows[e.RowIndex].Cells[0].Value).Name;
        }

        // Unit
        private void insertUnitBTN_Click(object sender, EventArgs e)
        {
            Unit unit = new Unit { Name = nameUnitTB.Text.Trim() };
            if (AddEntity(unit, _db.Units, unitBindingSource))
            {
                AddDGV(unitDGV, new object[] { unit.Id, unit.Name });
                DataSourceCB(unitsIdFurnitureCB, _db.Units.ToList(), "Id", "Name");
            }
        }

        private void updateUnitBTN_Click(object sender, EventArgs e)
        {
            if (unitDGV.Rows.Count > 0)
            {
                Unit newUnit = new Unit { Name = nameUnitTB.Text.Trim() };
                Unit unit = _db.Units.Find((int)unitDGV.CurrentRow.Cells[0].Value);
                if (UpdateEntity(new object[] { unit.Id }, newUnit, _db.Units, unitBindingSource))
                {
                    UpdateDGV(unitDGV, unitDGV.CurrentRow, new object[] { unit.Id, newUnit.Name });
                    DataSourceCB(unitsIdFurnitureCB, _db.Units.ToList(), "Id", "Name");
                }
            }
        }

        private void deleteUnitBTN_Click(object sender, EventArgs e)
        {
            if (unitDGV.Rows.Count > 0)
            {
                Unit unit = _db.Units.Find((int)unitDGV.CurrentRow.Cells[0].Value);
                if (RemoveEntity(unit, _db.Units, unitDGV, unitDGV.CurrentRow, unit.Furnitures.Count == 0))
                    DataSourceCB(unitsIdFurnitureCB, _db.Units.ToList(), "Id", "Name");
            }
        }

        private void clearUnitBTN_Click(object sender, EventArgs e)
        {
            unitBindingSource.Clear();
        }

        private void unitDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                nameUnitTB.Text = _db.Units.Find((int)unitDGV.Rows[e.RowIndex].Cells[0].Value).Name;
        }

        // Payment
        private void insertPaymentBTN_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment { Name = namePaymentTB.Text.Trim() };
            if (AddEntity(payment, _db.Payments, paymentBindingSource))
                AddDGV(paymentDGV, new object[] { payment.Id, payment.Name });
        }

        private void updatePaymentBTN_Click(object sender, EventArgs e)
        {
            if (paymentDGV.Rows.Count > 0)
            {
                Payment newPayment = new Payment { Name = namePaymentTB.Text.Trim() };
                Payment payment = _db.Payments.Find((int)paymentDGV.CurrentRow.Cells[0].Value);
                if (UpdateEntity(new object[] { payment.Id }, newPayment, _db.Payments, paymentBindingSource))
                    UpdateDGV(paymentDGV, paymentDGV.CurrentRow, new object[] { payment.Id, newPayment.Name });
            }
        }

        private void deletePaymentBTN_Click(object sender, EventArgs e)
        {
            if (paymentDGV.Rows.Count > 0)
            {
                Payment payment = _db.Payments.Find((int)paymentDGV.CurrentRow.Cells[0].Value);
                RemoveEntity(payment, _db.Payments, paymentDGV, paymentDGV.CurrentRow, payment.Cheques.Count == 0);
            }
        }

        private void clearPaymentBTN_Click(object sender, EventArgs e)
        {
            paymentBindingSource.Clear();
        }

        private void paymentDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                namePaymentTB.Text = _db.Payments.Find((int)paymentDGV.Rows[e.RowIndex].Cells[0].Value).Name;
        }

        // Employee
        private void insertEmployeeBTN_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee { FIO = fioEmployeeTB.Text.Trim() };
            if (AddEntity(employee, _db.Employees, employeeBindingSource))
            {
                AddDGV(employeeDGV, new object[] { employee.Id, employee.FIO });
                DataSourceCB(employeeUserCB, _db.Employees.ToList(), "Id", "FIO");
            }
        }

        private void updateEmployeeBTN_Click(object sender, EventArgs e)
        {
            if (employeeDGV.Rows.Count > 0)
            {
                Employee newEmployee = new Employee { FIO = fioEmployeeTB.Text.Trim() };
                Employee employee = _db.Employees.Find((int)employeeDGV.CurrentRow.Cells[0].Value);
                if (UpdateEntity(new object[] { employee.Id }, newEmployee, _db.Employees, employeeBindingSource))
                {
                    UpdateDGV(employeeDGV, employeeDGV.CurrentRow, new object[] { employee.Id, newEmployee.FIO });
                    DataSourceCB(employeeUserCB, _db.Employees.ToList(), "Id", "FIO");
                }
            }
        }

        private void deleteEmployeeBTN_Click(object sender, EventArgs e)
        {
            if (employeeDGV.Rows.Count > 0)
            {
                Employee employee = _db.Employees.Find((int)employeeDGV.CurrentRow.Cells[0].Value);
                if (RemoveEntity(employee, _db.Employees, employeeDGV, employeeDGV.CurrentRow, employee.Users.Count == 0))
                    DataSourceCB(employeeUserCB, _db.Employees.ToList(), "Id", "FIO");
            }
        }

        private void clearEmployeeBTN_Click(object sender, EventArgs e)
        {
            employeeBindingSource.Clear();
        }

        private void employeeDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                fioEmployeeTB.Text = _db.Employees.Find((int)employeeDGV.Rows[e.RowIndex].Cells[0].Value).FIO;
        }

        // User
        private void insertUserBTN_Click(object sender, EventArgs e)
        {
            if (_db.Employees.Count() > 0)
            {
                User user = new User
                {
                    Login = loginUserTB.Text.Trim(),
                    Password = passwordUserTB.Text.Trim(),
                    Employee = _db.Employees.Find(new object[] { employeeUserCB.SelectedValue }),
                    EmployeeId = (int)employeeUserCB.SelectedValue
                };

                if (!_db.Users.Any(u => u.Employee.Id == user.EmployeeId))
                {
                    if (AddEntity(user, _db.Users, userBindingSource))
                        AddDGV(userDGV, new object[] { user.Id, user.Employee.FIO, user.Login, user.Password, user.EmployeeId });
                }
                else
                {
                    MessageBox.Show("Выбранный сотрудник уже зарегистрирован в системе.",
                        "Выберите другого сотрудника.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("В дочерней таюлице нет записей.", "Заполните дочерние таблицы.", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void updateUserBTN_Click(object sender, EventArgs e)
        {
            if (userDGV.Rows.Count > 0)
            {
                User newUser = new User
                {
                    Login = loginUserTB.Text.Trim(),
                    Password = passwordUserTB.Text.Trim(),
                    Employee = _db.Employees.Find(new object[] { employeeUserCB.SelectedValue }),
                    EmployeeId = (int)employeeUserCB.SelectedValue
                };

                User user = _db.Users.Find((int)userDGV.CurrentRow.Cells[0].Value);
                if (user.EmployeeId == newUser.EmployeeId || !_db.Users.Any(u => u.Employee.Id == newUser.EmployeeId)) 
                {
                    if (UpdateEntity(new object[] { user.Id }, newUser, _db.Users, userBindingSource))
                        UpdateDGV(userDGV, userDGV.CurrentRow, new object[] { user.Id, user.Employee.FIO, user.Login, user.Password, user.EmployeeId });
                }
                else
                {
                    MessageBox.Show("Выбранный сотрудник уже зарегистрирован в системе.",
                        "Выберите другого сотрудника.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void deleteUserBTN_Click(object sender, EventArgs e)
        {
            if (userDGV.Rows.Count > 0)
            {
                User user = _db.Users.Find((int)userDGV.CurrentRow.Cells[0].Value);
                RemoveEntity(user, _db.Users, userDGV, userDGV.CurrentRow, user.Cheques.Count == 0);
            }
        }

        private void clearUserBTN_Click(object sender, EventArgs e)
        {
            userBindingSource.Clear();
        }

        private void userDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                User user = _db.Users.Find((int)userDGV.Rows[e.RowIndex].Cells[0].Value);

                employeeUserCB.SelectedValue = user.EmployeeId;
                loginUserTB.Text = user.Login;
                passwordUserTB.Text = user.Password;
            }
        }

        // Furniture
        private void insertFurnitureBTN_Click(object sender, EventArgs e)
        {
            if (_db.FurnitureColors.Count() > 0 && _db.FurnitureTypes.Count() > 0 && _db.Units.Count() > 0)
            {
                Furniture furniture = new Furniture
                {
                    Name = nameFurnitureTB.Text.Trim(),
                    ArticleNumber = articleNumberFurnitureTB.Text.Trim(),
                    FurnitureColor = furnitureColorIdFurnitureCB.SelectedItem as FurnitureColor,
                    FurnitureType = furnitureTypeIdFurnitureCB.SelectedItem as FurnitureType,
                    FurnitureColorId = Convert.ToInt32(furnitureColorIdFurnitureCB.SelectedValue),
                    FurnitureTypeId = Convert.ToInt32(furnitureTypeIdFurnitureCB.SelectedValue),
                    Warranty = warrantyFurnitureTB.Text.Trim(),
                    PriceIn = priceInFurnitureNUD.Value,
                    PriceOut = priceOutFurnitureNUD.Value,
                    Discount = Convert.ToInt32(discountFurnitureNUD.Value),
                    Quantity = Convert.ToInt32(quantityFurnitureNUD.Value),
                    Unit = unitsIdFurnitureCB.SelectedItem as Unit,
                    UnitsId = Convert.ToInt32(unitsIdFurnitureCB.SelectedValue),
                    Remarks = remarksFurnitureTB.Text.Trim()
                };

                if (AddEntity(furniture, _db.Furnitures, furnitureBindingSource))
                    AddDGV(furnitureDGV, new object[] {
                        furniture.Id, furniture.Name, furniture.ArticleNumber, furniture.FurnitureColor.Name,
                        furniture.FurnitureType.Name, furniture.Warranty, furniture.PriceIn, furniture.PriceOut,
                        furniture.Discount, furniture.Quantity, furniture.Unit.Name, furniture.Remarks
                    });
            }
            else
            {
                MessageBox.Show("В дочериз таюлицах нет записей.", "Заполните дочерние таблицы.",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void updateFurnitureBTN_Click(object sender, EventArgs e)
        {
            if (furnitureDGV.Rows.Count > 0)
            {
                Furniture newFurniture = new Furniture {
                    Name = nameFurnitureTB.Text.Trim(),
                    ArticleNumber = articleNumberFurnitureTB.Text.Trim(),
                    FurnitureColor = furnitureColorIdFurnitureCB.SelectedItem as FurnitureColor,
                    FurnitureType = furnitureTypeIdFurnitureCB.SelectedItem as FurnitureType,
                    FurnitureColorId = Convert.ToInt32(furnitureColorIdFurnitureCB.SelectedValue),
                    FurnitureTypeId = Convert.ToInt32(furnitureTypeIdFurnitureCB.SelectedValue),
                    Warranty = warrantyFurnitureTB.Text.Trim(),
                    PriceIn = priceInFurnitureNUD.Value,
                    PriceOut = priceOutFurnitureNUD.Value,
                    Discount = Convert.ToInt32(discountFurnitureNUD.Value),
                    Quantity = Convert.ToInt32(quantityFurnitureNUD.Value),
                    Unit = unitsIdFurnitureCB.SelectedItem as Unit,
                    UnitsId = Convert.ToInt32(unitsIdFurnitureCB.SelectedValue),
                    Remarks = remarksFurnitureTB.Text.Trim()
                };
                
                Furniture furniture = _db.Furnitures.Find((int)furnitureDGV.CurrentRow.Cells[0].Value);
                if (UpdateEntity(new object[] { furniture.Id }, newFurniture, _db.Furnitures, furnitureBindingSource))
                {
                    UpdateDGV(furnitureDGV, furnitureDGV.CurrentRow, new object[] {
                        furniture.Id, furniture.Name, furniture.ArticleNumber, furniture.FurnitureColor.Name,
                        furniture.FurnitureType.Name, furniture.Warranty, furniture.PriceIn, furniture.PriceOut,
                        furniture.Discount, furniture.Quantity, furniture.Unit.Name, furniture.Remarks
                    });
                    DataSourceCB(employeeUserCB, _db.Employees.ToList(), "Id", "FIO");
                }
            }
        }

        private void daleteFurnitureBTN_Click(object sender, EventArgs e)
        {
            if (furnitureDGV.Rows.Count > 0)
            {
                Furniture furniture = _db.Furnitures.Find((int)furnitureDGV.CurrentRow.Cells[0].Value);
                RemoveEntity(furniture, _db.Furnitures, furnitureDGV, furnitureDGV.CurrentRow, furniture.ShopLists.Count == 0);
            }
        }

        private void offFurnitureBTN_Click(object sender, EventArgs e)
        {
            if (furnitureDGV.Rows.Count > 0)
            {
                int quantity = Convert.ToInt32(quantityFurnitureNUD.Value);
                string remarks = remarksFurnitureTB.Text.Trim();

                Furniture furniture = _db.Furnitures.Find((int)furnitureDGV.CurrentRow.Cells[0].Value);
                Furniture newFurniture = new Furniture
                {
                    Id = furniture.Id,
                    Name = furniture.Name,
                    ArticleNumber = furniture.ArticleNumber,
                    FurnitureColor = furniture.FurnitureColor,
                    FurnitureType = furniture.FurnitureType,
                    FurnitureColorId = furniture.FurnitureColorId,
                    FurnitureTypeId = furniture.FurnitureTypeId,
                    Warranty = furniture.Warranty,
                    PriceIn = furniture.PriceIn,
                    PriceOut = furniture.PriceOut,
                    Discount = furniture.Discount,
                    Quantity = furniture.Quantity - quantity,
                    Unit = furniture.Unit,
                    UnitsId = furniture.UnitsId,
                    Remarks = furniture.Remarks
                };

                if (remarks != "")
                {
                    if (quantity <= furniture.Quantity)
                    {
                        if (UpdateEntity(new object[] { furniture.Id }, newFurniture, _db.Furnitures, furnitureBindingSource))
                        {
                            UpdateDGV(furnitureDGV, furnitureDGV.CurrentRow, new object[] {
                            furniture.Id, furniture.Name, furniture.ArticleNumber, furniture.FurnitureColor.Name,
                            furniture.FurnitureType.Name, furniture.Warranty, furniture.PriceIn, furniture.PriceOut,
                            furniture.Discount, furniture.Quantity, furniture.Unit.Name, furniture.Remarks
                        });
                            DataSourceCB(employeeUserCB, _db.Employees.ToList(), "Id", "FIO");

                            newFurniture.Quantity = quantity;
                            newFurniture.Remarks = remarks;

                            Report report = new Report(_offFurnitureFileName, saveFileDialog);
                            report.PrintOffFurniture(newFurniture, _userIn.Employee);
                            
                            Report log = new Report(_offFurnitureLogFileName);
                            log.PrintOffFurnitureLog(newFurniture, _userIn.Employee);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"На складе {furniture.Quantity} единиц данного товара.", "Ошибка.",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Вы не указали причину списания.", "Ошибка.",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void clearFurnitureBTN_Click(object sender, EventArgs e)
        {
            furnitureBindingSource.Clear();

            furnitureColorIdFurnitureCB.SelectedIndex = 0;
            furnitureTypeIdFurnitureCB.SelectedIndex = 0;
            unitsIdFurnitureCB.SelectedIndex = 0;
        }

        private void furnitureDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Furniture furniture = _db.Furnitures.Find((int)furnitureDGV.Rows[e.RowIndex].Cells[0].Value);

                nameFurnitureTB.Text = furniture.Name;
                articleNumberFurnitureTB.Text = furniture.ArticleNumber;
                furnitureColorIdFurnitureCB.SelectedItem = furniture.FurnitureColor;
                furnitureTypeIdFurnitureCB.SelectedItem = furniture.FurnitureType;
                warrantyFurnitureTB.Text = furniture.Warranty;
                priceInFurnitureNUD.Value = furniture.PriceIn;
                priceOutFurnitureNUD.Value = furniture.PriceOut;
                discountFurnitureNUD.Value = furniture.Discount;
                quantityFurnitureNUD.Value = furniture.Quantity;
                unitsIdFurnitureCB.SelectedItem = furniture.Unit;
                remarksFurnitureTB.Text = furniture.Remarks;
            }
        }
    }
}
