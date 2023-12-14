using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pizzaDelivery {
    public class User {
        public int id { get; set; }
        private string firstName, lastName, address, email, phoneNum, password;
        public string FirstName {
            get => firstName;
            set => firstName = value;
        }
        public string LastName {
            get => lastName;
            set => lastName = value;
        }
        public string Address {
            get => address;
            set => address = value;
        }

        public string Email {
            get => email;
            set => email = value;
        }
        public string PhoneNum {
            get => phoneNum;
            set => phoneNum = value;
        }

        public string Password {
            get => password;
            set => password = value;
        }

        public User() { }

        public User(string firstName, string lastName, string address, string email, string phoneNum, string password) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.email = email;
            this.phoneNum = phoneNum;
            this.password = password;
        }
    }
}
