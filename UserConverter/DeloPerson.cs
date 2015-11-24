using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserConverter {
    class DeloPerson {
        private string DepartmentID;
        private string DepartmentName;
        private string PersonID;
        private string PersonName;

        public DeloPerson(string DepartmentID, string PersonID, string DepartmentName, string PersonName) {
            this.DepartmentID = DepartmentID;
            this.PersonID = PersonID;
            this.DepartmentName = DepartmentName;
            this.PersonName = PersonName;
        }

        public string GetDepartmentID() {
            return this.DepartmentID;
        }

        public string GetDepartmentName() {
            return this.DepartmentName;
        }

        public string GetPersonID() {
            return this.PersonID;
        }

        public string GetPersonName() {
            return this.PersonName;
        }
    }
}
