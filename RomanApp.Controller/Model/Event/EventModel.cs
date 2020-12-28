using System;
using System.Collections.ObjectModel;

namespace RomanApp.Controller.Model.Event
{
    public class EventModel : EntityModel
    {
        public EventModel()
        {
            Guests = new ObservableCollection<GuestModel>();
            Expenses = new ObservableCollection<ExpenseModel>();
        }

        public EventModel(RomanApp.Service.Entities.Event entity)
            : this()
        {
            Map(entity);
        }

        public void Map(RomanApp.Service.Entities.Event entity)
        {
            base.Map(entity);
            DateCreated = entity.DateCreated;
            Guests.Clear();
            Expenses.Clear();
            
            foreach(var o in entity.Guests)
            {
                Guests.Add(new GuestModel(o));
            }

            foreach (var o in entity.Expenses)
            {
                Expenses.Add(new ExpenseModel(o));
            }
        }

        #region Properties

        private DateTime _dateCreated;
        public DateTime DateCreated
        {
            get
            {
                return _dateCreated;
            }
            set
            {
                _dateCreated = value;
                OnPropertyChanged(nameof(DateCreated));
            }
        }


        private ObservableCollection<GuestModel> _guests;
        public ObservableCollection<GuestModel> Guests
        {
            get
            {
                return _guests;
            }
            set
            {
                _guests = value;
                OnPropertyChanged(nameof(Guests));
            }
        }

        private ObservableCollection<ExpenseModel> _expenses;
        public ObservableCollection<ExpenseModel> Expenses
        {
            get
            {
                return _expenses;
            }
            set
            {
                _expenses = value;
                OnPropertyChanged(nameof(Expenses));
            }
        }

        #endregion

    }
}
