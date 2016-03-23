module App {
    export class StudentController {

        Student:Student;
        private studentService: StudentService;
        private stateService: angular.ui.IStateService;
        static $inject = ["StudentService", '$state'];
        constructor(studentService: StudentService, $state: angular.ui.IStateService) {
            this.Student = new Student();
            this.studentService = studentService;
            this.stateService = $state;
        }

        Save() {
            console.log(this.Student);
            var self = this;

            var successCallback = result => {
                console.log(result);
                if (result.data) {
                    self.stateService.go('root.student-list');
                } else {
                    alert("Duplicate city!");
                }
            };
            var errorCallback = error => {
                console.log(error);
            };

            self.studentService.Save(self.Student)
                .then(successCallback, errorCallback);
        }

        IsEmailExist() {
            var self = this;

            var successCallback = result => {
                console.log(result);
                if (result.data) {
                    alert("Already exists !");
                }
              
            };
            var errorCallback = error => {
                console.log(error);
            };

            self.studentService.IsEmailExist(self.Student)
                .then(successCallback, errorCallback);
        }
    }

    angular.module('app').controller('StudentController', StudentController);
}