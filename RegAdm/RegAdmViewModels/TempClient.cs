using Model.Interfaces;
using RegAdmModel.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace RegAdmViewModels
{
    public class TempClient : ValidationBase, IClient
    {
        public TempClient()
        {
            FullName = null;
            BirthDate = null;
            Seria = null;
            Number = null;
            Phone = null;
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

        public string? Seria
        {
            get => Get<string>();
            set
            {
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError("Введите серию");
                }
                else if (value.Length != 4)
                {
                    AddError("Серия должна состоять из 4 цифр");
                }
                Set(value);
            }
        }
                     
        public string? Number
        {
            get => Get<string>();
            set
            {
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError("Введите номер");
                }
                else if (value.Length != 6)
                {
                    AddError("Номер должен состоять из 6 цифр");
                }
                Set(value);
            }
        }
                     
        public string? Phone
        {
            get => Get<string>();
            set
            {
                ClearErrors();
                if (string.IsNullOrWhiteSpace(value))
                {
                    AddError("Введите номер");
                }
                else if (value.Length != 11)
                {
                    AddError("Номер должен состоять из 11 цифр");
                }
                Set(value);
            }
        }

        string IClient.FullName => FullName!;

        DateOnly IClient.BirthDate => BirthDate!.Value;

        string IClient.Seria => Seria!;

        string IClient.Number => Number!;

        string IClient.Phone => Phone!;

        IEnumerable<IReservation> IClient.Reservations => throw new NotImplementedException();
    }
}
