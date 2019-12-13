using Password_Manager.Contract;
using System;
using System.Windows.Forms;

namespace PasswordManagerGUI {
    public partial class EditGroupDialog : AwesomeFramelessForm {
        private IPasswordSage _passwordManager;
        private CredentialGroup _group { get; set; }

        public CredentialGroup EditedGroup { get; set; }

        public EditGroupDialog(IPasswordSage passwordManager, CredentialGroup group) {
            InitializeComponent();
            DoMagic();
            _passwordManager = passwordManager;

            EditedGroup = group;
            _group = (CredentialGroup)group.Clone();

            tbGroupName.Text = _group.Name;
        }

        public EditGroupDialog(IPasswordSage passwordManager) {
            InitializeComponent();
            DoMagic();
            _passwordManager = passwordManager;
        }

        private void ButtonOk_Click(object sender, EventArgs e) {
            string groupName = tbGroupName.Text;
            
            try {
                if (_group != null) {
                    _group.Name = groupName;
                    EditedGroup = _passwordManager.UpdateGroup(EditedGroup, _group);
                }
                else {
                    EditedGroup = _passwordManager.CreateGroup(groupName);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
