using AMS.Data;
using AMS.Data.People;
using AMS.Data.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMS.Users.Forms
{
    public partial class Network_Administration : Form
    {
        NetworkUser user = new NetworkUser();

        EditMode editMode;

        public Network_Administration()
        {
            InitializeComponent();
            editMode = EditMode.Normal;
        }

        public Network_Administration(NetworkUser user)
        {
            InitializeComponent();
            this.user = user;
            editMode = EditMode.Current;
        }

        #region DropShadow

        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        #endregion

        private void Network_Administration_Load(object sender, EventArgs e)
        {
            #region ThemeColors

            ThemeColors.SetBorders(this);
            ThemeColors.SetControls(this.Controls);
            ThemeColors.SetControls(userHeader_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(userLoginHeader_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(userRolesHeader_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(userPerson_Label, ThemeColors.ControlType.Menu);
            ThemeColors.SetControls(userList_FlowLayoutPanel, ThemeColors.ControlType.List);

            #endregion

            #region UserRols

            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(flowLayoutPanel2);


            #endregion

            LoadNetworkUsers();
            SetEditMode();
        }

        // Methods

        private void SetEditMode()
        {
            // Set Default Controls



            userHeader_Label.Enabled = (editMode == EditMode.Normal);
            userList_FlowLayoutPanel.Enabled = (editMode == EditMode.Normal);
            
            remove_Button.Visible = true;

            userLoginHeader_Label.BackColor = ThemeColors.Menu;
            userRolesHeader_Label.BackColor = ThemeColors.Menu;
            userPerson_Label.BackColor = ThemeColors.Menu;

            addSave_Button.Text = "Add";
            editCancel_Button.Text = "Edit";

            // Check EditMode

            switch (editMode)
            {
                case EditMode.New:
                    user = new NetworkUser();
                    AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(userList_FlowLayoutPanel);
                    this.footer1.UpdateFooterText("Adding User");
                    break;

                case EditMode.Edit:
                    this.footer1.UpdateFooterText("Editing " + user.Username);
                    break;

                case EditMode.Current:
                    this.footer1.UpdateFooterText("Editing " + user.Username);
                    remove_Button.Visible = false;
                    break;

                case EditMode.Normal:
                    LoadNetworkUsers();
                    break;
            }

            if (editMode != EditMode.Normal)
            {
                userLoginHeader_Label.BackColor = ThemeColors.Red;
                userRolesHeader_Label.BackColor = ThemeColors.Red;
                userPerson_Label.BackColor = ThemeColors.Red;

                addSave_Button.Text = "Save";
                editCancel_Button.Text = "Cancel";
            }

            bool ReadOnly = (editMode == EditMode.Normal);

            usernameTextBox.ReadOnly = ReadOnly;
            passwordTextBox.ReadOnly = ReadOnly;
            preFixTextBox.ReadOnly = ReadOnly;
            firstNameTextBox.ReadOnly = ReadOnly;
            lastNameTextBox.ReadOnly = ReadOnly;
            contactNumberTextBox.ReadOnly = ReadOnly;
            emailTextBox.ReadOnly = ReadOnly;
            noteTextBox.ReadOnly = ReadOnly;
            
            BindSources();
        }

        private void BindSources()
        {
            if (user != null) networkUserBindingSource.DataSource = user;
        }

        private void LoadNetworkUsers()
        {
            AMS.Utilities.Controls.FlowlayoutPanel.CleanUp(userList_FlowLayoutPanel);

            foreach (var i in AMS.Users.UserManager.NetworkUsers)
            {
                Label l = new Label();
                l.Size = new Size(userList_FlowLayoutPanel.Size.Width - 1, 20);
                l.Text = i.Username;
                l.TextAlign = ContentAlignment.MiddleLeft;
                l.Click += UserLabel_Click;
                l.Margin = new System.Windows.Forms.Padding(1);
                l.BackColor = ThemeColors.ControlList;

                if (editMode == EditMode.Normal) userList_FlowLayoutPanel.Controls.Add(l);
                else
                {
                    if (i.Username == user.Username) userList_FlowLayoutPanel.Controls.Add(l);
                }
            }

            BindSources();
        }

        private bool Save()
        {
            bool saved = false;

            if (usernameTextBox.Text.ToString().Trim() != "" && passwordTextBox.Text.ToString().Trim() != "" && firstNameTextBox.Text.ToString().Trim() != "" && emailTextBox.Text.ToString().Trim() != "")
            {
                user.FirstName = firstNameTextBox.Text;
                user.LastName = lastNameTextBox.Text;
                user.ContactNr = contactNumberTextBox.Text;
                user.Email = emailTextBox.Text;
                user.Notes = noteTextBox.Text;

                user.Username = usernameTextBox.Text;
                user.Password = passwordTextBox.Text;
                user.Prefix = preFixTextBox.Text;

                saved = UserManager.SaveNetworkUser(user);

                this.footer1.UpdateFooterText("User Saved");

            }
            else
            {
                AMS.MessageBox_v2.Show("Please enter relevant information\r\nUserName\r\nPassword\r\nFirstName\r\nEmail");
            }

            if (saved)
            {
                LoadNetworkUsers();
            }

            return saved;
        }

        // Events

        private void UserLabel_Click(object sender, EventArgs e)
        {
            foreach (Control c in userList_FlowLayoutPanel.Controls)
                c.BackColor = ThemeColors.ControlList;

            ((Label)sender).BackColor = ThemeColors.SelectedControl;

            user = UserManager.GetNetworkUser(((Label)sender).Text.ToString());
            BindSources();
        }

        private void AddSave_Click(object sender, EventArgs e)
        {
            // Set to add new data
            if (editMode == EditMode.Normal)
            {
                editMode = EditMode.New;
                SetEditMode();
                return;
            }

            // Save Current Data
            if (editMode == EditMode.New || editMode == EditMode.Edit || editMode == EditMode.Current)
            {
                if (Save())
                {
                    editMode = EditMode.Normal;
                    SetEditMode();
                }
                return;
            }
        }

        private void EditCancel_Click(object sender, EventArgs e)
        {
            // When clicked on cancel
            if (editMode == EditMode.New || editMode == EditMode.Edit)
            {
                editMode = EditMode.Normal;
                SetEditMode();
            }
            else
            {
                editMode = EditMode.Edit;
                SetEditMode();
            }
        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (AMS.MessageBox_v2.Show("Close " + AMS.Settings.Program.Name + " Network User Manager?", MessageType.Question) == MessageOut.YesOk)
                this.Close();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (user != null)
                AMS.Users.UserManager.RemoveNetworkUser(user);

            LoadNetworkUsers();
        }
    }
}
