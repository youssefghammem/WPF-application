using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWPF.Model;
using TestWPF.Commends;

namespace TestWPF.ViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged_Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        StudentService ObjStudentService;
        public StudentViewModel()
        {
            ObjStudentService = new StudentService();
            LoadData();
            CurrentStudents = new StudentDTO();
            saveCommand = new RelayCommand(Save);
          
            updateCommand = new RelayCommand(Update);
            deleteCommand = new RelayCommand(Delete);
        }

        private string message;
        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged("Message"); }
        }

        #region DisplayOperation
        private ObservableCollection<StudentDTO> studentList;
        public ObservableCollection<StudentDTO> Studentlist
        {
            get { return studentList; }
            set { studentList = value; OnPropertyChanged("Studentlist"); }
        }
        private void LoadData()
        {
            Studentlist = new ObservableCollection<StudentDTO>(ObjStudentService.GetAll());
        }
        #endregion

        #region SaveOperation
        private StudentDTO currentStudent;
        public StudentDTO CurrentStudents
        {
            get { return currentStudent; }
            set { currentStudent = value; OnPropertyChanged("CurrentStudents"); }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        public void Save()
        {
            try
            {
                var IsSaved = ObjStudentService.Add(CurrentStudents);
                LoadData();
                if (IsSaved)
                    Message = "Student saved";
                else
                    Message = "Save operation failed";
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

       

        #region UpdateOperation
        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get { return updateCommand; }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = ObjStudentService.Update(CurrentStudents);
                if (IsUpdated)
                {
                    Message = "Student updated";
                    LoadData();
                }
                else
                {
                    Message = "Update operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion

        #region DeleteOperation
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }

        public void Delete()
        {
            try
            {
                var IsDeleted = ObjStudentService.Delete(CurrentStudents.Id);
                if (IsDeleted)
                {
                    Message = "Student deleted";
                    LoadData();
                }
                else
                {
                    Message = "Delete operation failed";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }
        #endregion
    }
}

