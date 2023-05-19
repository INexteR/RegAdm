using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;
using RegAdmModel.Helpers;
using Model.Interfaces;
using System.Data;

namespace RegAdmViewModels
{
    public class TempUser : ValidationBase, IUser
    {
        public TempUser()
        {
            FullName = null;
            BirthDate = null;
            Role = null;
            Login = null;
            Password = null;
        }
        public int Id { get; set; }

        public string? FullName
        {
            get => Get<string>();
            set
            {
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError("Введите ФИО");
                }
                else if (value.Trim().Split().Length < 3)
                {
                    AddError("Введите ФИО через пробелы");
                }
                Set(value);
            }
        }

        public DateOnly? BirthDate
        {
            get => Get<DateOnly?>();
            set
            {
                ClearErrors();
                if (value.HasValue)
                {
                    int age = Funcs.GetAge(value.Value);
                    if (age < 18)
                    {
                        AddError("Сотруднику должно быть 18 лет");
                    }
                }
                else
                {
                    AddError("Введите дату рождения");
                }
                Set(value);
            }
        }

        public string? Role
        {
            get => Get<string>();
            set
            {
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError("Выберите должность");
                }
                Set(value);
            }
        }

        public string? Login
        {
            get => Get<string>();
            set
            {
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError("Введите логин");
                }
                else if (value.Length < 10)
                {
                    AddError("Логин должен состоять минимум из 10 символов");
                }
                Set(value);
            }
        }

        public string? Password
        {
            get => Get<string>();
            set
            {
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError("Введите пароль");
                }
                else if (value.Length < 8)
                {
                    AddError("Пароль должен состоять минимум из 8 символов");
                }
                Set(value);
            }
        }

        string IUser.FullName => FullName!;

        DateOnly IUser.BirthDate => BirthDate!.Value;

        string IUser.Role => Role!;

        string IUser.Login => Login!;

        string IUser.Password => Password!;

        IEnumerable<IReservation> IUser.Reservations => throw new NotImplementedException();
    }
}
