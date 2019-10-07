using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelSystem
{
    public partial class ManageReservationsForm : Form
    {
        public ManageReservationsForm()
        {
            InitializeComponent();
        }

        Room room = new Room();
        Reservation reservation = new Reservation();
        private void ManageReservationsForm_Load(object sender, EventArgs e)
        {
            //display room type
            comboBoxRoomType.DataSource = room.roomTypeList();
            comboBoxRoomType.DisplayMember = "label";
            comboBoxRoomType.ValueMember = "category_id";

            //display room number 
            int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
            comboBoxRoomNumber.DataSource = room.roomByType(type);
            comboBoxRoomNumber.DisplayMember = "number";
            comboBoxRoomNumber.ValueMember = "number";

            //show all reservations in datagrid
            dataGridView1.DataSource = reservation.getAllReserv();
        }

        private void ButtonClearFields_Click(object sender, EventArgs e)
        {
            textBoxReservation.Text = "";
            textBoxClientId.Text = ""; 
            comboBoxRoomType.SelectedIndex = 0;
            dateTimePickerIn.Value = DateTime.Now;
            dateTimePickerOut.Value = DateTime.Now;
        }

        private void ComboBoxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //display room number 
                int type = Convert.ToInt32(comboBoxRoomType.SelectedValue.ToString());
                comboBoxRoomNumber.DataSource = room.roomByType(type);
                comboBoxRoomNumber.DisplayMember = "number";
                comboBoxRoomNumber.ValueMember = "number";
            }
            catch (Exception)
            {

            }
        }

        private void ButtonAddNewReservation_Click(object sender, EventArgs e)
        {
            try
            {
                int clientId = Convert.ToInt32(textBoxClientId.Text);
                int roomNumber = Convert.ToInt32(comboBoxRoomNumber.SelectedValue);
                DateTime dateIn = dateTimePickerIn.Value;
                DateTime dateOut = dateTimePickerOut.Value;

                //date in and out must be == or > today's date
                if(DateTime.Compare(dateIn.Date, DateTime.Now.Date) < 0)
                {
                    MessageBox.Show("The Date in Must equal or greater than today's date", "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (DateTime.Compare(dateOut.Date, dateIn.Date) < 0)
                {
                    MessageBox.Show("The Date in Must equal or greater than Date In", "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (reservation.addReservation(roomNumber, clientId, dateIn, dateOut))
                    {
                        //set the room free column to no
                        dataGridView1.DataSource = reservation.getAllReserv();
                        room.setRoomFree(roomNumber, "No");
                        MessageBox.Show("New Reservation added", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("New Reservation failed", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                int reservationId = Convert.ToInt32(textBoxReservation.Text);
                int clientId = Convert.ToInt32(textBoxClientId.Text);
                int roomNumber = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                DateTime dateIn = dateTimePickerIn.Value;
                DateTime dateOut = dateTimePickerOut.Value;

                //date in and out must be == or > today's date
                if (dateIn < DateTime.Now)
                {
                    MessageBox.Show("The Date in Must equal or greater than today's date", "Invalid Date In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (dateOut < dateIn)
                {
                    MessageBox.Show("The Date in Must equal or greater than Date In", "Invalid Date Out", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (reservation.editReservation(reservationId ,roomNumber, clientId, dateIn, dateOut))
                    {
                        //set the room free column to no
                        room.setRoomFree(roomNumber, "No");
                        dataGridView1.DataSource = reservation.getAllReserv();
                        MessageBox.Show("Reservation Updated", "Reservation Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Reservation Update failed", "Reservation Update", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Add Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxReservation.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            //get the room id
            int roomId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            //select the room type from combobox
            comboBoxRoomType.SelectedValue = room.getRoomType(roomId);
            //select the room number from the combobox
            comboBoxRoomNumber.SelectedValue = roomId;

            textBoxClientId.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            //Show date in and out when selected
            dateTimePickerIn.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[3].Value);
            dateTimePickerOut.Value = Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
        }

        private void ButtonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int reservationId = Convert.ToInt32(textBoxReservation.Text);
                int roomNumber = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString());
                if (reservation.removeReservation(reservationId))
                {
                    dataGridView1.DataSource = reservation.getAllReserv();
                    //setting free to yes after deleting

                    room.setRoomFree(roomNumber, "Yes");
                    MessageBox.Show("Reservation Deleted", "Deleting Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleting Reservation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //ALTER TABLE rooms ADD CONSTRAINT fk_type_id FOREIGN KEY(type) REFERENCES room_category(category_id) on UPDATE CASCADE on DELETE CASCADE 
        //ALTER TABLE reservations ADD CONSTRAINT fk_room_number FOREIGN KEY(roomNumber) REFERENCES rooms(number) on UPDATE CASCADE on DELETE CASCADE
        //ALTER TABLE reservations ADD CONSTRAINT fk_client_id FOREIGN KEY(clientId) REFERENCES client(id) on UPDATE CASCADE on DELETE CASCADE
    }
}
