using FinalProject.DAL;
using FinalProject.Models;
using FinalProject.Models.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MAS_FinalProject
{
    /// <summary>
    /// Interaction logic for ViewAppointments.xaml
    /// </summary>
    public partial class ViewAppointments: Window
    {
        public int VisitId { get; set; }
        MasDbContext _context;
        string selectedRadioButton;
        DateTime selectedDate;
        string selectedLastName;


        public ViewAppointments()
        {
            InitializeComponent();

            _context = new MasDbContext();

            LoadData();

        }

        private void LoadData()
        {


            var login = new Login {
                Password = "asdqwe"
            };

            var account = new Account {
                CreationDate = DateTime.Now,
                Login = login,

            };

            login.Account = account;

            var doctor = new Doctor {
                FirstName = "John",
                LastName = "Done",
                Hiredate = DateTime.Now,
                Account = account,
                DoctorSpecialty = FinalProject.Models.enums.DoctorSpecialty.Dentistry,
                GenderType = FinalProject.Models.enums.GenderType.Male,
                Email = "john@medical.com",
                Salary = 25000,
                Title = "dr.John",
                Address = "medical ulica krakowska",
                PhoneNumber = "253213213"
            };

            var appointment = new Appointment {
                AppointmentId = 1,
                VisitDate = new DateTime(2023, 5, 22), // Example date value
                BookingDate = new DateTime(2023, 5, 22),
                SlotNumber = 3,
                Status = AppointmentStatus.Booked,
                DoctorId = 1,
                PatientId = 1,
                ReceptionistId = 1,
            };

            // Access the Slots dictionary values:
            string slotDescription = Appointment.Slots[appointment.SlotNumber];

            try {
                using (var db = new MasDbContext()) {
                    db.Doctor.Add(doctor);
                    db.Appointment.Add(appointment);
                    db.SaveChanges();
                }
            }
            catch (Exception ex) {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new VisitDetails(VisitId).Show();
        }

        private void radioButton1_Checked(object sender, RoutedEventArgs e)
        {
            using (var context = new MasDbContext()) {
                // Filter appointments based on criteria for RadioButton1
                //appointments = appointmentsQuery.Where(a => a.VisitDate.Date == selectedDate.Date).ToList();
                appointmentsList.Items.Add(from a in context.Appointment
                                           where a.VisitDate == selectedDate
                                           select a);
            }
        }

        private void radioButton2_Checked(object sender, RoutedEventArgs e)
        {
            using (var context = new MasDbContext()) {
                // Filter appointments based on criteria for RadioButton1
                //appointments = appointmentsQuery.Where(a => a.VisitDate.Date == selectedDate.Date).ToList();
                appointmentsList.Items.Add(from a in context.Appointment
                                           where a.Patient.LastName == selectedLastName
                                           select a);
            }
        }

        private void radioButton3_Checked(object sender, RoutedEventArgs e)
        {
            //TODO: implement 
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
