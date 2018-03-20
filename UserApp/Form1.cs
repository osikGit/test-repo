using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserApp
{
    public partial class Form1 : Form
    {
        EFDbContext context = new EFDbContext();
        List<User> users;

        public Form1()
        {
            InitializeComponent();
            users = context.Users.ToList();
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            List<User> matches = users
                .Where(x => x.Username == username)
                .ToList();
            User match;
            if (matches.Count < 1)
            {
                MessageBox.Show("User not found.");
                return;
            }
            else
            {
                match = matches.FirstOrDefault();
            }
            if (match.Password == password)
            {
                MessageBox.Show("Welcome, " + match.Name);
            }
            else
            {
                MessageBox.Show("Incorrect password!");
            }
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            string username = regUsernameBox.Text;
            string password = regPasswordBox.Text;
            string name = regNameBox.Text;

            List<User> matches = users
                .Where(x => x.Username == username)
                .ToList();
            if(matches.Count > 0)
            {
                MessageBox.Show("This username is already exists!");
                return;
            }
            User newUser = new User();
            try
            {
                newUser.UserId = users.Count;
                newUser.Name = name;
                newUser.Username = username;
                newUser.Password = password;
                context.Users.Add(newUser);
                context.SaveChanges();
                MessageBox.Show("User registered!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
